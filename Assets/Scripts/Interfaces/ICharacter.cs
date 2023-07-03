using UnityEngine;

public interface ICharacter
{
    public void Jump();
    public void Move(Vector3 movementDir);
    public void LaunchAttack(Transform attackTarget);
    public void Rebound(Collision other);
    public void AddSpeed(Vector3 direction, float speedBoost);
}
