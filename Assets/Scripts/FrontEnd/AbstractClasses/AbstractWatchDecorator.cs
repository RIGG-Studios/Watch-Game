using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

//This decorator handles insertion and returning a dictionary of all components in the watch
public abstract class AbstractWatchDecorator : MonoBehaviour, IWatch
{
    //Child watch part to delegate down to and inserting logic to know what to do when the player inserts something
    protected IWatch childWatchPart;
    protected IInsertable insertLogic;

    //Missing part is used to check if the part the player is trying to insert is the part relevant to this layer
    //Destinations denotes which destinations this missing part will be accepted into
    public GameObject missingPart;
    public List<Transform> destinations;

    //Component name is used solely in the GetAllComponentsLeft() as a unique key to identify this part by
    public string componentName;

    //Tracks how many destinations the player has inserted a missingPart into
    protected int filledDestinations;

    public void Awake()
    {
        //Setting some variables
        childWatchPart = transform.GetChild(0).GetComponent<IWatch>();
        insertLogic = GetComponent<IInsertable>();
    }

    //Recursive function, returns a dictionary containing the names of all of the parts on the watch and how many unfilled destinations they all have
    public virtual Dictionary<string, int> GetAllComponentsLeft(Dictionary<string, int> suppliedDictionary)
    {
        //Declaring a new dictionary just to avoid duplicate code later on
        Dictionary<string, int> currentDictionary;

        //If the class calling this method didn't supply a dictionary
        if (suppliedDictionary == null)
        {
            //Creates a new dictionary and sets currentDictionary to it
            Dictionary<string, int> newDictionary = new Dictionary<string, int>();
            currentDictionary = newDictionary;
        }
        else
        {
            //Else sets current dictionary to the supplied dictionary
            currentDictionary = suppliedDictionary;
        }

        //Adds the component name of this part and how amny unfilled destinations it has to the dictionary
        currentDictionary.Add(componentName, destinations.Count - filledDestinations);

        //Calls this exact same method on the childWatchPart, passing in the currentDictionary, setting up the recursion
        childWatchPart.GetAllComponentsLeft(currentDictionary);

        //Returns currentDictionary when done
        return currentDictionary;
    }

    //Insert method, handles inserting behaviour
    public virtual void Insert(GameObject insertObject, Transform destination)
    {
        //If the object trying to be inserted is the missingPart and the destination is valid
        if(insertObject == missingPart && DestinationExists(destination))
        {
            //Then delegate to insertLogic and increment filledDestinations
            insertLogic.Execute(insertObject, destination);
            filledDestinations++;
        }
        else
        {
            //Else delegate down to the childWatchPart
            childWatchPart.Insert(insertObject, destination);
        }
    }

    //Checks if the destination the player has provided is relevant to this layer
    public bool DestinationExists(Transform destination)
    {
        //bool declaration and instantiation
        bool canInsert = false;

        //If the destination the player provided is in the list of destinations
        for (int i = 0; i < destinations.Count; i++)
        {
            if (destinations[i] == destination)
            {
                //Then breaks and sets canInsert to true
                canInsert = true;
                break;
            }
        }

        //Returns canInsert
        return canInsert;
    }
}
