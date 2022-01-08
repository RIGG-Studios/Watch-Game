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

    public override void EndGameCallback()
    {
        player.playerWatches += 1;
        canvas.FindElementGroupByID("GameGroup").FindElement("watchescounttext").OverrideValue(string.Format("{0} WATCHES BUILT", player.playerWatches));
    }
}
