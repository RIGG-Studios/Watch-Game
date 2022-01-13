using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class handles every property a watch will have,
//since we must know a watches difficulty/time to complete/reward amounts
//we have to create a property class for it
[System.Serializable]
public class WatchProperties 
{
    //Easy and organized way to add in different levels of difficulty
    public enum WatchDifficulty
    {
        Easy,
        Normal,
        Hard,
        Advanced,
        Master
    }

    //the name of the watch, like "Victorian Watch", or "Electronic Watch"
    public string watchName;

    //create a var of the type of watch, Normal or Special
    public WatchTypes watchType;   

    //create a variable of the difficulty of the watch, so we can define and access it
    public WatchDifficulty watchDifficulty;

    //the time the player has to complete the watch, if normal watch just leave value at 0 as it doesn't do anything.
    public int timeToComplete;

    //how many watches will the player get rewarded with upon building, normal watches will be 1, while special orders can vary
    public int watchReward;

    //how many layers are in the watch, we could find it in a script to be fancy but for simplicity sake we'll just define it here
    public int layers;

    //a template this watch must follow
    public GameObject template;

    //and finally, a list of component requirements for the watch. This is useful for special orders so we know if we
    //have enough items to build the watch, and how many items it needs
    public List<ComponentRequirement> requiredComponents = new List<ComponentRequirement>();
}

//Class for special orders, so we know how many items and what items is required to build the watch
//Serialize this class so we can see it in inspector
[System.Serializable]
public class ComponentRequirement
{
    //the item required
    public Item itemRequirement;
    public int itemAmount;
}
