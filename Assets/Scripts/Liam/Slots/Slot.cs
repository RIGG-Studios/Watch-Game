using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    public Item item;
    //slots have an image for the item sprite, and a corresponding item
    public bool occupied { get; private set; }

    public Image imageSprite;
    public Text cost;
    public Text name;
    public Text quantity;


    //method for setting up the slots
    public void SetupSlot(Item item, int amount)
    {
       if(imageSprite) imageSprite.enabled = true;
       if(quantity) quantity.enabled = true;
        imageSprite.sprite = item.itemSprite;

        if (cost != null)
            cost.text = item.itemCost.ToString() + " Watches";

        if (name != null)
            name.text = item.itemName;

        if(amount > 0)
            SetQuantity("x" + amount);

        this.item = item;
        occupied = true;
    }


    public void SetQuantity(string text) => quantity.text = text;

    //method for deselecting our slots
    public void DeselectSlot()
    {
        if (imageSprite) imageSprite.enabled = false;
        if (quantity) quantity.enabled = false;
        imageSprite.sprite = null;
        SetQuantity(null);
        item = null;
        occupied = false;
    }

    public void ShowcaseItem()
    {
        ShopManager shop = FindObjectOfType<ShopManager>();

        if (shop)
            shop.ShowcaseItem(item);
    }

    //get item is just our item variable up above.
    public Item GetItem() => item;
}