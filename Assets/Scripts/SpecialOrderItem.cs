using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//This class is used to showcase the items required for the special watch/order
//neaty in UI
public class SpecialOrderItem : MonoBehaviour
{

    //reference to the amount text element
    public Text itemAmountText;

    //reference to the sprite image elemnent
    public Image itemSpriteImage;

    //method for assigning the sprite and text elements value to the required component
    public void Setup(ComponentRequirement componentRequirement)
    {
        itemSpriteImage.sprite = componentRequirement.itemRequirement.itemSprite;
        itemAmountText.text = componentRequirement.itemAmount.ToString();
    }
}
