using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Database database;
    public SlotManager slots;

    private List<Item> itemsInShop = new List<Item>();

    private void Start()
    {
        Item[] items = database.GetItems();

        for(int i = 0; i < items.Length; i++)
        {
            bool sellable = items[i].itemCost > 0;

            if (sellable)
                AddItem(items[i]);
        }

        slots.InitializeSlots(items.Length, items);
    }

    public void AddItem(Item item)
    {
        if (item == null || itemsInShop.Contains(item))
            return;

        itemsInShop.Add(item);
        slots.AddItemToSlot(item);
    }

    public void RemoveItem(Item item)
    {
        if (item == null || !itemsInShop.Contains(item))
            return;

        itemsInShop.Remove(item);
    }

    public void BuyItem(Item item)
    {
        //send a call to the player inventory to add a new item
        RemoveItem(item);
    }
}
