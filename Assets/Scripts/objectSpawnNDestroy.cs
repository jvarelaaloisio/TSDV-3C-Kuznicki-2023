using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//TODO: Fix - Code is in Spanish or is trash code
public class objectSpawnNDestroy : MonoBehaviour
{
    private GameObject _newChild;

    [ContextMenu("SARASA")]
    public void SpawnObject()
    {
        _newChild = new GameObject("Nice");
        _newChild.transform.SetParent(transform);
    }

    [ContextMenu("tita")]
    private void DestroyObject()
    {
        if (_newChild)
            Destroy(_newChild);
        else
            Debug.LogError("QUEE");
    }

    [ContextMenu("jita", true)]
    private bool ValidateDestroyObject()
    {
        return _newChild != null;
    }
}
