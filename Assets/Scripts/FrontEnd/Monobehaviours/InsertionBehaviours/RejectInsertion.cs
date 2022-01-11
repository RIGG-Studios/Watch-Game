using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Another insertion behaviour, used only for the WatchEndPart
public class RejectInsertion : MonoBehaviour, IInsertable
{
    //Does nothing, rejects the input
    public void Execute(GameObject insertObject, Transform destination)
    {
        Debug.Log("The object you're trying to insert doesn't fit in the destination UmU");
    }

    public bool HasObject() => false;
}
