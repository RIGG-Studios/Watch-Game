using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IWatch
{
    public Dictionary<string, int> GetAllComponentsLeft(Dictionary<string, int> dictionary);

    public void Insert(GameObject part, Transform destination);
}
