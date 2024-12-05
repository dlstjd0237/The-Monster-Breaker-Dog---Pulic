using System.Collections.Generic;
using UnityEngine;
using System;



[Serializable]
public class EnemySpawnAmount
{
    public int SpawnAmount;
    public SpawnEnemyType SpawnEnemy;
}

public enum SpawnEnemyType
{
    SLIME,
    SPIDER,
    SKELETON,
    ELITESKELETON,
    ANCIENT,
    NOMAD,
    SLAYER

}

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<EnemySpawnAmount> _enemySpawnAmounts = new();
    [SerializeField] private bool _directStart;

    private void Start()
    {
        if (_directStart)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        for (int i = 0; i < _enemySpawnAmounts.Count; ++i)
        {
            for (int j = 0; j < _enemySpawnAmounts[i].SpawnAmount; ++j)
            {
                PoolManager.SpawnFromPool(SpawnEnemyNameSet(_enemySpawnAmounts[i].SpawnEnemy), transform.position);
            }
        }
    }

    private string SpawnEnemyNameSet(SpawnEnemyType spawnEnemy)
    {
        switch (spawnEnemy)
        {
            case SpawnEnemyType.SLIME:
                return "Slime";
            case SpawnEnemyType.SPIDER:
                return "Spider";
            case SpawnEnemyType.SKELETON:
                return "Skeleton";
            case SpawnEnemyType.ELITESKELETON:
                return "EliteSkeleton";
            case SpawnEnemyType.ANCIENT:
                return "Ancient";
            case SpawnEnemyType.NOMAD:
                return "Nomad";
            case SpawnEnemyType.SLAYER:
                return "Slayer";
            default:
                return null;
        }
    }

}


