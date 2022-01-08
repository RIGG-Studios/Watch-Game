using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : EventBase
{
    [Range(0, 10)] private float timeSpeed = 1f;

    CanvasManager canvas;
    float currentTime;
    bool countTime = true;

    UIElementGroup gameTime;

    private void Start()
    {
        canvas = FindObjectOfType<CanvasManager>();
    }

    private void Update()
    {
        if (countTime)
        {
            currentTime += Time.deltaTime;

            int min = Mathf.FloorToInt(currentTime / 60);
            int sec = Mathf.FloorToInt(currentTime % 60);

            if (gameTime == null)
                gameTime = canvas.FindElementGroupByID("GameGroup");

            gameTime.FindElement("gametimer").OverrideValue(min.ToString("00") + ":" + sec.ToString("00"));
        }
    }

    public void ResetTime(float currentTime) => this.currentTime = currentTime;
}
