using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WatchProperties 
{
    public enum WatchDifficulty
    {
        Easy,
        Normal,
        Hard,
        Advanced,
        Master
    }

    public string watchName;

    public WatchTypes watchType;   

    public WatchDifficulty watchDifficulty;

    public int timeToComplete;

    public GameObject template;
}