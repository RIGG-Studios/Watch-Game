using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class handles our slot managing, slots are the UI you see and must be interacted with uniquely
public class SlotManager : MonoBehaviour
{  
    public GameObject slot;
    public Transform slotGrid;

    private List<Slot> slots = new List<Slot>();

    //when we intiailize the inventory, also initialize the slots with the size
    public void InitializeSlots(int size, Item[] item = null)
    {
        //loop through the size of the inventory
        for (int i = 0; i < size; i++)
        {
            //for every iteration, create a slot and assign its parent as the transform which has a 
            //grid layout on it.
            GameObject slot = Instantiate(this.slot, slotGrid);

            //set the position, scale, and rotation to zero incase there are any mishaps in the vectors/rotations
            slot.transform.localPosition = Vector3.zero;
            slot.transform.localScale = Vector3.one;
            slot.transform.localRotation = Quaternion.identity;

            if (item != null)
                slot.GetComponent<Slot>().SetupSlot(item[i]);

            //finally add it to our slot list.
            slots.Add(slot.GetComponent<Slot>());
        }
    }

    //when we add an item, we need to add it to our slot, but also update the other slots
    //we also need a reference to our inventory list, which is sent through an array
    public void AddItemToSlot(Item item)
    {
        //loop through all the slots
        for(int i = 0; i < slots.Count; i++)
        {
            //we need to find a slot that has NO item attached to it
            if (!slots[i].occupied)
            {
                //found our slot
                slots[i].SetupSlot(item);
                break; //break away because we dont need to continue searching
            }
        }
    }


    //when we remove items, we need to do it differently
    public void RemoveItemFromSlot(Item item)
    {
        //find the slot which has the item we are trying to remove
        Slot slot = FindSlotFromItem(item);

        //deselect the slot
        if (slot != null)
            slot.DeselectSlot();
    }

    public void RemoveSlot(Item item)
    {
        Slot slotToRemove = FindSlotFromItem(item);

        //deselect the slot
        if (slotToRemove != null)
        {
            slots.Remove(slotToRemove);
            Destroy(slotToRemove);
        }    
    }

    private Slot FindSlotFromItem(Item item)
    {
        //loop DOWN the slots list, so we can find the latest item in the inventory
        for (int i = slots.Count - 1; i >= 0; i--)
        {
            //if the item we have as a parameter is equal to any of the slots item, we found the slot          
            if (slots[i].GetItem() == item)
                return slots[i];
        }

        //if we didnt find any slot, return null.
        return null;
    }
}
