using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractWatchDecorator : MonoBehaviour, IWatch
{
    protected IWatch childWatchPart;
    protected IInsertable insertLogic;

    public Transform missingPart;
    public List<Transform> destinations;

    public string componentName;

    protected int filledDestinations;

    public void Awake()
    {
        childWatchPart = transform.GetChild(0).GetComponent<IWatch>();
        insertLogic = GetComponent<IInsertable>();
    }

    public virtual Dictionary<string, int> GetAllComponentsLeft(Dictionary<string, int> dictionary)
    {
        throw new System.NotImplementedException();
    }

    public virtual void Insert(Transform insertObject, Transform destination)
    {
        if(insertObject == missingPart && DestinationExists(destination))
        {
            insertLogic.Insert(insertObject, destination);
            filledDestinations++;
        }
        else
        {
            childWatchPart.Insert(insertObject, destination);
        }
    }

    public bool DestinationExists(Transform destination)
    {
        bool canInsert = false;

        for (int i = 0; i < destinations.Count; i++)
        {
            if (destinations[i] == destination)
            {
                canInsert = true;
                break;
            }
        }

        return canInsert;
    }
}
