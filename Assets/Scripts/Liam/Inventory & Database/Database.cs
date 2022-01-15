using System.Collections.Generic;
using UnityEngine;

//scriptable object for this for quick and easy reference.
public class Database : MonoBehaviour
{
    //quick a list of items to exist in our database
    public static Item[] itemDatabase
    {
        get
        {
            Item[] foundItems = Resources.LoadAll<Item>("Items");

            return foundItems;
        }

    }

    //method for retreiving the list.`

    //have a method to find an item in the database, by the name of the item
    public static Item GetItem(string itemName)
    {
        //chedck if the name is null, and is so debug and return.
        if (itemName == null)        
        {
            Debug.Log("Item is null while trying to get item, try again.");
            return null;
        }
        
        
        //loop through all the items to find the item with the same name
        for(int i = 0; i < itemDatabase.Length; i++)
        {
            //if we find an item with the same name, return it
            if (itemName == itemDatabase[i].name)
                return itemDatabase[i];           
        }

        //otherwise return null
        return null;
    }

    //essentially the same method as above, but instead of returning an Item we return a bool 
    //incase we need to simply check if the item exists, instead of getting its properties.
    public static bool HasItem(string itemName)
    {
        Debug.Log(itemDatabase);
        if (itemName == null)
        {
            Debug.Log("Item is null while trying to see if item exists, try again.");
            return false;
        }

        for (int i = 0; i < itemDatabase.Length; i++)
        {
            if (itemDatabase[i] == null)
                return false;

            if (itemName == itemDatabase[i].name)
                return true;
        }

        return false;
    }

    //method for finding a random item in the database
    public static Item FindRandomItem()
    {
        if (itemDatabase.Length <= 0)
            return null;

        //return a item with a random index between 0 and the length of the list.
        return itemDatabase[Random.Range(0, itemDatabase.Length)];
    }
}
