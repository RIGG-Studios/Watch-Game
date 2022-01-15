using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWatchManager : MonoBehaviour
{
    public GameObject watchPrefab;
    public GameObject watchEndPart;
    public GameObject watchTemplate;
    public List<WatchProperties> watches = new List<WatchProperties>();

    public WatchProperties queuedWatchProperties { get; private set; }
    public WatchProperties currentWatchProperties { get; private set; }
    private GameObject currentWatch;

    PlayerManager player;
    CanvasManager canvas;
    GameTime gameTime;
    SpecialOrdersManager specialOrderManager;

    UIElementGroup specialWatch;
    UIElement difficultyText;
    UIElement timeText;
    private PlayerInventory playerInventory
    {
        get
        {
            return FindObjectOfType<PlayerInventory>();
        }
    }
    private void Start()
    {
        player = FindObjectOfType<PlayerManager>();
        canvas = FindObjectOfType<CanvasManager>();
        gameTime = FindObjectOfType<GameTime>();
        specialOrderManager = FindObjectOfType<SpecialOrdersManager>();

        specialWatch = canvas.FindElementGroupByID("NewSpecialOrderGroup");

        difficultyText = specialWatch.FindElement("difficultytext");
        timeText = specialWatch.FindElement("timetext");
    }

    public void ResetWatch(WatchTypes type)
    {
        if (type == WatchTypes.Special)
        {
            queuedWatchProperties = GetRandomWatchFromType(WatchTypes.Special);
            gameTime.SetupTimer(queuedWatchProperties.timeToComplete);

            int min = Mathf.FloorToInt(queuedWatchProperties.timeToComplete / 60);
            int sec = Mathf.FloorToInt(queuedWatchProperties.timeToComplete % 60);

            timeText.OverrideValue("TIME: " + min.ToString("00") + ":" + sec.ToString("00"));
            difficultyText.OverrideValue("DIFFICULTY: " + System.Enum.GetName(typeof(WatchProperties.WatchDifficulty), queuedWatchProperties.watchDifficulty));

            specialOrderManager.AddComponentsToGrid(1);
            canvas.ShowElementGroup(specialWatch, false);
        }
        else
        {
            SpawnWatch(GetRandomWatchFromType(WatchTypes.Normal));
        }
    }

    public void SpawnWatch(WatchProperties properties)
    {
        if (properties.watchType == WatchTypes.Special)
        {
            if (!player.CanBuildWatch(queuedWatchProperties.requiredComponents.ToArray()))
                return;

            for (int i = 0; i < queuedWatchProperties.requiredComponents.Count; i++)
            {
                if (!queuedWatchProperties.requiredComponents[i].itemRequirement.equippable)
                {
                    playerInventory.RemoveItem(queuedWatchProperties.requiredComponents[i].itemRequirement, queuedWatchProperties.requiredComponents[i].itemAmount);
                }
            }
        }

        currentWatchProperties = properties;
        canvas.HideElementGroup(specialWatch);
        player.TransitionGamemode(true);

        //call the watch manager to create a new watch
        GameObject watchGameObject = CreateWatchGameObject(properties.watchType);

        player.UpdateGamemode(watchGameObject);
    }
    public GameObject CreateWatchGameObject(WatchTypes type, WatchProperties properties = null)
    {
        Transform parentTo = null;
        List<GameObject> alreadyUsedLayers = new List<GameObject>();

        if(currentWatch != null)
        {
            Destroy(currentWatch);
        }

        currentWatch = Instantiate(watchPrefab, transform.parent);

        for (int i = 0; i < Random.Range(2, watchTemplate.transform.childCount); i++)
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

}
