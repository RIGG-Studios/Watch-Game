using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
public class DefaultWatchDecorator : EventBase, IWatch
{
    //Child watch part to delegate down to and inserting logic to know what to do when the player inserts something
    protected IWatch childWatchPart;
    protected IInsertable insertLogic;
    public float moveDuration = 4f;

    //Missing part is used to check if the part the player is trying to insert is the part relevant to this layer
    //Destinations denotes which destinations this missing part will be accepted into
    public GameObject missingPartPrefab;
    public List<DefaultInsertion> destinations = new List<DefaultInsertion>();

    //Component name is used solely in the GetAllComponentsLeft() as a unique key to identify this part by
    public string componentName;

    //Tracks how many destinations the player has inserted a missingPart into
    protected int filledDestinations;

    List<GameObject> instantiatedParts = new List<GameObject>();

    private void Start()
    {
        //When a new layer is activated, we will send an event to the game manager
        GameManager.WatchBuildNewLayerEvent.Invoke();

        childWatchPart = transform.GetComponentsInChildren<IWatch>()[1];
        insertLogic = GetComponent<IInsertable>();
        childWatchPart.GetGameObject().SetActive(false);
        StartCoroutine(MoveToRestingPosition());
    }

    private IEnumerator MoveToRestingPosition()
    {
        yield return new WaitForSeconds(3.5f);

        float t = 0;

        while (t < 1)
        {
            t += Time.deltaTime;

            for (int i = 0; i < destinations.Count; i++)
            {
                if (destinations[i].GetComponent<DoNotHide>() == null)
                {
                    destinations[i].transform.position = Vector3.Lerp(destinations[i].transform.position, destinations[i].restingPosition, t / moveDuration);
                }
            }

            yield return null;
        }

        SpawnMissingParts();
    }

    private void SpawnMissingParts()
    {
        for (int i = 0; i < destinations.Count; i++)
        {
            destinations[i].transform.position = destinations[i].originalPos;
            if (destinations[i].GetComponent<DoNotHide>() == null) 
            {
                destinations[i].GetComponent<SpriteRenderer>().enabled = false;
            }

            GameObject watchPartClone = Instantiate(destinations[i].missingPiece, transform.parent);
            watchPartClone.transform.position = destinations[i].restingPosition + new Vector3(0, 0, -3);
            watchPartClone.transform.GetChild(0).transform.localScale = destinations[i].transform.localScale;
            watchPartClone.name = destinations[i].missingPiece.name;
            instantiatedParts.Add(watchPartClone);

            destinations[i].gameObject.SetActive(true);
        }
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
        float dist = (destination.position - insertObject.transform.position).magnitude;

        //check if its higher than a very smaller than threshold, meaning its off place from where its supposed to be
        if (dist > 5.106f)
        {
            //for now, simply log that its happening and return the function
            Debug.Log("Part misplaced, restarting layer!");
     //       return;
        }

        //check if the scale of the inserted object is not equal to the destination, or if the pieces dont fit in size
        if (insertObject.transform.GetChild(0).transform.localScale != destination.localScale)
        {
            //for now, simply log that its happening and return the function
            Debug.Log("part doesn't fit in destination, restarting layer!");
            return;
        }

        //If the object trying to be inserted is the missingPart and the destination is valid
        if (insertObject.name == destination.GetComponent<DefaultInsertion>().missingPiece.name && DestinationExists(destination))
        {
            //Then delegate to insertLogic and increment filledDestinations
            insertLogic.Execute(insertObject, destination);
            //when a object is succesfully inserted, we will send an event to the game manager
            GameManager.WatchObjectInsertEvent.Invoke();
            filledDestinations++;

            //check if the layer has do not hide, if not hide it
            if (destination.GetComponent<DoNotHide>() == null)
            {
                //disable the destination 
                destination.GetComponent<SpriteRenderer>().enabled = false;
            }


            if (filledDestinations >= destinations.Count)
            {
                for (int i = 0; i < destinations.Count; i++)
                {
                    destinations[i].gameObject.SetActive(false);
                }

                GameManager.WatchBuildLayerCompleteEvent.Invoke(componentName);

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
            if (destinations[i].transform == destination)
            {
                //Then breaks and sets canInsert to true
                canInsert = true;
                break;
            }
        }

        //Returns canInsert
        return canInsert;
    }

    public void HideAllObjects()
    {
        for(int i = 0; i < instantiatedParts.Count; i++)
        {
            instantiatedParts[i].gameObject.SetActive(false);
        }
    }
    public GameObject GetGameObject() => gameObject;
}