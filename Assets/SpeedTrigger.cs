using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrigger : MonoBehaviour
{
    [SerializeField] private PlayerTriggerDetector playerTrigger;
    [SerializeField] private float speedBoost;

    private void Awake()
    {
        playerTrigger.OnPlayerTrigger += GivePlayerBoost;
    }

    private void GivePlayerBoost(PlayerController controller)
    {
        controller.AddSpeed(transform.forward,speedBoost);
    }
}
