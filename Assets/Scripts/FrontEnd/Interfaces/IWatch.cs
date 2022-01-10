using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface that denotes if something is a watch
public interface IWatch
{
    //Get all components method that returns a dictionary of all the parts left to build in the watch
    public Dictionary<string, int> GetAllComponentsLeft(Dictionary<string, int> dictionary);

    //Insert method, will likely map 1:1 with an IInsertable's Execute() method, but might do checks before
    public void Insert(GameObject part, Transform destination);

    public GameObject GetGameObject();
}
