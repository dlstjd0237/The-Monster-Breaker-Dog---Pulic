using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private float _mexHealth;
    private float _currentHealth;
    private Collider _collider;

    private void Awake()
    {
        _currentHealth = _mexHealth;
        _collider = GetComponent<Collider>();
    }

    public void TakeDameg(float Damage)
    {

        _currentHealth -= Damage;
        Debug.Log(_currentHealth);
        if (_currentHealth <= 0)
        {
            Die();
        }
        else
        {
            GameObject qwer = PoolManager.SpawnFromPool("DamageText", new Vector3(transform.position.x + Random.Range(-1f, 1), transform.position.y, transform.position.z + Random.Range(-1f, 1f)), Quaternion.Euler(50, 147, 0));
            qwer.GetComponent<DamegText>().Show(Damage);
        }

    }



    public void Die()
    {
      
        _collider.enabled = false;
    }
}
