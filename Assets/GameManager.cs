using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField]
    private int level1BuildIndex = 1;

    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
        //UnloadLevel();
    }

    private void UnloadLevel()
    {
        SceneManager.UnloadSceneAsync(0);
        //SceneManager.UnloadSceneAsync(0, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameLevel(bool LoadNext)
    {
        Scene previousScene = SceneManager.GetActiveScene();
        if (LoadNext)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
