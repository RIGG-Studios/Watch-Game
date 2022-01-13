using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class handles the special order list, so if the player doesn't want to do a special order 
//when they come in, they can save it for later and do it when they want too.
public class SpecialOrdersManager : EventBase
{
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

    //add watch to special order list, with the correct requirements
    public void AddComponentsToGrid(int gridType)
    {
        WatchProperties newWatch = playerWatchManager.queuedWatchProperties;

        if (newWatch == null || specialOrderQueue.ContainsKey(newWatch))
            return;

        if(gridType == 1)
        {
            for (int i = 0; i < newWatch.requiredComponents.Count; i++)
            {
                GameObject order = Instantiate(specialOrderRequirementItem, firstGrid);

                order.GetComponent<SpecialOrderItem>().Setup(newWatch.requiredComponents[i]);
            }
            return;
        }

        SpecialOrderButton specialOrder = Instantiate(specialOrderPrefab, secondGrid).GetComponent<SpecialOrderButton>();

        specialOrder.Setup(System.Enum.GetName(typeof(WatchProperties.WatchDifficulty), newWatch.watchDifficulty), newWatch.watchReward, newWatch, this);

        for (int i = 0; i < newWatch.requiredComponents.Count; i++)
        {
            GameObject order = Instantiate(specialOrderRequirementItem, specialOrder.grid);

            order.GetComponent<SpecialOrderItem>().Setup(newWatch.requiredComponents[i]);
        }

        specialOrderQueue.Add(newWatch, specialOrder.gameObject);        
    }

    public void BuildWatch(WatchProperties watchProperties)
    {
        if (player.CanBuildWatch(playerWatchManager.queuedWatchProperties.requiredComponents.ToArray()))
            return;
        gameTime.SetupTimer(watchProperties.timeToComplete);
        playerWatchManager.SpawnWatch(watchProperties);

        RemoveWatch(watchProperties);
    }

    private void RemoveWatch(WatchProperties watchToRemove)
    {
        if (watchToRemove == null)
            return;

        Destroy(specialOrderQueue[watchToRemove]);
        specialOrderQueue.Remove(watchToRemove);
    }
}
