using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jewel : MonoBehaviour, IAttackable, ITargetable
{
    [SerializeField] private ParticleSystem deathParticles;
    [SerializeField] private Outline outline;

    public void SetTargetted(bool value)
    {
        outline.enabled = value;
    }

    public void RecieveAttack()
    {
        if (deathParticles != null)
            deathParticles.Play();
        else
            Destroy(this.gameObject);
    }
}
