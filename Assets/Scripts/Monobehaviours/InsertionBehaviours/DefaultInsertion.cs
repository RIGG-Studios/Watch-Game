using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Default inserting behaviour, just positions the object if it is valid
public class DefaultInsertion : MonoBehaviour, IInsertable
{
    //Transforming the insertObject to this object's position if it is the missing part
    public void Insert(GameObject insertObject, Transform destination)
    {
        insertObject.transform.position = destination.position;

        Debug.Log("Inserted successfully UwU");
    }
}
