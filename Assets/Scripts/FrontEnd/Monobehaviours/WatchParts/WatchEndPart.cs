using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Probably the most common implementation of IWatch, besides AbstractWatchPart. Defines the end point of the watch,
//essentially this is the point where downwards delegation stops, every watch needs one of these at the end
public class WatchEndPart : MonoBehaviour, IWatch
{
    PlayerManager player;

    //Inserting logic to tell the watch end what to do when insert is called on it
    IInsertable insertingLogic;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerManager>();

        //Gets inserting logic from its "layer"
        insertingLogic = GetComponent<IInsertable>();
        player.TransitionGamemode(false);
    }

    //Returns the dictionary back when asked, creating a base condition for recursion
    public Dictionary<string, int> GetAllComponentsLeft(Dictionary<string, int> dictionary)
    {
        return dictionary;
    }

    //This one's insert method maps 1:1 with its inserting logic's Execute method
    public void Insert(GameObject insertObject, Transform destination) => insertingLogic.Execute(insertObject, destination);
}
