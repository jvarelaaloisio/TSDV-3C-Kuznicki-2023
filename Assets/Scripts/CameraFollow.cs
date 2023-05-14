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
    //private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        Vector3 newPos = target.position - horDistance * target.forward.normalized;
        newPos.y = target.position.y + yDistance;
        transform.position = Vector3.Lerp(transform.position, newPos,damping);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Vector3 newPos = target.position - horDistance * target.forward.normalized;
        //newPos.y = target.position.y + yDistance;
        //transform.position = Vector3.Lerp(transform.position, newPos,damping);

        transform.RotateAround(target.position, Vector3.up, mouseInput.x * 10);
        transform.RotateAround(target.position, Vector3.right, -mouseInput.y * 10);
        
        //target.Rotate(target.rotation.x, target.rotation.y + mouseInput.x * 30,  target.rotation.z + mouseInput.y * 30);
        //transform.LookAt(target, Vector3.up);
        //transform.RotateAround(target.position, new Vector3(mouseInput.x,0,mouseInput.y),0);
    }
    
    public void OnCamera(InputValue value)
    {
        //Debug.LogError(value.Get<Vector2>());
        mouseInput = value.Get<Vector2>();
    }
}
