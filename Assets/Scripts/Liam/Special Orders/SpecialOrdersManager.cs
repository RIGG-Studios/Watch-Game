using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class handles the special order list, so if the player doesn't want to do a special order 
//when they come in, they can save it for later and do it when they want too.
public class SpecialOrdersManager : EventBase
{
    //list of the special orders in the queue, however we want to know the button/SpecialOrderButton UI item its attached to, 
    //so we make it into a dictionary
    private Dictionary<WatchProperties, GameObject> specialOrderQueue = new Dictionary<WatchProperties, GameObject>();

    public GameObject specialOrderPrefab;
    public GameObject specialOrderRequirementItem;

    public Transform firstGrid;
    public Transform secondGrid;

    private PlayerManager player
    {
        get
        {
            return FindObjectOfType<PlayerManager>();
        }
    }

    private PlayerWatchManager playerWatchManager
    {
        get
        {
            return FindObjectOfType<PlayerWatchManager>();
        }
    }

    private GameTime gameTime
    {
        get
        {
            return FindObjectOfType<GameTime>();
        }
    }

    private PlayerInventory playerInventory
    {
        get
        {
            return FindObjectOfType<PlayerInventory>();
        }
    }

    //add watch to special order list, with the correct item requirements
    public void AddComponentsToGrid(int gridType)
    {
        //get a reference to the newest watch in the player watch manager.
        WatchProperties newWatch = playerWatchManager.queuedWatchProperties;

        //if the watch is null, or we already have this watch in the list
        //we will not add it to the list
        if (newWatch == null || specialOrderQueue.ContainsKey(newWatch))
            return;

        //if the grid type is 1, meaning we are using the SpecialOrdersGroup UI Group, we will change the grid the required items
        //get populated too so we can see the required items BEFORE saving it for later, and AFTER.
        if(gridType == 1 && firstGrid.childCount <= 0)
        {
            //loop through all the required components of the watch
            for (int i = 0; i < newWatch.requiredComponents.Count; i++)
            {
                //for each component create a UI element represnting it on the SpecialOrderButton
                GameObject order = Instantiate(specialOrderRequirementItem, firstGrid);

                //set it up with the required component data
                order.GetComponent<SpecialOrderItem>().Setup(newWatch.requiredComponents[i]);
            }
            //return since we dotn want to continue
            return;
        }

        //Create a special order button, and find the component on the new object
        SpecialOrderButton specialOrder = Instantiate(specialOrderPrefab, secondGrid).GetComponent<SpecialOrderButton>();

        //set up the special order with the correct parameters
        specialOrder.Setup(System.Enum.GetName(typeof(WatchProperties.WatchDifficulty), newWatch.watchDifficulty), newWatch.watchReward, newWatch, this);

        //same as above, loop through the required components but this time spawn them on the special order grid
        //so they will be seen in the special order list as well.
        for (int i = 0; i < newWatch.requiredComponents.Count; i++)
        {
            GameObject order = Instantiate(specialOrderRequirementItem, specialOrder.grid);

            order.GetComponent<SpecialOrderItem>().Setup(newWatch.requiredComponents[i]);
        }

        //finally, add the new watch and gamewobject we made for it to the list
        specialOrderQueue.Add(newWatch, specialOrder.gameObject);        
    }

    public void BuildWatch(WatchProperties watchProperties)
    {
        //when we go to build a watch from the special order list, we must check if the player has enough materials/items
        //to create the watch
        if (!player.CanBuildWatch(playerWatchManager.queuedWatchProperties.requiredComponents.ToArray()))
            return;

        //if so, set up the game timer because this is a special watch
        gameTime.SetupTimer(watchProperties.timeToComplete);
        //and spawn a watch with the watch properties given
        playerWatchManager.SpawnWatch(watchProperties);

        //since we spawned this watch item, remove it from the list as we are currently building the order.
        RemoveWatch(watchProperties);
    }

    private void RemoveWatch(WatchProperties watchToRemove)
    {
        if (watchToRemove == null)
            return;

        //destroy the object
        Destroy(specialOrderQueue[watchToRemove]);
        //remove it from the list
        specialOrderQueue.Remove(watchToRemove);
    }
}
