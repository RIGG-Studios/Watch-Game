using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : EventBase
{
    public override void SceneLeaveCallback()
    {
        LoadScene(0);
    }

    private void LoadScene(int index)
    {
        if (index < 0)
            return;

        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
