using UnityEngine;
using UnityEngine.AI;
public class EnemyChase : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Enemy enemy;
    private void Awake()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
        enemy = GetComponentInParent<Enemy>();
    }
    public void Chase(Vector3 _playerDir)
    {
        _agent.SetDestination(_playerDir);
    }
}
