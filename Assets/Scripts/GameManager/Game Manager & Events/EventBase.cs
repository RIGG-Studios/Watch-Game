using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventBase : MonoBehaviour, IEventBehaviour
{
    private void OnEnable()
    {
        GameManager.SceneLoadEvent += SceneLoadCallback;
        GameManager.StartGameEvent += StartGameCallback;
        GameManager.EndGameEvent += EndGameCallback;
        GameManager.SceneLeaveEvent += SceneLeaveCallback;
    }

    private void OnDisable()
    {
        GameManager.SceneLoadEvent -= SceneLoadCallback;
        GameManager.StartGameEvent -= StartGameCallback;
        GameManager.EndGameEvent -= EndGameCallback;
        GameManager.SceneLeaveEvent -= SceneLeaveCallback;
    }

    public virtual void EndGameCallback() { }

    public virtual void SceneLeaveCallback()  { }

    public virtual void SceneLoadCallback() { }

    public virtual void StartGameCallback() { }
}
