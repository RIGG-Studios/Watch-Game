using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is meant to put our event inteface into other classes, we had to to
//a base class because we can add and remove it based on if the object is enabled/disabled, and we dont wanna write that multiple times.
public class EventBase : MonoBehaviour
{
    private void OnEnable()
    {
        //add our base virtual methods to the GameManager delegates.
        GameManager.SceneLoadEvent += SceneLoadCallback;
        GameManager.WatchBuildStartEvent += WatchBuildStartCallback;
        GameManager.WatchBuildEndEvent += WatchBuildEndCallback;
        GameManager.GameLoadEvent += GameLoadCallback;
        GameManager.SceneLeaveEvent += SceneLeaveCallback;
    }

    private void OnDisable()
    {

        //remove our base virtual methods to the GameManager delegates.
        GameManager.SceneLoadEvent -= SceneLoadCallback;
        GameManager.WatchBuildStartEvent -= WatchBuildStartCallback;
        GameManager.WatchBuildEndEvent -= WatchBuildEndCallback;
        GameManager.GameLoadEvent -= GameLoadCallback;
        GameManager.SceneLeaveEvent -= SceneLeaveCallback;
    }


    //method for scene leave, methods will override this function adding in unique functionality
    public virtual void SceneLeaveCallback() { }

    //method for scene load, methods will override this function adding in unique functionality
    public virtual void SceneLoadCallback() { }

    public virtual void WatchBuildStartCallback(WatchTypes type) { }

    public virtual void WatchBuildEndCallback() { }

    public virtual void GameLoadCallback() { }
}