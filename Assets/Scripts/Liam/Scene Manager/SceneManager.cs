using UnityEngine;
using UnityEngine.SceneManagement;

//Scene manager will have EventBase as a parent class
public class SceneManager : EventBase
{
    public override void SceneLeaveCallback()
    {
        //when the scene leave event happens, load our "base" scene
        LoadScene(0);
    }

    private void LoadScene(int index)
    {
        //if the index is negative, return since there will be an error
        if (index < 0)
            return;

        //load the scene with the scene management methods.
        UnityEngine.SceneManagement.SceneManager.LoadScene(index);
    }
}
