using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAxe : MonoBehaviour
{
    public bool IsAttack { get; set; }
    public bool IsSpin { get; set; }
    private Transform _playerTrm;
    public Transform BossTrm { get; set; }

    [SerializeField] private BossDataSO _bossDataSO;
    private void Awake()
    {
        _playerTrm = GameObject.Find("Player").transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (IsAttack)
        {
            if (other.TryGetComponent<PlayerHit>(out PlayerHit playerHit))
            {
                playerHit.TakeDamge(Random.Range(_bossDataSO.AttackPower / 1.5f, _bossDataSO.AttackPower * 1.5f));
            }
        }
        if (IsSpin)
        {
            if (other.TryGetComponent<PlayerHit>(out PlayerHit playerHit))
            {
                playerHit.TakeDamge(Random.Range(_bossDataSO.AttackPower / 3f, _bossDataSO.AttackPower));
            }
        }

    }
}
