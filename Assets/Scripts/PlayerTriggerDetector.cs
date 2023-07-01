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
        //TODO: Fix - TryGetComponent
        if(other.GetComponent<PlayerController>())
        {
            //TODO: Fix - Could subscribe the unityEvent to the action in the OnValidate or in the Awake method
            OnPlayerTriggerEvent.Invoke();
            OnPlayerTrigger?.Invoke(other.GetComponent<PlayerController>());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        //TODO: Fix - TryGetComponent
        if(other.GetComponent<PlayerController>())
        {
            OnPlayerTriggerExit?.Invoke(other.GetComponent<PlayerController>());
        }
    }
}
