using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform camera;
    [SerializeField] private Transform launchAttackPoint;
    [SerializeField] private float speed = 10.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float launchAttackDetectRadius;
    private Rigidbody rb;
    private Transform attackTarget;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMove(InputValue value)
    {
        Vector2 input = value.Get<Vector2>();

        Vector3 forceAdded = Vector3.zero;

        forceAdded.x = input.normalized.x;
        forceAdded.z = input.normalized.y;
    
        rb.velocity = new Vector3(forceAdded.x * speed, rb.velocity.y, forceAdded.z * speed);
    }

    private void OnJump(InputValue value)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnAttack(InputValue inputValue)
    {
        List<Transform> enemies = new List<Transform>();
        foreach (Collider coll in Physics.OverlapSphere(launchAttackPoint.position, launchAttackDetectRadius))
        {
            if(coll.tag == "Enemy")
            {
                enemies.Add(coll.transform);
            }
        }

        if(enemies.Count > 0)
        {
            attackTarget = GetClosest(enemies);

            LaunchAttack();
        }
    }

    private void LaunchAttack()
    {
        Vector3 newDirection = attackTarget.position - transform.position;

        rb.velocity = Vector3.zero;

        rb.AddForce(newDirection * 10, ForceMode.Impulse);
    }

    private Transform GetClosest(List<Transform> points)
    {
        Transform closest = points[0];

        for(int i = 0; i < points.Count; i++)
        {
            if(Vector3.Distance(transform.position, points[i].position) < Vector3.Distance(transform.position, closest.position))
            {
                closest = points[i];
            }
        }

        return closest;
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(launchAttackPoint.position, launchAttackDetectRadius);
    }
}
