using UnityEngine.UI;
using UnityEngine;

public class Slot : MonoBehaviour
{
    //slots have an image for the item sprite, and a corresponding item
    public bool occupied => item != null;

    public Image imageSprite;

    private Item item;

    //method for setting up the slots
    public void SetupSlot(Item item)
    {
        this.item = item;
        imageSprite.sprite = item.itemSprite;
    }

    //method for deselecting our slots
    public void DeselectSlot()
    {
        item = null;
        imageSprite.sprite = null;
    }

    //get item is just our item variable up above.
    public Item GetItem() => item;
}
