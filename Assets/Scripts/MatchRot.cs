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

    void LateUpdate()
    {
        transform.rotation = rotationToMatch.rotation;
    }
}
