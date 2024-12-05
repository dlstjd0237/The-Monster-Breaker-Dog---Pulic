using UnityEngine;
using UnityEngine.Events;
[RequireComponent(typeof(BoxCollider))]
public class EnemyAttack : MonoBehaviour
{
    private Enemy _enemy;
    private bool _isAttacking;
    [SerializeField] private UnityEvent<float> _attackOnEvent;
    [SerializeField] private UnityEvent _attackOffEvent;
    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
    }

    public void Attack()
    {
        _enemy.IsAttack = true;
    }
    public void AttackOn()
    {
        if (_attackOnEvent != null)
            _attackOnEvent?.Invoke(_enemy.AttackDamage);
        else
            _isAttacking = true;


    }

    public void AttackOff()
    {
        if (_attackOffEvent != null)
            _attackOffEvent?.Invoke();
        else
            _isAttacking = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (_isAttacking == false)
            return;

        if (other.TryGetComponent<PlayerHit>(out PlayerHit playerHit))
        {
            playerHit.TakeDamge(_enemy.AttackDamage);
        }
    }
}
