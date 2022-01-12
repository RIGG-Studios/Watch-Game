using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : EventBase
{
    CanvasManager canvas;
    PlayerManager player;

    UIElement watchesItemText;

    private void Start()
    {
        canvas = FindObjectOfType<CanvasManager>();
        player = GetComponent<PlayerManager>();

        if (canvas != null)
        {
            watchesItemText = canvas.FindElementGroupByID("GameGroup").FindElement("watchcounttext");
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
    }

    public override void LayerCompleteCallback(string layerName)
    {
   //     layerText.FadeElement(1, 0);
      //  layerText.OverrideValue(string.Format("{0} COMPLETED", layerName));
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
