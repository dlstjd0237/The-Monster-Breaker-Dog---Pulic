using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class SkillState : State
{
    private BossAnimation _ani;
    private NavMeshAgent _agent;
    [SerializeField] private ChaseState chaseState;
    private bool _onComplet;
    private bool _nextState;
    private void Awake()
    {
        _ani = GetComponentInParent<BossAnimation>();
        _agent = transform.parent.GetComponentInParent<NavMeshAgent>();
    }

    public override State RunCurrentState()
    {
        if (_onComplet == false)
            StartCoroutine(SkillOn());
        if (_nextState == true)
        {
            _nextState = false;
            _onComplet = false;
            return chaseState;
        }
        else
        {
            return this;
        }

    }

    private IEnumerator SkillOn()
    {
        _onComplet = true;
        _agent.isStopped = true;
        _ani.OnShouting();
        PoolManager.SpawnFromPool("EnemyIcedAge", transform.position);
        for (int i = 0; i < 6; ++i)
        {
            PoolManager.SpawnFromPool("SpearSoldier", transform.position + new Vector3(UnityEngine.Random.Range(-3f, 3f), 0, UnityEngine.Random.Range(-3f, 3f)));
            yield return new WaitForSeconds(0.2f);
        }
        yield return new WaitForSeconds(1.5f);
        _agent.isStopped = false;
        _nextState = true;
    }



}
