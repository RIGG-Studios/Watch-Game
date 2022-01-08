using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this class is meant to put our event inteface into other classes, we had to to
//a base class because we can add and remove it based on if the object is enabled/disabled, and we dont wanna write that multiple times.
public class EventBase : MonoBehaviour, IEventBehaviour
{
    private void OnEnable()
    {
        //add our base virtual methods to the GameManager delegates.
        GameManager.instance.SceneLoadEvent += SceneLoadCallback;
        GameManager.instance.StartGameEvent += StartGameCallback;
        GameManager.instance.EndGameEvent += EndGameCallback;
        GameManager.instance.SceneLeaveEvent += SceneLeaveCallback;
    }

    private void OnDisable()
    {
        if (GameManager.instance == null)
            return;

        //remove our base virtual methods to the GameManager delegates.
        GameManager.instance.SceneLoadEvent -= SceneLoadCallback;
        GameManager.instance.StartGameEvent -= StartGameCallback;
        GameManager.instance.EndGameEvent -= EndGameCallback;
        GameManager.instance.SceneLeaveEvent -= SceneLeaveCallback;
    }

    //method for game, methods will override this function adding in unique functionality
    public virtual void EndGameCallback() { }

    //method for scene leave, methods will override this function adding in unique functionality
    public virtual void SceneLeaveCallback()  { }

    //method for scene load, methods will override this function adding in unique functionality
    public virtual void SceneLoadCallback() { }

    //method for start game, methods will override this function adding in unique functionality
    public virtual void StartGameCallback() { }
}
