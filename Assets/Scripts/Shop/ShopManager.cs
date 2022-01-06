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

            if (sellable) itemsInShop.Add(items[i]);
        }

        slots.InitializeSlots(items.Length, items);
    }

}
