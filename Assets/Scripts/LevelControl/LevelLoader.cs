using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//TODO: Fix - Unclear name
public class LevelLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        GameManager.Instance.LoadGameLevel(true);
    }

    public void EndGame()
    {
        Application.Quit();
    }
}
