using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public abstract class AbstractWatchDecorator : MonoBehaviour, IWatch
{
    protected IWatch childWatchPart;
    protected IInsertable insertLogic;

    public GameObject missingPart;
    public List<Transform> destinations;

    public string componentName;

    protected int filledDestinations;

    public void Awake()
    {
        childWatchPart = transform.GetChild(0).GetComponent<IWatch>();
        insertLogic = GetComponent<IInsertable>();
    }

    public virtual Dictionary<string, int> GetAllComponentsLeft(Dictionary<string, int> suppliedDictionary)
    {
        Dictionary<string, int> currentDictionary;

        if (suppliedDictionary == null)
        {
            Dictionary<string, int> newDictionary = new Dictionary<string, int>();
            currentDictionary = newDictionary;
        }
        else
        {
            currentDictionary = suppliedDictionary;
        }

        currentDictionary.Add(componentName, destinations.Count - filledDestinations);

        childWatchPart.GetAllComponentsLeft(currentDictionary);

        return currentDictionary;
    }

    public virtual void Insert(GameObject insertObject, Transform destination)
    {
        if(insertObject == missingPart && DestinationExists(destination))
        {
            insertLogic.Execute(insertObject, destination);
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
