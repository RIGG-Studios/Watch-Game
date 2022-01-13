using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTime : MonoBehaviour
{
    public Gradient timeTextGradient;
    [Range(0, 10)] public float timeSpeed = 1f;
    [Range(0, 500)] public float startMinute;
    
    float currentTime;

    bool countTime = false;
    bool playedPulseAnim;

    UIElementGroup gameTime;
    UIElement gameTimerElement;

    CanvasManager canvas;
    PlayerWatchManager watchManager;

    private void Start()
    {
        currentTime = startMinute * 60;
        canvas = FindObjectOfType<CanvasManager>();
        watchManager = FindObjectOfType<PlayerWatchManager>();

        gameTime = canvas.FindElementGroupByID("GameGroup");
        gameTimerElement = gameTime.FindElement("gametimer");
    }

    private void Update()
    {
        if (countTime && watchManager.currentWatchProperties.watchType == WatchTypes.Special)
        {
            currentTime -= Time.deltaTime;

            int min = Mathf.FloorToInt(currentTime / 60);
            int sec = Mathf.FloorToInt(currentTime % 60);

            gameTimerElement.OverrideValue(min.ToString("00") + ":" + sec.ToString("00"));

            if (currentTime < 15)
            {
                gameTimerElement.OverrideColor(timeTextGradient.Evaluate(currentTime / 15f));
            }

            if (currentTime < 10)
            {
                if (!playedPulseAnim)
                {
                    gameTimerElement.PlayAnimation("pulse");
                    playedPulseAnim = true;
                }
            }

            if (currentTime <= 0)
            {
                gameTimerElement.OverrideValue("00:00");
                gameTimerElement.FadeElement(0, 0.25f);
                GameManager.WatchBuildEndEvent.Invoke(watchManager.currentWatchProperties, false);
                countTime = false;
            }
        }

    }

    public void SetupTimer(float time)
    {
        gameTimerElement.FadeElement(1, 0.25f);
        currentTime = time;
        countTime = true;
    }
}
