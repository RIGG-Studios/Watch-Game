using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : EventBase
{
    CanvasManager canvas;
    PlayerManager player;
    PlayerWatchManager playerWatchManager;

    UIElement watchesItemText;

    private void Start()
    {
        canvas = FindObjectOfType<CanvasManager>();
        player = FindObjectOfType<PlayerManager>();
        playerWatchManager = GetComponent<PlayerWatchManager>();

        if (canvas != null)
        {
            watchesItemText = canvas.FindElementGroupByID("GameGroup").FindElement("watchcounttext");
        }
    }

    public override void WatchBuildEndCallback(WatchProperties watchProperties, bool won)
    {
        if(won)
            player.playerWatches += watchProperties.watchReward;

        watchesItemText.OverrideValue("x" + player.playerWatches);
        canvas.FindElementGroupByID("GameGroup").FindElement("gametimer").FadeElement(0, 0.25f);
    }

    public override void GameLoadCallback()
    {
        playerWatchManager.ResetWatch(WatchTypes.Normal);
    }

    public override void WatchBuildStartCallback(WatchTypes type)
    {
        playerWatchManager.ResetWatch(type);
    }
}