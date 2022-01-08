using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //slots have an image for the item sprite, and a corresponding item
    public bool occupied => item != null;

    public Image imageSprite;

    public Text cost;
    public Text name;

    private Item item;

    //method for setting up the slots
    public void SetupSlot(Item item)
    {
        this.item = item;
        imageSprite.sprite = item.itemSprite;

        if (cost != null)
            cost.text = item.itemCost.ToString()+ " Watches";

        if (name != null)
            name.text = item.itemName;
    }

    //method for deselecting our slots
    public void DeselectSlot()
    {
        item = null;
        imageSprite.sprite = null;
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
