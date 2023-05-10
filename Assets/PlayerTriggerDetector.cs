using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerDetector : MonoBehaviour
{
    public Action OnPlayerTrigger;
    public Action OnPlayerTriggerExit;
    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            OnPlayerTrigger?.Invoke();
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
            OnPlayerTriggerExit?.Invoke();
        }
    }
}
