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

    [SerializeField] private GameObject[] respawneableObjects;

    private void Awake()
    {
        instance = this;
        Cursor.lockState = CursorLockMode.Locked;
        endGoalTrigger.OnPlayerTrigger += OnEndLevelHandler;
    }

    public void RespawnPlayer()
    {
        player.transform.position = startingPoint.position;
        player.GetPlayerModel().GetRigidbody().rotation = Quaternion.Euler(Vector3.zero);
        player.GetPlayerModel().GetRigidbody().velocity = Vector3.zero;

        foreach (var item in respawneableObjects)
        {
            item.SetActive(true);
            item.GetComponent<Outline>().enabled = false;
        }
    }

    public void LoadNextLevel()
    {
        GameManager.Instance.LoadGameLevel(true);
    }

    public void LoadMainMenu()
    {
        GameManager.Instance.LoadMenu();
    }
    private void OnEndLevelHandler(PlayerController controller)
    {
        OnEndLevel.Invoke();
        Cursor.lockState = CursorLockMode.None;
    }
}
