using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class UIElementGroup : MonoBehaviour
{
    public string groupID;

    public UIElement[] elementsInGroup;

    private Animator animator
    {
        get
        {
            return GetComponent<Animator>();
        }
    }

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

    public void PlayAnimation(bool show)
    {
        if (show)
            animator.SetTrigger("show");
        else
            animator.SetTrigger("hide");
    }

    public void LerpAlpha(float targetAlpha, float duration)
    {
        StartCoroutine(IELerpAlpha(targetAlpha, duration));
    }

    private IEnumerator IELerpAlpha(float targetAlpha, float duration)
    {
        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;
            for (int i = 0; i < elementsInGroup.Length; i++)
            {
                elementsInGroup[i].graphics.CrossFadeAlpha(targetAlpha, duration, false);
            }

            yield return null;
        }
    }

    public void FindUIElements()
    {
        UIElement[] elements = GetComponentsInChildren<UIElement>();
        groupID = gameObject.name;

        if (elements.Length > 0)
            elementsInGroup = elements;
    } 
}
