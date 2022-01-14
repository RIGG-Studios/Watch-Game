using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //slots have an image for the item sprite, and a corresponding item
    public bool occupied => item != null;

    public Image imageSprite;

    public Text cost;
    public Text name;
    public Text quantity;

    private Item item;

    //method for setting up the slots
    public void SetupSlot(Item item)
    {
       if(imageSprite) imageSprite.enabled = true;
       if(quantity) quantity.enabled = true;
        imageSprite.sprite = item.itemSprite;

        if (cost != null)
            cost.text = item.itemCost.ToString() + " Watches";

        if (name != null)
            name.text = item.itemName;


        this.item = item;
    }
    public void SetQuantity(string text) => quantity.text = text;

    //method for deselecting our slots
    public void DeselectSlot()
    {
        item = null;
        if (imageSprite) imageSprite.enabled = false;
        if (quantity) quantity.enabled = false;
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
