using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    private bool _isAttacking;
    private float _attackPower;
    public void OnAttack(float value)
    {
        _attackPower = value;
        _isAttacking = true;
    }

    public void OffAttack()
    {
        _isAttacking = false;
    }



    private void OnTriggerEnter(Collider other)
    {
        if (_isAttacking == false)
            return;

        if (other.TryGetComponent<PlayerHit>(out PlayerHit playerHit))
        {
            playerHit.TakeDamge(_attackPower);
        }
    }
}
