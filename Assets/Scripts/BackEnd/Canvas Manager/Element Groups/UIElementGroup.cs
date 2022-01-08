using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum UpdateTypes
{
    Animation,
    Fade
}

//this script handles grouping of different ui elements
[RequireComponent(typeof(Animator))]
public class UIElementGroup : MonoBehaviour
{
    //id for the group
    public string groupID;

    //list of elements this group contains
    public UIElement[] elementsInGroup;

    public UpdateTypes hideType;

    bool inShownPlace;

    //create a property of our animator
    private Animator animator
    {
        get
        {
            return GetComponent<Animator>();
        }
    }

    //method for finding elements
    public UIElement FindElement(string id)
    {
        for(int i = 0; i < elementsInGroup.Length; i++)
        {
            if (id == elementsInGroup[i].id)
            {
                return elementsInGroup[i];
            }
        }
        return null;
    }

    public void UpdateElements(float targetAlpha, float duration, bool show)
    {
        switch (hideType)
        {
            case UpdateTypes.Animation:
                PlayAnimation(show);
                break;

            case UpdateTypes.Fade:
                StartCoroutine(IELerpAlpha(targetAlpha, duration));
                break;
        }
    }


    //method for playing animations
    private void PlayAnimation(bool show)
    {
        if (show)
        {
            animator.SetTrigger("show");
            inShownPlace = true;
        }
        else
        {
            if (inShownPlace)
            {
                animator.SetTrigger("hide");
                inShownPlace = false;
            }
        }
    }

    private IEnumerator IELerpAlpha(float targetAlpha, float duration)
    {
        //create a temp time variable
        float t = 0;

        //while our time is less than 1, lerp towards a value
        while (t < 1)
        {
            t += Time.deltaTime;// increase time

            for (int i = 0; i < elementsInGroup.Length; i++) //for every element in the group
            {
                //cross fade the graphics to the desired alpha, based on the duration
                elementsInGroup[i].graphics.CrossFadeAlpha(targetAlpha, duration, false);
            }

            yield return null;
        }
    }

    //method for our editor script to find all ui elements underneath this obj, and assign the
    //id to the name of the gameobject
    public void FindUIElements()
    {
        UIElement[] elements = GetComponentsInChildren<UIElement>();
        groupID = gameObject.name;

        if (elements.Length > 0)
            elementsInGroup = elements;
        else
        {
            Text[] texts = GetComponentsInChildren<Text>();

            if (texts.Length > 0)
            {
                foreach (Text txt in texts)
                {
                    txt.gameObject.AddComponent<TextElement>();
                    txt.gameObject.GetComponent<TextElement>().Setup();
                }
            }

            Image[] images = GetComponentsInChildren<Image>();

            if (images.Length > 0)
            {
                foreach (Image img in images)
                {
                    img.gameObject.AddComponent<ImageElement>();
                    img.gameObject.GetComponent<ImageElement>().Setup();
                }
            }

            UIElement[] elem = GetComponentsInChildren<UIElement>();

            if (elem.Length > 0)
                elementsInGroup = elem;
        }
    } 
}
