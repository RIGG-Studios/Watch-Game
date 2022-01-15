using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//list of events for the game
public enum GameEvents
{
    SceneLoad,
    GameLoad,
    WatchBuildStart,
    WatchBuildEnd,
    WatchBuildNewLayer,
    WatchLayerComplete,
    WatchObjectInsert,
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

    public delegate void WatchBuildInsertDelegate();
    public static WatchBuildInsertDelegate WatchObjectInsertEvent;

    public delegate void WatchBuildNewLayer();
    public static WatchBuildNewLayer WatchBuildNewLayerEvent;

    public delegate void WatchBuildLayerDelegate(string layerName);
    public static WatchBuildLayerDelegate WatchBuildLayerCompleteEvent;

    public delegate void LeavingSceneDelegate();
    public static LeavingSceneDelegate SceneLeaveEvent;

    //methods for starting events through buttons
    public void StartWatchBuild()
    {
        WatchTypes type = WatchTypes.Special;

        WatchBuildStartEvent.Invoke(type);
    }

    public void RestartGame()
    {
        PlayerSaving.ResetPlayerPrefs();
        SceneManager.ReloadScene();
    }

    public void ExitGame() => Application.Quit();

    public void StartGame() => GameLoadEvent.Invoke();
}
