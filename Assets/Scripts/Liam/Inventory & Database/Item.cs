using UnityEngine;

//create a scriptable object with the create asset menu implentation.
[CreateAssetMenu(fileName = "New Item", menuName = "New Item", order = 0)]
public class Item : ScriptableObject
{
    [Header("Base Item Properties")]
    //item name
    public string itemName;
    [TextArea]// text area so the area in the inspector looks nice and big, for the description of the item
    public string itemDescription;
    //cost of the item
    public int itemCost;
    //sprite of the item, will show up in the UI store, etc...
    public Sprite itemSprite;
    //let us know if we can equip the item, for example a tool such as a screwdriver or tweezers
    public bool equippable;
    //item this item is required to have
    public Item dependentItem;


    //constructor for the item with only arguement for the base item properties
    //useful for initializing basic items with minimal item properties.
    public Item(string itemName, string itemDescription, Sprite itemSprite, bool equippable)
    {
        //assign the item name, description, sprite to the arguements
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemSprite = itemSprite;
        this.equippable = equippable;
    }
}
