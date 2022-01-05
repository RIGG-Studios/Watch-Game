using UnityEngine;

//this is an inteface for classes that will implenent event behaviour, or wants to be notified of when a new event occurs.
public interface IEventBehaviour
{
    //event method for scene load
    public void SceneLoadCallback();

    //event method for start game
    public void StartGameCallback();

    //event method for end game
    public void EndGameCallback();

    //event method for scene leave
    public void SceneLeaveCallback();
}
