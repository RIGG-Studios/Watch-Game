using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//different ways to transition UI menus
public enum GroupTransitionMethods
{
    Animation,
    Fade,
    None
}

//this class handles managing of the canvas and ui elements
public class CanvasManager : EventBase
{
    //create a list of our ui element groups, since this is the main things we modify
    private UIElementGroup[] allElements;

    private void Start()
    {
        //find the elements
        allElements = FindElements();

        //to start, play the hide animation on all elements so they aren't visible.
        foreach (UIElementGroup gr in allElements)
            gr.PlayAnimation(false);
    }

    private UIElementGroup[] FindElements()
    {
        //find all components that are a UIElementGroup underneath this gameobject
        UIElementGroup[] elements = GetComponentsInChildren<UIElementGroup>();

        //return it the array if its length is > 0.
        return elements.Length > 0 ? elements : null;
    }

    //method for finding groups based on group id
    public UIElementGroup FindElementGroupByID(string id)
    {
        //loop through all of our elements
        for(int i = 0; i < allElements.Length; i++)
        {
            //simply check if our id equals any in the list, and if so return it
            if (allElements[i].groupID == id)
                return allElements[i];
        }

        //otherwise return null
        return null;
    }

    //method for showing element groups
    public void ShowElementGroup(UIElementGroup group, GroupTransitionMethods method, bool clearOtherElements)
    {
        //loop through all of our elements
        foreach (UIElementGroup e in allElements)
        {
            //check which method we are using
            if(method == GroupTransitionMethods.Fade)
            {
                //check if our group is equal to any of the ones in the list, meaning we found the one
                if (group == e)
                {
                    group.LerpAlpha(1, 1);
                }
                else
                {
                    //for every other element, do we want to hide it?
                    if (clearOtherElements)
                        e.LerpAlpha(0, 1); //if we want to hide it, hide it based on the transition mode.
                }
            }
            else if(method == GroupTransitionMethods.Animation)
            {
                //same method as above, but instead of lerping alphas we play an animation.
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


    //method for hiding specific elements
    public void HideElementGroup(UIElementGroup group, GroupTransitionMethods method)
    {
        //switch the transition type
        switch (method)
        {
            case GroupTransitionMethods.Animation:
                group.PlayAnimation(false); //play the hide animation on this group
                break;

            case GroupTransitionMethods.Fade:
                group.LerpAlpha(0, 1); //lerp the element alpha to 0, over a duration of 1s
                break;
        }


    }
}
