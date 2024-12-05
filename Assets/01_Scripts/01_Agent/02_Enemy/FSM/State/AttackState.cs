using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AttackState : State
{
    public IdleState _idleState;
    private BossAnimation _ani;
    private bool _isAttack;
    [SerializeField] private BossAxe _bossAxe;
    private void Awake()
    {
        _ani = transform.parent.GetComponentInParent<BossAnimation>();
        _bossAxe.BossTrm = transform.parent.GetComponentInParent<Transform>(); 
    }
    public override State RunCurrentState()
    {
        if (!_isAttack)
        {
            StartCoroutine(AttackCoroutine());

            return _idleState;

        }
        else
        {
            return this;
        }
    }
    private IEnumerator AttackCoroutine()
    {
        if (_isAttack == false)
        {
            _ani.OnAttack();
            _isAttack = true;
            _bossAxe.IsAttack = true;
            yield return new WaitForSeconds(2.3f);
            _bossAxe.IsAttack = false;
            _isAttack = false;
        }
    }
}
