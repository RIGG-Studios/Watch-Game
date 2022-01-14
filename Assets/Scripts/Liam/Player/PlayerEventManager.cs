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

            watchesItemText.OverrideValue(player.playerWatches.ToString());
        }
    }

    public override void WatchBuildEndCallback(WatchProperties watchProperties, bool won)
    {
        Debug.Log(won);
        if (won)
        {
            Debug.Log("won");
            for(int i = 0; i < player.playerMonkeys; i++)
                player.playerWatches += watchProperties.watchReward;
        }

        watchesItemText.OverrideValue(player.playerWatches.ToString());
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
