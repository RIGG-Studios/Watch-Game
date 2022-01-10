using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWatchManager : MonoBehaviour
{
    public GameObject watchPrefab;

    private GameObject currentWatch;


    public GameObject CreateNewWatch()
    {
        if(currentWatch != null)
        {
            Destroy(currentWatch);
        }

        currentWatch = Instantiate(watchPrefab, transform.parent);

        return currentWatch != null ? currentWatch : null;
    }
}
