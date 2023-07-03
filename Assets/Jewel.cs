using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour, IAttackable, ITargetable
{
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private Outline outline;

    //TODO: Fix - Unclear logic
    public void SetTargetted(bool value)
    {
        outline.enabled = value;
    }

    public void ReceiveAttack()
    {
        if (deathParticles != null)
            deathParticles.Play();

        gameObject.SetActive(false);
    }
}
