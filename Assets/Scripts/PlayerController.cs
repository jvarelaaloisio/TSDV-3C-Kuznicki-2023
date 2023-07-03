using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //TODO: TP2 - Remove unused methods/variables/classes
    //[SerializeField] private Transform camera;
    [SerializeField] private Transform launchAttackPoint;
    //TODO: TP2 - Remove unused methods/variables/classes
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

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

        playerModel = new PlayerModel(rb, GetRelativeMovement, IsJumping, IsGrounded, settings);

        //SetCameraValues();
    }

    //private void SetCameraValues()
    //{
    //    //TODO: Fix - Hardcoded value
    //    string controlScheme = PlayerPrefs.GetString("ControlScheme", " ");

    //    if (controlScheme == null)
    //        return;

    //    //TODO: Fix - Hardcoded value
    //    if (controlScheme == "Keyboard")
    //    {
    //        //TODO: Fix - Hardcoded value
    //        GetComponent<Camera>().m_YAxis.m_MaxSpeed = 0.01f;
    //        GetComponent<Camera>().m_XAxis.m_MaxSpeed = 0.2f;
    //    }
    //    else
    //    {
    //        GetComponent<Camera>().m_YAxis.m_MaxSpeed = 0.1f;
    //        GetComponent<Camera>().m_XAxis.m_MaxSpeed = 3f;
    //    }
    //}

    private void Update()
    {
        CheckGrounded();

        CheckNearbyEnemies();
    }

    private void FixedUpdate()
    {
        playerModel.MyFixedUpdate();
    }

    //TODO: TP2 - SOLID This could be it's own component. But it's not obligatory :)
    private void CheckGrounded()
    {
        RaycastHit hit;
        //TODO: TP2 - Remove unused methods/variables/classes
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

    //TODO: Fix - Why is this called in Update?
    private void CheckNearbyEnemies()
    {
        List<Transform> enemies = new List<Transform>();
        foreach (Collider coll in Physics.OverlapSphere(launchAttackPoint.position, settings.ExternLaunchAttackDetectRadius))
        {
            if (coll.GetComponent<IAttackable>() != null)
            {


                if (Vector3.Distance(coll.transform.position, launchAttackPoint.position) <= settings.launchAttackDetectRadius)
                    enemies.Add(coll.transform);
                else
                    coll.GetComponent<ITargetable>()?.SetTargetted(false);
            }
        }

        if (enemies.Count > 0)
        {
            attackTarget = GetClosest(enemies);
            attackTarget.gameObject.GetComponent<ITargetable>()?.SetTargetted(true);
        }
        else
            attackTarget = null;
    }



    private Vector3 GetRelativeMovement()
    {
        //TODO: Fix - Cache value/s
        //TODO: Fix - Camera.main.transform.TransformDirection()
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
        //TODO: Fix - Unclear name
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
        //TODO: TP2 - FSM
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

    //TODO: Fix - Should be native Setter/Getter
    public PlayerModel GetPlayerModel() => playerModel;


    //TODO: TP2 - Syntax - Fix declaration order
    public bool IsJumping() => isJumping;
    public bool IsGrounded() => isGrounded;



    private void OnCollisionEnter(Collision other)
    {
        //TODO: Fix - TryGetComponent()
        if (other.gameObject.GetComponent<IAttackable>() != null)
        {
            playerModel.Rebound(other);
            attackTarget = null;
            isAttacking = false;
        }
        //TODO: Fix - else if(){}, not else{ if(){} }
        else
        {
            if (isAttacking)
            {
                playerModel.Rebound(null);
                isAttacking = false;
                attackTarget = null;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (settings)
            Gizmos.DrawWireSphere(launchAttackPoint.position, settings.launchAttackDetectRadius);
    }
}
