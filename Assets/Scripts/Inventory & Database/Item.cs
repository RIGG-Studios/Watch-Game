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

    [Header("Item Properties")]
    //build speed for the watch, more of an example variable
    public float watchBuildSpeed;
    //how many watches are we gonna build per interval?
    public int watchBuildStations;

    //constructor for the item with only arguement for the base item properties
    //useful for initializing basic items with minimal item properties.
    public Item(string itemName, string itemDescription, Sprite itemSprite)
    {
        //assign the item name, description, sprite to the arguements
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemSprite = itemSprite;

        //assign the speed and stations to their default value
        watchBuildSpeed = 1;
        watchBuildStations = 1;
    }

    //constructor for the item with arguements for every variable
    public Item(string itemName, string itemDescription, Sprite itemSprite, float watchBuildSpeed, int watchBuildStations)
    {
        //assign the variables with all the arguemengts
        this.itemName = itemName;
        this.itemDescription = itemDescription;
        this.itemSprite = itemSprite;

        this.watchBuildSpeed = watchBuildSpeed;
        this.watchBuildStations = watchBuildStations;
    }
}
