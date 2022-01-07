using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this script handles grouping of different ui elements
[RequireComponent(typeof(Animator))]
public class UIElementGroup : MonoBehaviour
{
    //id for the group
    public string groupID;

    //list of elements this group contains
    public UIElement[] elementsInGroup;

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

    //method for playing animations
    public void PlayAnimation(bool show)
    {
        if (show)
            animator.SetTrigger("show");
        else
            animator.SetTrigger("hide");
    }

    //method for calling the Lerp Alpha IEnumerator
    public void LerpAlpha(float targetAlpha, float duration)
    {
        StartCoroutine(IELerpAlpha(targetAlpha, duration));
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
    } 
}
