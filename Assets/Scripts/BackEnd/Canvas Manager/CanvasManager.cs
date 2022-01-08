using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class handles managing of the canvas and ui elements
public class CanvasManager : EventBase
{
    //create a list of our ui element groups, since this is the main things we modify
    private UIElementGroup[] allElements;

    private void Awake()
    {
        //find the elements
        allElements = FindElements();

        //to start, play the hide animation on all elements so they aren't visible.
        foreach (UIElementGroup gr in allElements)
            gr.UpdateElements(0, 1, false);
    }

    public override void SceneLoadCallback()
    {
        UIElementGroup group = FindElementGroupByID("SceneIntroGroup");

        ShowElementGroup(group, true);
    }

    public override void StartGameCallback()
    {
        UIElementGroup gameGroup = FindElementGroupByID("GameGroup");

        ShowElementGroup(gameGroup, true);
    }

   
    public override void EndGameCallback()
    {
        UIElementGroup watchBuilt = FindElementGroupByID("WatchCompleteGroup");

        ShowElementGroup(watchBuilt, false);
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
    public void ShowElementGroup(UIElementGroup group, bool clearOtherElements)
    {
        //loop through all of our elements
        foreach (UIElementGroup e in allElements)
        {
            //check which method we are using
            if (group == e)
            {
                group.UpdateElements(1, 0.5f, true);
            }
            else
            {
                //for every other element, do we want to hide it?
                if (clearOtherElements)
                    HideElementGroup(e);
            }
        }
        
    }

    //method for hiding specific elements
    public void HideElementGroup(UIElementGroup group) => group.UpdateElements(0, 1, false);
}
