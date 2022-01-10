using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class DefaultWatchDecorator : EventBase, IWatch
{
    //Child watch part to delegate down to and inserting logic to know what to do when the player inserts something
    protected IWatch childWatchPart;
    protected IInsertable insertLogic;

    //Missing part is used to check if the part the player is trying to insert is the part relevant to this layer
    //Destinations denotes which destinations this missing part will be accepted into
    public GameObject missingPartPrefab;
    public List<GameObject> destinations;

    //Component name is used solely in the GetAllComponentsLeft() as a unique key to identify this part by
    public string componentName;

    //Tracks how many destinations the player has inserted a missingPart into
    protected int filledDestinations;

    List<GameObject> instantiatedParts;

    public void Start()
    {
        childWatchPart = transform.GetComponentsInChildren<IWatch>()[1];
        insertLogic = GetComponent<IInsertable>();
        instantiatedParts = new List<GameObject>();

        for (int i = 0; i < destinations.Count; i++)
        {
            GameObject watchPartClone = Instantiate(missingPartPrefab, transform.parent);
            watchPartClone.transform.position = new Vector2(Random.Range(-3f, -5f), Random.Range(-3, 3));
            watchPartClone.transform.GetChild(0).transform.localScale = destinations[i].transform.localScale;
            watchPartClone.name = missingPartPrefab.name;
            instantiatedParts.Add(watchPartClone);

            destinations[i].SetActive(true);
        }

        childWatchPart.GetGameObject().SetActive(false);
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
        //get the distance between the destination and the inserted object
        float dist = (insertObject.transform.position - destination.position).magnitude;

        //check if its higher than a very smaller than threshold, meaning its off place from where its supposed to be
        if (dist > 5.106f)
        {
            //for now, simply log that its happening and return the function
            Debug.Log("Part misplaced, restarting layer!");
            Debug.Log(dist);
            return;
        }

        //check if the scale of the inserted object is not equal to the destination, or if the pieces dont fit in size
        if (insertObject.transform.GetChild(0).transform.localScale != destination.localScale)
        {
            //for now, simply log that its happening and return the function
            Debug.Log("part doesn't fit in destination, restarting layer!");
            return;
        }

        //If the object trying to be inserted is the missingPart and the destination is valid
        if (insertObject.name == missingPartPrefab.name && DestinationExists(destination))
        {
            //Then delegate to insertLogic and increment filledDestinations
            insertLogic.Execute(insertObject, destination);
            filledDestinations++;

            //check if the layer is a gear layer, so we can animate it when we insert it
            if (componentName == "BigGears" || componentName == "MedGears")
            {
                //call the animator to set the trigger, very roughly, will need to be touched upon later
                insertObject.GetComponentInChildren<Animator>().SetTrigger("rotate");
                //disable the destination 
                //destination.GetComponent<SpriteRenderer>().enabled = false;
            }

            if (filledDestinations >= destinations.Count)
            {
                //check if the component is a medium gear
                //this section will probably need to be removed, I just wanted the game to be bugfree as of now (2:22am)
                //and am tired and want to see the animations work with smooth transitions

                //So yea, anything with animations/Gears and stuff may need to be touched upon when Bilal works on the randomized
                //preset watches. I just wanted to see it working for now - Liam :)
                //if (componentName == "MedGears")
                //{
                    //get the big gears watch on the parent since were on the medium gears layer
                    //DefaultWatchDecorator bigGearsWatch = transform.parent.GetComponent<DefaultWatchDecorator>();

                    //loop through its destinations
                    //for(int i =0; i < bigGearsWatch.destinations.Count; i++)
                    //{
                        //set the instiatiated parts to false
                        //bigGearsWatch.instantiatedParts[i].SetActive(false);
                    //}
                //}
                for (int i = 0; i < destinations.Count; i++)
                {
                    destinations[i].SetActive(false);

                    //if this is a gear layer, allow the gears to stay active
                    //if (componentName != "BigGears")
                        //instantiatedParts[i].SetActive(false);   
                }

                childWatchPart.GetGameObject().SetActive(true);
            }
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
            if (destinations[i] == destination.gameObject)
            {
                //Then breaks and sets canInsert to true
                canInsert = true;
                break;
            }
        }

        //Returns canInsert
        return canInsert;
    }

    public GameObject GetGameObject() => gameObject;
}