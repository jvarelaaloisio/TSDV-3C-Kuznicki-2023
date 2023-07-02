using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourSingleton<GameManager>
{
    [SerializeField] private int MenuBuildIndex = 0;

    public void LoadLevel(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadMenu()
    {
        //TODO: Fix - Hardcoded value
        SceneManager.LoadScene(MenuBuildIndex);
    }
}
