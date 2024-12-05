using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(EnemyAttack))]
[RequireComponent(typeof(EnemyChase))]
[RequireComponent(typeof(EnemyDead))]
[RequireComponent(typeof(EnemyHit))]
[RequireComponent(typeof(EnemyPatrol))]

public class EnemyIdle : MonoBehaviour
{
    private NavMeshAgent _agent;
    private EnemyAnimator _enemyAni;
    private void Awake()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
        _enemyAni = GetComponentInParent<EnemyAnimator>();
    }
    public void Idel()
    {
        _enemyAni.IdleAniamtion();
        _agent.SetDestination(transform.position);
    }
}
