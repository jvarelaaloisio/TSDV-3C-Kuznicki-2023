using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MatchRot : MonoBehaviour
{
    [SerializeField] Transform rotationToMatch;
    void Update()
    {
        transform.rotation = rotationToMatch.rotation;
    }
}
