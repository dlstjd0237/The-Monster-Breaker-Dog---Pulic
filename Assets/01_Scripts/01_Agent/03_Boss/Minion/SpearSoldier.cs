using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearSoldier : MonoBehaviour
{
    private Transform _target;
    private Vector3 _dir;
    private void OnEnable()
    {

        _target = GameObject.Find("Player")?.transform;
        if (_target != null)
        {
            _dir = (_target.position - transform.position).normalized;
            transform.LookAt(_target);

        }

    }

    private void Start()
    {
        Invoke(nameof(Count), 3);
    }
    private void Update()
    {
        transform.position += _dir * 7 * Time.deltaTime;

    }
    private void Count()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        PoolManager.ReturnToPool(gameObject);
    }
}

