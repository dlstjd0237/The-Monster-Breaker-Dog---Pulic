using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sword : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        //if (other.TryGetComponent<EnemyIdle>(out EnemyIdle enemyHealth))
        //{
        //}
        if (other.TryGetComponent<Dummy>(out Dummy _dummy))
        {
            _dummy.TakeDameg(4);
        }
    }
}
