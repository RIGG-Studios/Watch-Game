using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : EventBase
{
    CanvasManager canvas;
    PlayerManager player;

    UIElement watchesItemText;
    UIElement gameTimer;

    private void Start()
    {
        canvas = FindObjectOfType<CanvasManager>();
        player = GetComponent<PlayerManager>();

        if (canvas != null)
        {
            watchesItemText = canvas.FindElementGroupByID("GameGroup").FindElement("watchcounttext");
            gameTimer = canvas.FindElementGroupByID("GameGroup").FindElement("gametimer");
        }
    }

    public override void WatchBuildEndCallback()
    {
        for(int i = 0; i < player.monkeys.Count; i++)
        {
            player.playerWatches++;
        }

        player.playerWatches += 1;

        watchesItemText.OverrideValue("x" + player.playerWatches);
        canvas.FindElementGroupByID("GameGroup").FindElement("gametimer").FadeElement(0, 0.25f);
    }

    public override void GameLoadCallback()
    {
        player.ResetWatch(WatchTypes.Normal);
    }

    public override void WatchBuildStartCallback(WatchTypes type)
    {
        player.ResetWatch(type);
    }
}
