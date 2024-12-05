using UnityEngine;

public class EnemySkillDamage : MonoBehaviour
{
    [SerializeField] private BossDataSO _bossDataSO;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent<PlayerHit>(out PlayerHit enemy))
            {
                enemy.TakeDamge((int)Random.Range(_bossDataSO.AttackPower / 1.5f, _bossDataSO.AttackPower * 1.5f));
            }
        }
       
    }
}
