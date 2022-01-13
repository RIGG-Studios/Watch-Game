using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//game states for in game, not sure if states will be necessary when we have events, for now they do nothing
public enum GameStates
{
    PreGame,
    InGame,
    EndGame
}
//list of events for the game
public enum GameEvents
{
    SceneLoad,
    GameLoad,
    WatchBuildStart,
    WatchBuildEnd,
    WatchLayerComplete,
    SceneLeave,
}

public enum WatchTypes
{
    Normal,
    Special
}

public class GameManager : MonoBehaviour
{
    
    //first time in scene event, show staring hud, showcase scene, essentially have a cool transition
    //from the scene load
    public delegate void LoadedSceneDelegate();
    public static LoadedSceneDelegate SceneLoadEvent;

    public delegate void LoadedGameDelegate();
    public static LoadedGameDelegate GameLoadEvent;

    public delegate void WatchBuildStartDelegate(WatchTypes type);
    public static WatchBuildStartDelegate WatchBuildStartEvent;

    public delegate void WatchBuildEndDelegate(WatchProperties watchProperties, bool won);
    public static WatchBuildEndDelegate WatchBuildEndEvent;

    public delegate void WatchBuildLayerDelegate(string layerName);
    public static WatchBuildLayerDelegate WatchBuildLayerCompleteEvent;

    //leave scene to main menu/enable fadeaway hud
    public delegate void LeavingSceneDelegate();
    public static LeavingSceneDelegate SceneLeaveEvent;


    //gameState for places to access, but can't modify
    public GameStates gameState { get; private set; }

    //this method should be called whenever the game wants to call a new event, more events should be implented but 4 will provide a good prototype for us.

    //method for setting our game state
    public void SetGameState(GameStates gameState)
    {
        //check if our state is already set to the one we want to set it to, if so return because there is no point.
        if (this.gameState == gameState)
            return;

        //assign the game state to the next state.
        this.gameState = gameState;
    }

    public void StartGame() => GameLoadEvent.Invoke();

    public void StartWatchBuild()
    {
        WatchTypes type = WatchTypes.Special;

        WatchBuildStartEvent.Invoke(type);
    }
}
