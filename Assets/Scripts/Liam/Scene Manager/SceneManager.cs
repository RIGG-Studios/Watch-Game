using UnityEngine;
using UnityEngine.SceneManagement;

//Scene manager will have EventBase as a parent class
public class SceneManager : EventBase
{

    public static void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}
