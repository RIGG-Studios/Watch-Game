using UnityEngine;

public interface IEventBehaviour
{
    public void SceneLoadCallback();

    public void StartGameCallback();

    public void EndGameCallback();

    public void SceneLeaveCallback();
}
