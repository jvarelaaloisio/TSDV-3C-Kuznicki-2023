using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField]
    private int level1BuildIndex = 1;

    //TODO: Fix - Receive index as parameter
    public void LoadLevel()
    {
        SceneManager.LoadScene(1);
        //TODO: TP2 - Remove unused methods/variables/classes
        //UnloadLevel();
    }

    private void UnloadLevel()
    {
        //TODO: Fix - Hardcoded value
        SceneManager.UnloadSceneAsync(0);
        //TODO: TP2 - Remove unused methods/variables/classes
        //SceneManager.UnloadSceneAsync(0, UnloadSceneOptions.UnloadAllEmbeddedSceneObjects);
    }

    public void LoadMenu()
    {
        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene(0);
    }

    public void LoadGameLevel(bool LoadNext)
    {
        //TODO: TP2 - Remove unused methods/variables/classes
        Scene previousScene = SceneManager.GetActiveScene();
        //TODO: Fix - Trash code
        if (LoadNext)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
