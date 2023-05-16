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
    [SerializeField] private PlayerModel playerModel;
    private Rigidbody rb;
    private Transform attackTarget;

    private Vector2 input;

    private bool initCoyoteTimer = false;
    private bool isGrounded;
    private bool isJumping;
    private bool isAttacking;

    private int jumpCount = 1;

    private float coyoteCurrentTime;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerModel = new PlayerModel(rb, GetRelativeMovement, IsJumping, IsGrounded, settings);
    }

    private void Update()
    {
        CheckGrounded();

        CheckNearbyEnemies();
    }

    private void FixedUpdate()
    {
        GetPlayerModel().MyFixedUpdate();
    }

    private void CheckGrounded()
    {
        RaycastHit hit;
        Vector3 originOffset = transform.position + new Vector3(0, -GetComponent<SphereCollider>().radius, 0);

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.8f))
        {
            isGrounded = true;

            if (playerModel.CurrentTimeJumping > settings.targetLowJumpTimer)
            {
                isJumping = false;
                playerModel.CurrentTimeJumping = 0;
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

    private void CheckNearbyEnemies()
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

        return (cameraForward * input.y + cameraRight * input.x) * Time.deltaTime;
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
                playerModel.Jump();
            }
        }
    }


    private void OnAttack(InputValue inputValue)
    {
        if (isAttacking)
            return;

        CheckNearbyEnemies();

        if (attackTarget != null)
            playerModel.LaunchAttack(attackTarget);

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

    public void Damage()
    {

    }

    public PlayerModel GetPlayerModel() => playerModel;


    public bool IsJumping() => isJumping;
    public bool IsGrounded() => isGrounded;



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            playerModel.Rebound(other);
            attackTarget = null;
            isAttacking = false;
        }
    }

    private void OnDrawGizmos()
    {
        if (settings)
            Gizmos.DrawWireSphere(launchAttackPoint.position, settings.launchAttackDetectRadius);
    }
}
