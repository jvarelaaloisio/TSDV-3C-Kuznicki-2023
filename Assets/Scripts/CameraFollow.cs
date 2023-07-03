using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float yDistance;
    [SerializeField] private float horDistance;
    [SerializeField] private float damping;

    private Vector2 mouseInput;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 newPos = target.position - horDistance * target.forward.normalized;
        newPos.y = target.position.y + yDistance;
        transform.position = Vector3.Lerp(transform.position, newPos,damping);
    }

    private void FixedUpdate()
    {
        transform.RotateAround(target.position, Vector3.up, mouseInput.x * 10);
        transform.RotateAround(target.position, Vector3.right, -mouseInput.y * 10);
    }
    
    //TODO: Fix - Using Input related logic outside of an input responsible class
    /// <summary>
    /// Collects Camera Input from new input system
    /// </summary>
    /// <param name="value"></param>
    public void OnCamera(InputValue value)
    {
        mouseInput = value.Get<Vector2>();
    }
}
