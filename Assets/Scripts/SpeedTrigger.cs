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

    //TODO: Fix - It would be better to just have an OnTriggerEnter in this component, the event will be triggered anyways
    private void GivePlayerBoost(PlayerController controller)
    {
        controller.GetPlayerCharacter().AddSpeed(transform.forward,speedBoost);
    }
}
