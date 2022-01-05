using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RejectInsertion : MonoBehaviour, IInsertable
{
    public void Insert(Transform insertObject, Transform destination)
    {
        Debug.Log("The onject you're trying to insert doesn't fit in the destination UmU");
    }
}
