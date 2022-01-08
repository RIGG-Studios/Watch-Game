using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameProgression : MonoBehaviour
{
    GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

        if (gameManager != null)
            gameManager.CallEvent(GameEvents.SceneLoad);
    }
}
