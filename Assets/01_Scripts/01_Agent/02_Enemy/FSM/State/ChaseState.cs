using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
public class ChaseState : State
{
    public AttackState _attackState;
    [SerializeField] private SpinState _spinState;
    [SerializeField] private SkillState _skillState;
    public bool isInAttackRange, isInSkillAttackRange;
    private NavMeshAgent _agent;
    private GameObject _player;
    private BossAnimation _bossAnimation;

    private void Awake()
    {
        _agent = transform.parent.GetComponentInParent<NavMeshAgent>();
        _bossAnimation = GetComponentInParent<BossAnimation>();
        _player = GameObject.Find("Player");
    }
    public override State RunCurrentState()
    {
        ChasePlayer();
        if (isInSkillAttackRange)
        {
            isInSkillAttackRange = false;
            return _skillState;
        }
        else if (isInAttackRange)
        {
            isInAttackRange = false;
            if (Random.Range(0, 101) <= 70)
                return _attackState;
            else
                return _spinState;

        }
        else
        {
            return this;
        }

    }

    private void ChasePlayer()
    {
        _bossAnimation.OnRun();
        _agent.SetDestination(_player.transform.position);
        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);
        if (distanceToPlayer >= 6 && distanceToPlayer <= 8)
        {
            isInSkillAttackRange = true;
        }
        else if (distanceToPlayer <= 2)
        {
            isInAttackRange = true;
        }
    }


}
