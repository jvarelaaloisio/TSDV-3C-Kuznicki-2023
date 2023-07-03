using UnityEngine;

public interface ICharacter
{
    public void Jump();
    public void Move();
    public void LaunchAttack(Transform attackTarget);
    public void Rebound(Collision other);
    public void AddSpeed(Vector3 direction, float speedBoost);
}
