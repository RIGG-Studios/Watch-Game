using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class PlayerSaving : MonoBehaviour
{
    private PlayerManager playerManager;

    const string firstTimeTag = "FirstTime";
    const string inventoryTag = "InventoryList";
    const string monkeysTag = "Monkeys";
    const string watchesTag = "Watches";
    const string minutesTag = "Minutes";
    const string hoursTag = "Hours";

    private void Awake()
    {
        playerManager = FindObjectOfType<PlayerManager>();
        playerManager.playerMonkeys = PlayerPrefs.GetInt(monkeysTag);

        if (playerManager.playerMonkeys == 0)
        {
            playerManager.playerWatches = PlayerPrefs.GetInt(watchesTag);
        }
        else
        {
            //this code is hard me for to test, as I dont wanna wait around for like 20 minutes not opening the game
            //so it may be not right, however i think the logic is right

            //get the difference in time between when we started, and now
            //we only care about the minutes/hours as minutes only go up to 59 so when we get into the hours we have to consider it in the calculation
            //and seconds would be wasted calculations as minutes are the min we care about
            DateTime timePassed = DateTime.Now - new TimeSpan(PlayerPrefs.GetInt(hoursTag), PlayerPrefs.GetInt(minutesTag), 0);

            //get a ref to the current min
            int time = timePassed.Minute;

            //if we have indeed waited over atleast an hour
            if(timePassed.Hour > 0)
            {
                //get the amount of minutes passed in the hours elapsed, and add that to our current minutes as it could be an hour and 15 minutes or an hour and 35 minutes since we last played
                time += timePassed.Hour * 60;
            }


            //dfinally multiple the total time elapsed by the amount of monkeys we have, multiplied by the monkeys per minute
            //which is gonna be a low value because we want the game to be fun
            float nextWatches = time * (PlayerPrefs.GetInt(monkeysTag) * playerManager.monkeysPerMinute);

            //finally set the current watches to whatever our saved watches are, plus the additional watches
            playerManager.playerWatches = PlayerPrefs.GetFloat(watchesTag) + nextWatches;
        }

        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();

        string message = PlayerPrefs.GetString(inventoryTag);

        string[] items = message.Split('|');


        for (int i = 0; i < items.Length; i++)
        {
            if (Database.GetItem(items[i]))
            {
                inventory.AddItem(Database.GetItem(items[i]), 1);
            }
        }
    }


    //set data
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(monkeysTag, playerManager.playerMonkeys);
        PlayerPrefs.SetFloat(watchesTag, playerManager.playerWatches);
        PlayerPrefs.SetInt(minutesTag, DateTime.Now.Minute);
        PlayerPrefs.SetInt(hoursTag, DateTime.Now.Hour);

        PlayerPrefs.SetInt(firstTimeTag, 1);

        PlayerInventory inventory = FindObjectOfType<PlayerInventory>();

        string message = "";
        foreach(KeyValuePair<Item, int> items in inventory.inventory)
        {
            message += "|" + items.Key.itemName;
        }

        Debug.Log(message);
        PlayerPrefs.SetString(inventoryTag, message);
    }

    public static void ResetPlayerPrefs()
    {
        PlayerPrefs.SetInt(monkeysTag, 0);
        PlayerPrefs.SetInt(watchesTag, 0);
        PlayerPrefs.SetInt(minutesTag, 0);
        PlayerPrefs.SetInt(firstTimeTag, 0);
        PlayerPrefs.SetInt(hoursTag, DateTime.Now.Hour);
        PlayerPrefs.SetString(inventoryTag, string.Empty);
    }
}
