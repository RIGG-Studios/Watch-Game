using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Default inserting behaviour, just positions the object if it is valid
public class DefaultInserting : MonoBehaviour, IInsertable
{
    //Missing part field
    public GameObject missingPart;

    //Supplying the method with the missing part
    public GameObject GetMissingPart() => missingPart;

    //Transforming the insertObject to this object's position if it is the missing part
    public void Insert(Transform insertObject)
    {
        if(insertObject.gameObject == missingPart)
        {
            insertObject.position = transform.position;
            Debug.Log("Inserted successfully UwU");
        }
    }
}
