using System.Collections.Generic;
using UnityEngine;

//scriptable object for this for quick and easy reference.
[CreateAssetMenu(fileName = "New Database", menuName = "Item Database", order = 1)]
public class Database : ScriptableObject
{
    //quick a list of items to exist in our database
    [SerializeField] private List<Item> items = new List<Item>();

    //method for retreiving the list.`
    public Item[] GetItems() => items.ToArray();


    //have a method to find an item in the database, by the name of the item
    public Item GetItem(string itemName)
    {
        //chedck if the name is null, and is so debug and return.
        if (itemName == null)        
        {
            Debug.Log("Item is null while trying to get item, try again.");
            return null;
        }
        
        
        //loop through all the items to find the item with the same name
        for(int i = 0; i < items.Count; i++)
        {
            //if an item is nul, return out so we dont get an error
            if (items[i] == null)
                return null;

            //if we find an item with the same name, return it
            if (itemName == items[i].name)
                return items[i];           
        }

        //otherwise return null
        return null;
    }

    //essentially the same method as above, but instead of returning an Item we return a bool 
    //incase we need to simply check if the item exists, instead of getting its properties.
    public bool HasItem(string itemName)
    {
        if (itemName == null)
        {
            Debug.Log("Item is null while trying to see if item exists, try again.");
            return false;
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
                return false;

            if (itemName == items[i].name)
                return true;
        }

        return false;
    }

    //method for finding a random item in the database
    public Item FindRandomItem()
    {
        if (items.Count <= 0)
            return null;

        //return a item with a random index between 0 and the length of the list.
        return items[Random.Range(0, items.Count)];
    }
}
