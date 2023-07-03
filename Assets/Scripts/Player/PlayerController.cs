using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Transform launchAttackPoint;
    [SerializeField] private Transform cameraPoint;
    [SerializeField] private PlayerSettings settings;
    [SerializeField] private PlayerModel playerModel;

    [SerializeField] private PlayerCharacter playerCharacter;

    private Transform attackTarget;

    private Vector2 input;

    private bool isAttacking;

    private void Update()
    {
        playerCharacter.Move(GetRelativeMovement());

        CheckNearbyEnemies();
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


    private void OnMove(InputValue value)
    {
        //TODO: Fix - Unclear name
        input = value.Get<Vector2>();
    }

    private void OnJump(InputValue value)
    {
        playerCharacter.Jump();
    }


    private void OnAttack(InputValue inputValue)
    {
        //TODO: TP2 - FSM
        if (isAttacking)
            return;

        CheckNearbyEnemies();

        if (attackTarget != null)
            playerCharacter.LaunchAttack(attackTarget);

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
    public PlayerCharacter GetPlayerCharacter() => playerCharacter;


    private void OnCollisionEnter(Collision other)
    {
        //TODO: Fix - TryGetComponent()
        if (other.gameObject.GetComponent<IAttackable>() != null)
        {
            playerCharacter.Rebound(other);
            attackTarget = null;
            isAttacking = false;
        }
        //TODO: Fix - else if(){}, not else{ if(){} }
        else
        {
            if (isAttacking)
            {
                playerCharacter.Rebound(null);
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
