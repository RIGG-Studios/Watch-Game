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
    StartGame,
    EndGame,
    SceneLeave,
}

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get { return FindObjectOfType<GameManager>(); } }
    //first time in scene event, show staring hud, showcase scene, essentially have a cool transition
    //from the scene load
    public delegate void LoadedSceneDelegate();
    public LoadedSceneDelegate SceneLoadEvent;
    
    //start game event // show and hide ui, enable interactions / watch manager starts with the first layer
    //camera set accordinly, etc...
    public delegate void StartGameDelegate();
    public StartGameDelegate StartGameEvent;

    //game end event // show or hide ui elements/disable player interactions/camera fov?, etc...
    public delegate void EndGameDelegate();
    public EndGameDelegate EndGameEvent;

    //leave scene to main menu/enable fadeaway hud
    public delegate void LeavingSceneDelegate();
    public LeavingSceneDelegate SceneLeaveEvent;


    //gameState for places to access, but can't modify
    public GameStates gameState { get; private set; }

    //this method should be called whenever the game wants to call a new event, more events should be implented but 4 will provide a good prototype for us.
    public void CallEvent(GameEvents type)
    {
        //simply switch the type, getting the type and invoking the correct event
        switch (type)
        {
            case GameEvents.SceneLoad:
                SceneLoadEvent.Invoke();
                SetGameState(GameStates.PreGame);
                break;

            case GameEvents.StartGame:
                StartGameEvent.Invoke();
                SetGameState(GameStates.InGame);
                break;

            case GameEvents.EndGame:
                EndGameEvent.Invoke();
                SetGameState(GameStates.EndGame);
                break;

            case GameEvents.SceneLeave:
                SceneLeaveEvent.Invoke();
                break;
        }
    }

    //method for setting our game state
    public void SetGameState(GameStates gameState)
    {
        //check if our state is already set to the one we want to set it to, if so return because there is no point.
        if (this.gameState == gameState)
            return;

        //assign the game state to the next state.
        this.gameState = gameState;
    }

    public void StartGame() => CallEvent(GameEvents.StartGame);
}
