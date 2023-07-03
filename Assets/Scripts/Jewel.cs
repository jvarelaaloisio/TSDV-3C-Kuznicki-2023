using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour, IAttackable, ITargetable
{
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private Outline outline;

    /// <summary>
    /// Set object targetted state
    /// </summary>
    /// <param name="value"></param>
    public void SetTargettedState(bool value)
    {
        outline.enabled = value;
    }

    /// <summary>
    /// Runs when receiving attack by player
    /// </summary>
    public void ReceiveAttack()
    {
        if (deathParticles != null)
            deathParticles.Play();

        gameObject.SetActive(false);
    }
}
