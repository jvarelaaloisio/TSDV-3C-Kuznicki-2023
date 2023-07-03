using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : MonoBehaviour, ICharacter
{
    [SerializeField] private PlayerSettings playerSettings;
    [SerializeField] private Rigidbody rb;

    private bool characterGrounded;
    private bool characterJumping;

    private int jumpCount = 1;

    private float currentTimeJumping;
    private float coyoteCurrentTime;

    private void Update()
    {
        CheckGrounded();
    }


    public void Jump()
    {
        if (coyoteCurrentTime <= playerSettings.coyoteTargetTime)
        {
            if (jumpCount > 0)
            {
                jumpCount--;

                characterJumping = true;
                rb.AddForce(Vector3.up * playerSettings.jumpForce, ForceMode.VelocityChange);

            }
        }

    }

    /// <summary>
    /// Controls movement via rigidbody and a given direction
    /// </summary>
    /// <param name="relativeMovement"></param>
    public void Move(Vector3 relativeMovement)
    {

        if (Mathf.Abs(rb.velocity.z) > playerSettings.maxHorVelocity)
        {
            relativeMovement = Vector3.zero;
        }

        if (Mathf.Abs(rb.velocity.x) > playerSettings.maxHorVelocity)
        {
            relativeMovement = Vector3.zero;
        }

        if (Mathf.Abs(rb.velocity.y) > playerSettings.maxVertVelocity)
        {
            relativeMovement = Vector3.zero;
        }

        if (rb.useGravity)
        {
            rb.AddForce(new Vector3(relativeMovement.x * playerSettings.speed, 0.0f, relativeMovement.z * playerSettings.speed), ForceMode.VelocityChange);
            //TODO: TP2 - Remove unused methods/variables/classes
            //rb.velocity = rb.velocity + new Vector3(forceAdded.x * settings.speed, 0.0f, forceAdded.z * settings.speed);

            if (rb.velocity.y < 0.0f)
            {
                //isJumping = false;
                rb.velocity += Vector3.up * playerSettings.fallingMultiplier * Physics.gravity.y * Time.deltaTime;
            }
            else if (rb.velocity.y > 0f && !characterGrounded)
                rb.velocity += Vector3.up * Physics.gravity.y * (playerSettings.lowJumpMultiplier - 1) * Time.deltaTime;

            //TODO: TP2 - Remove unused methods/variables/classes
            //CapVelocities();
        }

        if (characterJumping)
            currentTimeJumping += Time.deltaTime;
    }

    public void LaunchAttack(Transform attackTarget)
    {
        rb.rotation = Quaternion.Euler(Vector3.zero);
        rb.velocity = Vector3.zero;
        rb.useGravity = false;
        Vector3 destination = attackTarget.position - rb.transform.position;
        destination = destination.normalized;
        rb.AddRelativeForce(destination * playerSettings.launchAttackForce, ForceMode.Impulse);
    }


    public void Rebound(Collision other)
    {
        rb.useGravity = true;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        rb.rotation = Quaternion.Euler(Vector3.zero);

        if (other != null)
        {
            other.gameObject.GetComponent<ITargetable>().SetTargetted(false);
            other.gameObject.GetComponent<IAttackable>().ReceiveAttack();
        }
        rb.AddForce(Vector3.up * 200, ForceMode.Impulse);
    }

    public void AddSpeed(Vector3 direction, float speedBoost)
    {
        rb.AddForce(direction * speedBoost, ForceMode.Impulse);
    }

    private void CheckGrounded()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, -Vector3.up, out hit, 0.8f))
        {
            characterGrounded = true;

            if (currentTimeJumping > playerSettings.targetLowJumpTimer)
            {
                characterJumping = false;
                currentTimeJumping = 0;
                jumpCount = 1;
            }

            coyoteCurrentTime = 0;
        }
        else
        {
            characterGrounded = false;
        }

        if (!characterGrounded)
            coyoteCurrentTime += Time.deltaTime;

    }

    /// <summary>
    /// Toggles 'characterGrounded' to boolean 'value'
    /// </summary>
    /// <param name="value"></param>
    public void ToggleGrounded(bool value)
    {
        characterGrounded = value;
    }

    /// <summary>
    /// Toggles 'characterJumping' to boolean 'value'
    /// </summary>
    /// <param name="value"></param>
    public void ToggleJumping(bool value)
    {
        characterJumping = value;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }
}
