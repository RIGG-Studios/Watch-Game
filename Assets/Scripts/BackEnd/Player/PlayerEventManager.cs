using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEventManager : EventBase
{
    CanvasManager canvas;
    PlayerManager player;

    UIElement watchesItemText;
    UIElement layerText;

    private void Start()
    {
        canvas = FindObjectOfType<CanvasManager>();
        player = GetComponent<PlayerManager>();

        if (canvas != null)
        {
            watchesItemText = canvas.FindElementGroupByID("GameGroup").FindElement("watchesitemquantity");
            layerText = canvas.FindElementGroupByID("GameGroup").FindElement("watchbuilderstate");
        }
    }

    public override void WatchBuildEndCallback()
    {
        player.playerWatches += 1;
        watchesItemText.OverrideValue("x" + player.playerWatches);
    }

    public override void LayerCompleteCallback(string layerName)
    {
        layerText.FadeElement(1, 0);
        layerText.OverrideValue(string.Format("{0} COMPLETED", layerName));
    }

    public override void WatchBuildStartCallback(WatchTypes type)
    {
        player.ResetWatch(type);
    }
}
