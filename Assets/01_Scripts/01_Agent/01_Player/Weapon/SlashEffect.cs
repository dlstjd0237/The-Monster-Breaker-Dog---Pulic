using UnityEngine;

public class SlashEffect : MonoBehaviour
{

    private void OnEnable()
    {
  
        //Debug.Log(transform.localRotation);
        //Debug.Log(player.transform.rotation.y);
        Invoke("OffThis", 1);

    }


    private void OffThis()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<IDamage>(out IDamage enemyHit))
        {
            enemyHit.TakeDamage((int)Random.Range((DataManager.Instance._nowPlayer.AttackPower + DataManager.Instance._nowPlayer.WeaponPower) / 2, (DataManager.Instance._nowPlayer.AttackPower + DataManager.Instance._nowPlayer.WeaponPower) * 1.5f));
        }
     

    }
    //private void OnDisable()
    //{
    //    CancelInvoke();
    //    PoolManager.ReturnToPool(gameObject);
    //}
}
