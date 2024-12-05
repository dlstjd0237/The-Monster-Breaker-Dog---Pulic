using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParryingEffect : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<EnemyHit>(out EnemyHit enemyHit))
        {
            enemyHit.ParryingTakeDamge((int)Random.Range(DataManager.Instance._nowPlayer.WeaponPower, DataManager.Instance._nowPlayer.WeaponPower*1.5f));
        }
    }


    private void OnDisable()
    {
        PoolManager.ReturnToPool(gameObject);
    }
}
