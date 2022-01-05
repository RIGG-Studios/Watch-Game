using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatchEndPart : MonoBehaviour, IWatch
{
    IInsertable insertingLogic;

    private void Start()
    {
        insertingLogic = GetComponent<IInsertable>();
    }

    public Dictionary<string, int> GetAllComponentsLeft(Dictionary<string, int> dictionary)
    {
        return null;
    }

    public void Insert(Transform insertObject, Transform destination)
    {
        insertingLogic.Insert(insertObject, destination);
    }
}
