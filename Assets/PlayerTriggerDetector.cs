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
        if(other.GetComponent<PlayerController>())
        {
            OnPlayerTriggerEvent.Invoke();
            OnPlayerTrigger?.Invoke(other.GetComponent<PlayerController>());
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            OnPlayerTriggerExit?.Invoke(other.GetComponent<PlayerController>());
        }
    }
}
