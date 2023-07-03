using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrigger : MonoBehaviour
{
    [SerializeField] private PlayerTriggerDetector playerTrigger;
    // Start is called before the first frame update
    //TODO: TP2 - Syntax - Consistency in access modifiers (private/protected/public/etc)
    void Start()
    {
        playerTrigger.OnPlayerTrigger += DamagePlayer;
    }

    private void DamagePlayer(PlayerController controller)
    {
        controller.GetComponent<IAttackable>()?.ReceiveAttack();
    }
}
