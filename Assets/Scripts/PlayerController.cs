using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //[SerializeField] private Transform camera;
    [SerializeField] private Transform launchAttackPoint;
    [SerializeField] private Transform cameraPoint;
    [SerializeField] private PlayerSettings settings;
    private Rigidbody rb;
    private Transform attackTarget;

    private Vector2 input;

    private bool initCoyoteTimer = false;
    private bool isGrounded;
    private bool isJumping;

    private int jumpCount = 1;

    private float coyoteCurrentTime;
    private float currentTimeJumping = 0.0f;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        CheckGrounded();

        List<Transform> enemies = new List<Transform>();
        foreach (Collider coll in Physics.OverlapSphere(launchAttackPoint.position, settings.launchAttackDetectRadius))
        {
            if (coll.tag == "Enemy")
            {
                enemies.Add(coll.transform);
            }
        }

        if (enemies.Count > 0)
        {
            attackTarget = GetClosest(enemies);
            attackTarget.gameObject.GetComponent<Outline>().enabled = true;
        }
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        Vector3 originOffset = transform.position + new Vector3(0, -GetComponent<SphereCollider>().radius, 0);
            
        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.8f))
        {
            isGrounded = true;

            if (currentTimeJumping > settings.targetLowJumpTimer)
            {
                isJumping = false;
                currentTimeJumping = 0;
                jumpCount = 1;
            }

            coyoteCurrentTime = 0;
        }
        else
        {
            isGrounded = false;
        }

        if (!isGrounded)
            coyoteCurrentTime += Time.deltaTime;

    }

    private void FixedUpdate()
    {
        Vector3 forceAdded = GetRelativeMovement();

        if (Mathf.Abs(rb.velocity.z) > settings.maxHorVelocity)
        {
            forceAdded = Vector3.zero;
        }

        if (Mathf.Abs(rb.velocity.x) > settings.maxHorVelocity)
        {
            forceAdded = Vector3.zero;
        }

        if (Mathf.Abs(rb.velocity.y) > settings.maxVertVelocity)
        {
            forceAdded = Vector3.zero;
        }

        if (rb.useGravity)
        {
            rb.AddForce(new Vector3(forceAdded.x * settings.speed, 0.0f, forceAdded.z * settings.speed), ForceMode.VelocityChange);
            //rb.velocity = rb.velocity + new Vector3(forceAdded.x * settings.speed, 0.0f, forceAdded.z * settings.speed);

            if (rb.velocity.y < 0.0f)
            {
                //isJumping = false;
                rb.velocity += Vector3.up * settings.fallingMultiplier * Physics.gravity.y * Time.fixedDeltaTime;
            }
            else if (rb.velocity.y > 0f && !isGrounded)
                rb.velocity += Vector3.up * Physics.gravity.y * (settings.lowJumpMultiplier - 1) * Time.deltaTime;

            //CapVelocities();
        }

        if (isJumping)
            currentTimeJumping += Time.fixedDeltaTime;

    }

    private void CapVelocities()
    {
        if (Mathf.Abs(rb.velocity.z) > settings.maxHorVelocity)
        {
            if (rb.velocity.z < 0)
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -settings.maxHorVelocity);
            else
                rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, settings.maxHorVelocity);
        }

        if (Mathf.Abs(rb.velocity.x) > settings.maxHorVelocity)
        {
            if (rb.velocity.x < 0)
                rb.velocity = new Vector3(-settings.maxHorVelocity, rb.velocity.y, rb.velocity.z);
            else
                rb.velocity = new Vector3(settings.maxHorVelocity, rb.velocity.y, rb.velocity.z);
        }

        if (Mathf.Abs(rb.velocity.y) > settings.maxVertVelocity)
        {
            if (rb.velocity.y < 0)
                rb.velocity = new Vector3(rb.velocity.x, -settings.maxVertVelocity, rb.velocity.z);
            else
                rb.velocity = new Vector3(rb.velocity.x, settings.maxVertVelocity, rb.velocity.z);
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
        if (isGrounded || coyoteCurrentTime <= settings.coyoteTargetTime)
        {
            if (jumpCount > 0)
            {
                isJumping = true;
                jumpCount--;
                rb.AddForce(Vector3.up * settings.jumpForce, ForceMode.VelocityChange);
            }
        }
    }


    private void OnAttack(InputValue inputValue)
    {
        List<Transform> enemies = new List<Transform>();
        foreach (Collider coll in Physics.OverlapSphere(launchAttackPoint.position, settings.launchAttackDetectRadius))
        {
            if (coll.tag == "Enemy")
            {
                enemies.Add(coll.transform);
            }
        }

        if (enemies.Count > 0)
        {
            attackTarget = GetClosest(enemies);
            attackTarget.gameObject.GetComponent<Outline>().enabled = true;
            LaunchAttack();
        }
    }

    private void LaunchAttack()
    {
        rb.rotation = Quaternion.Euler(Vector3.zero);
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        Vector3 destination = attackTarget.position - transform.position;
        destination = destination.normalized;
        rb.AddRelativeForce(destination * settings.launchAttackForce, ForceMode.Impulse);
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

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    public void AddSpeed(Vector3 direction, float speedBoost)
    {
        rb.AddForce(direction * speedBoost, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            rb.useGravity = true;
            other.gameObject.GetComponent<Outline>().enabled = false;
            other.gameObject.SetActive(false);
        }
    }

    private void OnDrawGizmos()
    {
        if (settings)
            Gizmos.DrawWireSphere(launchAttackPoint.position, settings.launchAttackDetectRadius);
    }
}
