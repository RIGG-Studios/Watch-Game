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

    public void StartGame()
    {
        GameManager.GameLoadEvent.Invoke();
    }

    public override void GameLoadCallback()
    {
        GameManager.WatchBuildStartEvent.Invoke(WatchTypes.Normal);
    }
}
