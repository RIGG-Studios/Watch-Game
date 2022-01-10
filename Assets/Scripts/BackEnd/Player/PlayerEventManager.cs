using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : EventBase
{
    CanvasManager canvas;
    PlayerManager player;

    private void Start()
    {
        canvas = FindObjectOfType<CanvasManager>();
        player = GetComponent<PlayerManager>();
    }

    public override void WatchBuildEndCallback()
    {
        player.playerWatches += 1;
        canvas.FindElementGroupByID("GameGroup").FindElement("watchesitemquantity").OverrideValue("x" + player.playerWatches);
    }

    public override void WatchBuildStartCallback(WatchTypes type) => player.ResetWatch();
}
