using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void LoadGameLevel(bool LoadNext)
    {
        if (LoadNext)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
