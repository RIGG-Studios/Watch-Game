using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWatchManager : MonoBehaviour
{
    public GameObject watchPrefab;
    public List<WatchProperties> watches = new List<WatchProperties>();

    public GameObject watchEndPart;

    private GameObject currentWatch;

    public WatchProperties GetRandomWatch()
    {
        return watches[Random.Range(0, watches.Count)];
    }

    public WatchProperties GetRandomWatchFromType(WatchTypes type)
    {
        List<WatchProperties> w = new List<WatchProperties>();

        foreach (WatchProperties wat in watches)
        {
            if (wat.watchType == type)
                w.Add(wat);
        }

        return w[Random.Range(0, w.Count)];
    }

    public GameObject CreateNewWatch(WatchTypes type)
    {
        Transform parentTo = null;
        List<GameObject> alreadyUsedLayers = new List<GameObject>();

        if(currentWatch != null)
        {
            Destroy(currentWatch);
        }

        currentWatch = Instantiate(watchPrefab, transform.parent);

        GameObject watchTemplate = GetRandomWatchFromType(type).template;

        for (int i = 0; i < Random.Range(watchTemplate.transform.childCount, watchTemplate.transform.childCount); i++)
        {
            List<GameObject> objectList = new List<GameObject>();

            if (currentWatch.GetComponentInChildren<IWatch>() == null)
            {
                parentTo = currentWatch.transform;
            }

            for (int v = 0; v < watchTemplate.transform.childCount; v++)
            {
                if (watchTemplate.transform.GetChild(v).GetComponent<IWatch>() != null)
                {
                    objectList.Add(watchTemplate.transform.GetChild(v).gameObject);

                    for(int j = 0; j < alreadyUsedLayers.Count; j++)
                    {
                        objectList.Remove(alreadyUsedLayers[j]);
                    }
                }
            }

            int randomRange = Random.Range(0, objectList.Count);

            GameObject layer = Instantiate(objectList[randomRange], parentTo);
            alreadyUsedLayers.Add(objectList[randomRange]);
            
            if(i == 0)
            {
                layer.transform.position -= new Vector3(0, 0, i);
            }
            else
            {
                layer.transform.position = new Vector3(0, 0, layer.transform.position.z - i);
            }

            layer.name = i.ToString();
            layer.SetActive(true);

            parentTo = layer.transform;
        }

        Instantiate(watchEndPart, parentTo);

        return currentWatch != null ? currentWatch : null;
    }
}
