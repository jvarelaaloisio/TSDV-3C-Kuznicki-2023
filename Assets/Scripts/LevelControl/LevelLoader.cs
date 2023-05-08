using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private int level1BuildIndex = 1;

    [ContextMenu("CARLIIITOOOOO")]
    public void LoadLevel()
    {
        SceneManager.LoadSceneAsync(level1BuildIndex,LoadSceneMode.Additive);
    }

    [ContextMenu("MARTEEEEEN", true)]
    private bool ValidateLoadLEvel1()
    {
        return Application.isPlaying;
    }

    [ContextMenu("UnloadLevel")]
    private void UnloadLevel()
    {
        SceneManager.UnloadSceneAsync(level1BuildIndex);
    }
}
