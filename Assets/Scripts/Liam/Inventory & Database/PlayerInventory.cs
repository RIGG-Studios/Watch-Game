using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //our inventory needs a list of items to know what items we have
    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();

    //size of our inventory
    [Range(3, 10)] public int inventorySize;

    //quick references to the database and slot manager.
    public SlotManager slots;

    private PlayerWatchBuildingMode playerWatchBuildingMode
    {
        get
        {
            return FindObjectOfType<PlayerWatchBuildingMode>();
        }
    }

    private CanvasManager canvas
    {
        get
        {
            return FindObjectOfType<CanvasManager>();   
        }
    }

    private void Awake()
    {
        slots.InitializeSlots(inventorySize);

        if (PlayerPrefs.GetInt("FirstTime") == 0)
        {
            AddItem(Database.GetItem("Screwdriver"), 1);
            AddItem(Database.GetItem("Tweezers"), 1);
            AddItem(Database.GetItem("Reg Monkey"), 1);
        }
    }

    //method for adding items to our inventory
    public void AddItem(Item item, int amount)
    {
        //when we add an item, check for a bunch of conditions to make sure we can add the item without errors
        if (item == null && Database.HasItem(item.itemName) || inventory.Count - 1 > inventorySize)
            return;

        if (inventory.ContainsKey(item))
        {
            inventory[item] += amount;
            slots.FindSlotFromItem(item).SetQuantity("x" + inventory[item]);
            return;
        }

        inventory.Add(item, amount);
        slots.AddItemToSlot(item, amount);
    }


    //method for removing items from our inventory
    public void RemoveItem(Item item, int amount)
    {
        //check if the item is null, which will result in an error if the method went ahead.
        if (item == null)
            return;

        if(item.itemName == "Screwdriver")
        {
            playerWatchBuildingMode.screwDriver.UpdateUses(playerWatchBuildingMode.screwDriver.maxUses);
        }
        if (item.itemName == "Tweezers")
        {
            playerWatchBuildingMode.tweezers.UpdateUses(playerWatchBuildingMode.tweezers.maxUses);
        }

        if (inventory.ContainsKey(item))
        {
            inventory[item] -= amount;
            slots.FindSlotFromItem(item).SetQuantity("x" + amount);
        }

        //remove the item from the list, and also call the slots remove item method
        if (inventory[item] <= 0)
        {
            inventory.Remove(item);
            slots.RemoveItemFromSlot(item);
        }
    }

    public bool HasItem(Item item, int amount)
    {
        foreach(KeyValuePair<Item, int> items in inventory)
        {
            //has item
            if (item == items.Key)
            {
                if((items.Value - amount) >= 0)
                    return true;
            }
        }
        return false;
    }

    public bool HasItem(string item, int amount)
    {
        foreach (KeyValuePair<Item, int> items in inventory)
        {
            //has item
            if (item == items.Key.itemName)
            {
                if ((items.Value - amount) >= 0)
                    return true;
            }
        }
        return false;
    }
    public void SelectSlot(int index)
    {
        Slot slot = slots.FindSlotFromIndex(index);
        Item item = slot.GetItem();

        if (item != null && item.equippable) 
        {
            switch (item.itemName)
            {
                case "Screwdriver":
                    playerWatchBuildingMode.currentTool = playerWatchBuildingMode.screwDriver;
                    break;

                case "Tweezers":
                    playerWatchBuildingMode.currentTool = playerWatchBuildingMode.tweezers;
                    break;
            }


            canvas.FindElementGroupByID("GameGroup").FindElement("toolicon").OverrideValue(item.itemSprite);
            canvas.FindElementGroupByID("GameGroup").FindElement("tooluses").OverrideValue(playerWatchBuildingMode.currentTool.GetRemainingUses().ToString() + "/" + playerWatchBuildingMode.currentTool.maxUses);
            canvas.FindElementGroupByID("GameGroup").FindElement("toolicon").SetActive(true);
            canvas.FindElementGroupByID("GameGroup").FindElement("toolicon").FadeElement(1, 0.25f);
            canvas.FindElementGroupByID("GameGroup").FindElement("tooluses").FadeElement(1, 0.25f);
        }
    }
}
