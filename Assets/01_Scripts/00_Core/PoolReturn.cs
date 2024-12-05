using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolReturn : MonoBehaviour
{
    [SerializeField] private bool _isParticle;
    [SerializeField] private bool _isEffectSound;

    private void OnEnable()
    {
        if (_isParticle|| _isEffectSound)
            Invoke(nameof(SelfFalse), 10);
    }

    private void SelfFalse()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        PoolManager.ReturnToPool(gameObject);
    }
}
