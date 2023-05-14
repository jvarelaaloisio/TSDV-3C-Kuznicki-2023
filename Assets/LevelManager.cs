using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    [SerializeField] private PlayerTriggerDetector endGoalTrigger;
    [SerializeField] private UnityEvent OnEndLevel;
    [SerializeField] private PlayerController player;
    [SerializeField] private Transform startingPoint;

    private void Awake()
    {
        instance = this;

        endGoalTrigger.OnPlayerTrigger += (PlayerController playerController) => OnEndLevel.Invoke();
    }

    public void RespawnPlayer()
    {
        player.transform.position = startingPoint.position;
        player.GetRigidbody().rotation = Quaternion.Euler(Vector3.zero);
        player.GetRigidbody().velocity = Vector3.zero;
    }
    //private void EndLevel()
    //{
    //    GameManager.Instance.LoadGameLevel(true);
    //}
}
