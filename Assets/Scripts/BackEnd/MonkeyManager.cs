using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonkeyManager : MonoBehaviour
{
    public Transform monkeyParent;
    public GameObject monkeyPrefab;

    public void SpawnMonkey()
    {
        GameObject monkey = Instantiate(monkeyPrefab, monkeyParent);

        monkey.transform.position = new Vector3(Random.Range(-3f, 3f), Random.Range(7, 10), 0);
    }
}
