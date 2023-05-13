using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
   [SerializeField] private PlayerTriggerDetector endGoalTrigger;
    [SerializeField] private UnityEvent OnEndLevel;

    private void Awake()
    {
        endGoalTrigger.OnPlayerTrigger += () => OnEndLevel.Invoke();
    }

    //private void EndLevel()
    //{
    //    GameManager.Instance.LoadGameLevel(true);
    //}
}
