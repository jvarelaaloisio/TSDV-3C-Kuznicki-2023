using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private Transform camera;
    [SerializeField] private Transform launchAttackPoint;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float launchAttackDetectRadius;
    [SerializeField] private float maxHorVelocity = 5.0f;
    [SerializeField] private float maxVertVelocity = 5.0f;

    [SerializeField] private float fallingMultiplier = 5.0f;

    private Rigidbody rb;
    private Transform attackTarget;

    private Vector2 input;

    private bool isJumping = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 forceAdded = GetRelativeMovement();

        if (rb.useGravity)
        {
            

            rb.velocity = rb.velocity + new Vector3(forceAdded.x * speed, 0.0f, forceAdded.z * speed);

            if (rb.velocity.y < 0.0f)
            {
                isJumping = false;
                rb.velocity += Vector3.up * fallingMultiplier * Physics.gravity.y * Time.fixedDeltaTime;
            }

            CapVelocities();
        }

    }

    private void CapVelocities()
    {
        if (Mathf.Abs(rb.velocity.z) > maxHorVelocity)
        {
            if (rb.velocity.z < 0)
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -maxHorVelocity);
            else
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxHorVelocity);
        }

        if (Mathf.Abs(rb.velocity.x) > maxHorVelocity)
        {
            if (rb.velocity.x < 0)
                rb.velocity = new Vector3(-maxHorVelocity, rb.velocity.y, rb.velocity.z);
            else
                rb.velocity = new Vector3(maxHorVelocity, rb.velocity.y, rb.velocity.z);
        }

        if (Mathf.Abs(rb.velocity.y) > maxVertVelocity)
        {
            if (rb.velocity.y < 0)
                rb.velocity = new Vector3(rb.velocity.x, -maxVertVelocity, rb.velocity.z);
            else
                rb.velocity = new Vector3(rb.velocity.x, maxVertVelocity, rb.velocity.z);
        }
    }

    private Vector3 GetRelativeMovement()
    {
        Vector3 cameraForward = Camera.main.transform.forward;
        cameraForward.y = 0f;
        cameraForward = cameraForward.normalized;

        Vector3 cameraRight = Camera.main.transform.right;
        cameraRight.y = 0f;
        cameraRight = cameraRight.normalized;

        return (cameraForward * input.y + cameraRight * input.x) * Time.fixedDeltaTime;
    }

    private void OnMove(InputValue value)
    {
        input = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
    }

    private void OnAttack(InputValue inputValue)
    {
        List<Transform> enemies = new List<Transform>();
        foreach (Collider coll in Physics.OverlapSphere(launchAttackPoint.position, launchAttackDetectRadius))
        {
            if (coll.tag == "Enemy")
            {
                enemies.Add(coll.transform);
            }
        }

        if (enemies.Count > 0)
        {
            attackTarget = GetClosest(enemies);

            LaunchAttack();
        }
    }

    private void LaunchAttack()
    {
        rb.rotation = Quaternion.Euler(Vector3.zero);
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        Vector3 destination = attackTarget.position - rb.position;
        destination = destination.normalized;
        rb.AddRelativeForce(destination * 20.0f, ForceMode.Impulse);
    }

    private Transform GetClosest(List<Transform> points)
    {
        Transform closest = points[0];

        for (int i = 0; i < points.Count; i++)
        {
            if (Vector3.Distance(transform.position, points[i].position) < Vector3.Distance(transform.position, closest.position))
            {
                closest = points[i];
            }
        }

        return closest;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            rb.useGravity = true;
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(launchAttackPoint.position, launchAttackDetectRadius);
    }
}
