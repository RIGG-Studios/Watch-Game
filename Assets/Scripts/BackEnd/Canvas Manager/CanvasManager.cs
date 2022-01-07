using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GroupTransitionMethods
{
    Animation,
    Fade,
    None
}

public class CanvasManager : EventBase
{
    private UIElementGroup[] allElements;

    private void Start()
    {
        allElements = FindElements();

        foreach (UIElementGroup gr in allElements)
            gr.PlayAnimation(false);
    }

    private UIElementGroup[] FindElements()
    {
        UIElementGroup[] elements = GetComponentsInChildren<UIElementGroup>();

        return elements.Length > 0 ? elements : null;
    }

    public UIElementGroup FindElementGroupByID(string id)
    {
        for(int i = 0; i < allElements.Length; i++)
        {
            if (allElements[i].groupID == id)
                return allElements[i];
        }

        return null;
    }

    public void ShowElementGroup(UIElementGroup group, GroupTransitionMethods method, bool clearOtherElements)
    {
        foreach (UIElementGroup e in allElements)
        {
            if(method == GroupTransitionMethods.Fade)
            {
                if (group == e)
                {
                    group.LerpAlpha(1, 1);
                }
                else
                {
                    if (clearOtherElements)
                        e.LerpAlpha(0, 1);
                }
            }
            else if(method == GroupTransitionMethods.Animation)
            {
                if (group == e)
                {
                    group.PlayAnimation(true);
                }
                else
                {
                    if (clearOtherElements)
                        e.PlayAnimation(false);
                }
            }
        }
    }

    public void HideElementGroup(UIElementGroup group, GroupTransitionMethods method)
    {
        switch (method)
        {
            case GroupTransitionMethods.Animation:
                group.PlayAnimation(false);
                break;

            case GroupTransitionMethods.Fade:
                group.LerpAlpha(0, 1);
                break;
        }


    }
}
