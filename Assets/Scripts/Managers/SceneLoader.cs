using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader instance;
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Load new Scene
    public void GoToScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}
