using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTriggerDetector : MonoBehaviour
{
    public Action<PlayerController> OnPlayerTrigger;
    public Action<PlayerController> OnPlayerTriggerExit;

    private void OnTriggerEnter(Collider other)
    {
        if(other.GetComponent<PlayerController>())
        {
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
