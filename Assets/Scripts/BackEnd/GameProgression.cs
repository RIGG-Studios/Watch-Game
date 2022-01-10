using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : EventBase
{
    private void Start()
    {
        GameManager.SceneLoadEvent.Invoke();
    }

    public override void GameLoadCallback()
    {
        Debug.Log("hi");
        GameManager.WatchBuildStartEvent.Invoke(WatchTypes.Normal);
    }
}
