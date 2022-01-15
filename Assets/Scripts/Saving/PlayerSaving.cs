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
            DateTime timePassed = DateTime.Now - new TimeSpan(PlayerPrefs.GetInt(hoursTag), PlayerPrefs.GetInt(minutesTag), 0);

            int time = timePassed.Minute;

            if(timePassed.Hour > 0)
            {
                time += timePassed.Hour * 60;
            }

            int nextWatches = time * (int)(PlayerPrefs.GetInt(monkeysTag) * playerManager.monkeysPerMinute);

            playerManager.playerWatches = PlayerPrefs.GetInt(minutesTag) + nextWatches;
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
        PlayerPrefs.SetInt(watchesTag, playerManager.playerWatches);
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
