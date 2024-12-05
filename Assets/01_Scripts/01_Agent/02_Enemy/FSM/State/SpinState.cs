using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SpinState : State
{
    private BossAnimation _ani;
    private bool _isSpin;
    private NavMeshAgent _agent;
    private Transform _player;
    [SerializeField] private IdleState _idleState;
    [SerializeField] private BossAxe _bossAxe;

    private void Awake()
    {
        _ani = GetComponentInParent<BossAnimation>();
        _agent = transform.parent.GetComponentInParent<NavMeshAgent>();
        _player = GameObject.Find("Player").transform;
    }

    public override State RunCurrentState()
    {
        if (_isSpin)
        {
            _agent.enabled = true;  
            _isSpin = false;
            return _idleState;
        }
        else
        {
            _agent.enabled = false;
            StartCoroutine(SpinAction());
        }
        return this;
    }


    private IEnumerator SpinAction()
    {
        _bossAxe.IsSpin = true;
        _ani.OnSpin();
        yield return new WaitForSeconds(4);
        _ani.OffSpin();
        _bossAxe.IsSpin = false;
        _isSpin = true;
    }



}
