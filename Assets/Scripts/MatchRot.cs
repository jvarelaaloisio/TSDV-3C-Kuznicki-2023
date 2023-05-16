using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRot : MonoBehaviour
{
    private Transform rotationToMatch;

    private void Start()
    {
        rotationToMatch = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        transform.rotation = rotationToMatch.rotation;
    }
}