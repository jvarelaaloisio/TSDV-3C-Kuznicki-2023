using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private int firstLevelBuildIndex = 1;
    public void LoadFirstLevel()
    {
        GameManager.Instance.LoadLevel(firstLevelBuildIndex);
    }
}
