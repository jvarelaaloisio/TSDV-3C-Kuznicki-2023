using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel
{
    Rigidbody rb;
    Func<Vector3> GetRelativeMovement;
    Func<bool> IsJumping;
    Func<bool> IsGrounded;
    
    PlayerSettings settings;

    private float currentTimeJumping;

    public float CurrentTimeJumping
    {
        get => currentTimeJumping;
        set => currentTimeJumping = value;
    }

    //TODO: Fix - We talked about this in class, but we can revisit it on call if you need :)
    public PlayerModel(Rigidbody rb, Func<Vector3> GetRelativeMovement, Func<bool> IsJumping, Func<bool> IsGrounded, PlayerSettings settings)
    {
        this.rb = rb;
        this.GetRelativeMovement = GetRelativeMovement;
        this.IsGrounded = IsGrounded;
        this.IsJumping = IsJumping;
        this.settings = settings;
    }
    

    public void MyFixedUpdate()
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
            //TODO: TP2 - Remove unused methods/variables/classes
            //rb.velocity = rb.velocity + new Vector3(forceAdded.x * settings.speed, 0.0f, forceAdded.z * settings.speed);

            if (rb.velocity.y < 0.0f)
            {
                //isJumping = false;
                rb.velocity += Vector3.up * settings.fallingMultiplier * Physics.gravity.y * Time.deltaTime;
            }
            else if (rb.velocity.y > 0f && !IsGrounded())
                rb.velocity += Vector3.up * Physics.gravity.y * (settings.lowJumpMultiplier - 1) * Time.deltaTime;

            //TODO: TP2 - Remove unused methods/variables/classes
            //CapVelocities();
        }

        if (IsJumping())
            currentTimeJumping += Time.deltaTime;

    }

    public Rigidbody GetRigidbody() => rb;

    public void LaunchAttack(Transform attackTarget)
    {
        rb.rotation = Quaternion.Euler(Vector3.zero);
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        Vector3 destination = attackTarget.position - rb.transform.position;
        destination = destination.normalized;
        rb.AddRelativeForce(destination * settings.launchAttackForce, ForceMode.Impulse);
    }

    public void AddSpeed(Vector3 direction, float speedBoost)
    {
        rb.AddForce(direction * speedBoost, ForceMode.Impulse);
    }

    public void Jump()
    {
        rb.AddForce(Vector3.up * settings.jumpForce, ForceMode.VelocityChange);
    }

    public void Rebound(Collision other)
    {
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.Euler(Vector3.zero);

        if(other != null)
        {
            other.gameObject.GetComponent<ITargetable>().SetTargetted(false);
            other.gameObject.GetComponent<IAttackable>().ReceiveAttack();
        }
        rb.AddForce(Vector3.up * 200, ForceMode.Impulse);
    }
}
