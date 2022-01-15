using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class handles all of our shop management
public class ShopManager : MonoBehaviour
{
    public SlotManager slots;

    //our shop is essentially a list of items, but we also need to keep track of the stock of the items,
    //so we store it in a dictionary.
    private Dictionary<Item, int> itemsInShop = new Dictionary<Item, int>();

    //get reference to the selected item in the shop
    private Item selectedItem;
    private bool shopShown;

    public int buyAmount = 1;

    private CanvasManager canvas
    {
        get
        {
            return FindObjectOfType<CanvasManager>();
        }
    }

    private PlayerManager player
    {
        get
        {
            return FindObjectOfType<PlayerManager>();
        }
    }

    private void Start()
    {
        //find all items in the database
        Item[] items = Database.itemDatabase;

        //loop through all the items in the shop
        for(int i = 0; i < items.Length; i++)
        {
            if (items[i].itemCost >= 1)
            {
                AddItem(items[i], 100);
            }
        }

        //after the shop list has been initialized, initialize the slots for the shop
        slots.InitializeSlots(items.Length, items);
    }


    //method for adding an item to the shop
    public void AddItem(Item item, int stock)
    {    
        //check if the item is null, or the shop already CONTAINS this item
        if (item == null || itemsInShop.ContainsKey(item))
            return;

        itemsInShop.Add(item, stock);
        slots.AddItemToSlot(item, 0);
    }

    //method for removing an item from the shop
    public void RemoveItem(Item item)
    {
        //check if the item is null or the shop DOESN'T contain the item
        if (item == null || !itemsInShop.ContainsKey(item))
            return;

        itemsInShop.Remove(item);
    }

    //method for showcasing an item, eg when we click on a item in the shop
    public void ShowcaseItem(Item item)
    {
        if (item == null)
            return;

        //when we select an item, set the selected item to the item
        selectedItem = item;

        if (player.CanBuyItem(buyAmount * selectedItem.itemCost))
        {
            //find the Buy confirmation UI group in the canvas manager
            UIElementGroup group = canvas.FindElementGroupByID("BuyConfirmationGroup");

            //find a specific element in the group, and overriding its value with the item name
            group.FindElement("buyconfirmationitemname").OverrideValue(item.itemName);

            //finally, we must update the canvas.
            canvas.ShowElementGroup(group, false);
        }
    }


    //method for when we click the buy item button
    public void BuyItem()
    {
        int stock = 0;
        itemsInShop.TryGetValue(selectedItem, out stock);

        player.playerWatches -=  buyAmount * selectedItem.itemCost;
        player.AddItem(selectedItem, buyAmount);
        RemoveItem(selectedItem);

        canvas.FindElementGroupByID("GameGroup").FindElement("watchcounttext").OverrideValue(((int)player.playerWatches).ToString());
    }

    public void UpdateBuyAmount(int amount) => buyAmount = amount;
}
