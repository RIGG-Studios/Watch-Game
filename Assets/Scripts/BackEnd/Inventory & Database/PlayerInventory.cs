using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    //our inventory needs a list of items to know what items we have
    public List<Item> itemsInInventory = new List<Item>();

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
    public void AddItem(Item item)
    {
        //when we add an item, check for a bunch of conditions to make sure we can add the item without errors
        if (item == null && database.HasItem(item.itemName) || itemsInInventory.Count - 1 > inventorySize)
            return;

        //if everything is clear, add the items and also update the slots
        itemsInInventory.Add(item);
        slots.AddItemToSlot(item);
    }

    //method for removing items from our inventory
    public void RemoveItem(Item item)
    {
        //check if the item is null, which will result in an error if the method went ahead.
        if (item == null)
            return;

        //remove the item from the list, and also call the slots remove item method
        itemsInInventory.Remove(item);
        slots.RemoveItemFromSlot(item);
    }

    //quick method for finding a random item in the inventory list
    private Item FindRandomItem()
    {
        if (itemsInInventory.Count <= 0)
            return null;

        return itemsInInventory[Random.Range(0, itemsInInventory.Count)];
    }
}
