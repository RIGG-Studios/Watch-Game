using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public Database database;
    public SlotManager slots;
    public CanvasManager canvas;
    public PlayerManager player;

    private Dictionary<Item, int> itemsInShop = new Dictionary<Item, int>();
    private Item selectedItem;

    private void Start()
    {
        Item[] items = database.GetItems();

        for(int i = 0; i < items.Length; i++)
        {
            bool sellable = items[i].itemCost > 0;

            if (sellable)
                AddItem(items[i], 1);
        }
        slots.InitializeSlots(items.Length, items);
    }

    public void AddItem(Item item, int stock)
    {
        if (item == null || itemsInShop.ContainsKey(item))
            return;

        itemsInShop.Add(item, stock);
        slots.AddItemToSlot(item);
    }

    public void RemoveItem(Item item)
    {
        if (item == null || !itemsInShop.ContainsKey(item))
            return;

        itemsInShop.Remove(item);
    }

    public void ShowcaseItem(Item item)
    {
        if (item == null)
            return;

        selectedItem = item;

        int nextMoney = player.playerMoney - selectedItem.itemCost;

        if (nextMoney > 0)
        {

            UIElementGroup group = canvas.FindElementGroupByID("Buy_Confirmation_Group");

            group.FindElement("buy_confirmation_item_name").OverrideValue(item.itemName);

            canvas.ShowElementGroup(group, GroupTransitionMethods.Animation, false);
        }
    }

    public void BuyItem()
    {
        int stock = 0;
        itemsInShop.TryGetValue(selectedItem, out stock);

        player.playerMoney -= selectedItem.itemCost;

        RemoveItem(selectedItem); //remove the item from the shop

        if (stock - 1 < 0)
        {
            Debug.Log("Item out of stock!");
        }

        canvas.HideElementGroup(canvas.FindElementGroupByID("Buy_Confirmation_Group"), GroupTransitionMethods.Animation);
    }
}
