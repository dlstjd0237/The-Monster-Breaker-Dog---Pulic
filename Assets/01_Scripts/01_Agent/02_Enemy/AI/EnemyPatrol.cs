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
        Vector3 randomDirection = Random.insideUnitSphere * 10f; // 원하는 범위 내의 랜덤한 방향 벡터를 생성합니다.
        randomDirection += transform.position; // 랜덤 방향 벡터를 현재 위치에 더합니다.

        NavMeshHit hit;
        if (NavMesh.SamplePosition(randomDirection, out hit, 10f, NavMesh.AllAreas)) // 랜덤 위치가 NavMesh 위에 있는지 확인합니다.
        {
            return hit.position; // NavMesh 위의 랜덤 위치를 반환합니다.
        }
        else
        {
            return transform.position; // NavMesh 위의 랜덤 위치를 찾지 못한 경우 현재 위치를 반환합니다.
        }
    }
}