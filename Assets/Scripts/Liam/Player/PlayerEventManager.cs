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

            watchesItemText.OverrideValue(((int)player.playerWatches).ToString());
        }
    }

    public override void WatchBuildEndCallback(WatchProperties watchProperties, bool won)
    {
        if (won)
        {
            int reward = watchProperties.watchReward;

            if (player.playerMonkeys > 0)
                reward *= player.playerMonkeys;

            player.playerWatches += reward;
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
