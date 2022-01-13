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
    public Database database;
    public SlotManager slots;

    private void Start()
    {
        slots.InitializeSlots(inventorySize);
    }

    //method for adding items to our inventory
    public void AddItem(Item item, int amount = 1)
    {
        //when we add an item, check for a bunch of conditions to make sure we can add the item without errors
        if (item == null && database.HasItem(item.itemName) || inventory.Count - 1 > inventorySize)
            return;

        if (inventory.ContainsKey(item))
        {
            inventory[item] += amount;
            slots.FindSlotFromItem(item).SetQuantity("x" + inventory[item]);
            return;
        }

        //if everything is clear, add the items and also update the slots
        inventory.Add(item, amount);
        slots.AddItemToSlot(item);
    }


    //method for removing items from our inventory
    public void RemoveItem(Item item, int amount)
    {
        //check if the item is null, which will result in an error if the method went ahead.
        if (item == null)
            return;

        if (inventory.ContainsKey(item))
        {
            inventory[item] -= amount;
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
            if (item == items.Key && (items.Value - amount) >= 0)
            {
                return true;
            }
        }

        return false;
    }
}
