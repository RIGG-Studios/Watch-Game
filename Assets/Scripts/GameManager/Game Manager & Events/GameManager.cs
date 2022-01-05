using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//game states for in game, not sure if states will be necessary when we have events, for now they do nothing
public enum GameStates
{
    MainMenu,
    Loading,
    PreGame,
    InGame,
    EndGame
}
//list of events for the game
public enum GameEvents
{
    SceneLoad,
    StartGame,
    EndGame,
    SceneLeave
}

public class GameManager : MonoBehaviour
{
    //first time in scene event, show staring hud, showcase scene, essentially have a cool transition
    //from the scene load
    public delegate void LoadedSceneDelegate();
    public static LoadedSceneDelegate SceneLoadEvent;
    
    //start game event // show and hide ui, enable interactions / watch manager starts with the first layer
    //camera set accordinly, etc...
    public delegate void StartGameDelegate();
    public static StartGameDelegate StartGameEvent;

    //game end event // show or hide ui elements/disable player interactions/camera fov?, etc...
    public delegate void EndGameDelegate();
    public static EndGameDelegate EndGameEvent;

    //leave scene to main menu/enable fadeaway hud
    public delegate void LeavingSceneDelegate();
    public static LeavingSceneDelegate SceneLeaveEvent;

    public GameStates gameState { get; private set; }


    public void CallEvent(GameEvents type)
    {
        switch (type)
        {
            case GameEvents.SceneLoad:
                SceneLoadEvent.Invoke();
                break;

            case GameEvents.StartGame:
                StartGameEvent.Invoke();
                break;

            case GameEvents.EndGame:
                EndGameEvent.Invoke();
                break;

            case GameEvents.SceneLeave:
                SceneLeaveEvent.Invoke();
                break;
        }
    }

    public void SetGameState(GameStates gameState)
    {
        if (this.gameState == gameState)
            return;

        this.gameState = gameState;
    }
}
