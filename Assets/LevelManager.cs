using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
   [SerializeField] private PlayerTriggerDetector endGoalTrigger;

    private void Awake()
    {
        endGoalTrigger.OnPlayerTrigger += EndLevel;
    }

    private void EndLevel()
    {
        GameManager.Instance.LoadGameLevel(true);
    }
}
