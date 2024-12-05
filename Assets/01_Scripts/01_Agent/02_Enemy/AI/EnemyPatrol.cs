using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyPatrol : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Enemy enemy;
    private void Awake()
    {
        _agent = GetComponentInParent<NavMeshAgent>();
        enemy = GetComponentInParent<Enemy>();
    }
    public void Patrol()
    {
        if (enemy.IsComplete) return;
      
        
            enemy.IsComplete = true;
            Vector3 randomPosition = GetRandomPositionOnNavMesh();
            _agent.SetDestination(randomPosition);
            enemy.CompleteSet();

        
    }
    Vector3 GetRandomPositionOnNavMesh()
    {
        Vector3 randomDirection = Random.insideUnitSphere * 10f; // ���ϴ� ���� ���� ������ ���� ���͸� �����մϴ�.
        randomDirection += transform.position; // ���� ���� ���͸� ���� ��ġ�� ���մϴ�.

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas)) // ���� ��ġ�� NavMesh ���� �ִ��� Ȯ���մϴ�.
        {
            return hit.position; // NavMesh ���� ���� ��ġ�� ��ȯ�մϴ�.
        }
        else
        {
            return transform.position; // NavMesh ���� ���� ��ġ�� ã�� ���� ��� ���� ��ġ�� ��ȯ�մϴ�.
        }
    }
}