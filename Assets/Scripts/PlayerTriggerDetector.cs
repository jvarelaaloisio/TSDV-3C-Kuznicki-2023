using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTriggerDetector : MonoBehaviour
{
    public Action<PlayerController> OnPlayerTrigger;
    public Action<PlayerController> OnPlayerTriggerExit;

    [SerializeField] private UnityEvent OnPlayerTriggerEvent;

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            //TODO: Fix - Could subscribe the unityEvent to the action in the OnValidate or in the Awake method
            OnPlayerTriggerEvent.Invoke();
            OnPlayerTrigger?.Invoke(playerController);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<PlayerController>(out PlayerController playerController))
        {
            OnPlayerTriggerExit?.Invoke(other.GetComponent<PlayerController>());
        }
    }
}
