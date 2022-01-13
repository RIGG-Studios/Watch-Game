using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class handles all of our shop management
public class ShopManager : MonoBehaviour
{
    public Database database;
    public SlotManager slots;
    public CanvasManager canvas;
    public PlayerManager player;

    //our shop is essentially a list of items, but we also need to keep track of the stock of the items,
    //so we store it in a dictionary.
    private Dictionary<Item, int> itemsInShop = new Dictionary<Item, int>();

    //get reference to the selected item in the shop
    private Item selectedItem;
    private bool shopShown;

    private void Start()
    {
        //find all items in the database
        Item[] items = database.GetItems();

        //loop through all the items in the shop
        for(int i = 0; i < items.Length; i++)
        {
            //check if an item is sellable by checking if the price is greater than 0,
            //maybe we have an item that isnt sellable.
            bool sellable = items[i].itemCost > 0;

            //if its sellable, an that item to our shop list
            if (sellable)
                AddItem(items[i], 100);
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
        slots.AddItemToSlot(item);
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

        if (player.CanBuyItem(item.itemCost))
        {
            //find the Buy confirmation UI group in the canvas manager
            UIElementGroup group = canvas.FindElementGroupByID("BuyConfirmationGroup");

            //find a specific element in the group, and overriding its value with the item name
            group.FindElement("buyconfirmationitemname").OverrideValue(item.itemName);

            //finally, we must update the canvas.
            canvas.ShowElementGroup(group, false);
            canvas.ShowElementGroup(group, false);
        }
    }


    //method for when we click the buy item button
    public void BuyItem()
    {
        //create a temp var for our stock
        int stock = 0;

        //try and find our stock
        itemsInShop.TryGetValue(selectedItem, out stock);

        //deduct money from our playerMoney.
        player.playerWatches -= selectedItem.itemCost;
        player.AddItem(selectedItem);
        //Remove the item from the shop
        RemoveItem(selectedItem);

        canvas.FindElementGroupByID("GameGroup").FindElement("watchcounttext").OverrideValue(player.playerWatches.ToString());
    }
}
