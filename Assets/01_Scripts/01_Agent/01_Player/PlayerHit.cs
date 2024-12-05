using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    private PlayerAnimationControl _animationControl;

    private void Awake()
    {
        _animationControl = GetComponentInParent<PlayerAnimationControl>();
    }


    public void TakeDamge(float damage)
    {
        if (DataManager.Instance._nowPlayer.DefensePercentage + DataManager.Instance._nowPlayer.ShieldPower > Random.Range(0, 100))
        {
            GameObject qwer = PoolManager.SpawnFromPool("DamageText", new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f), transform.position.y, transform.position.z + Random.Range(-0.5f, 0.5f)), Quaternion.Euler(50, 147, 0));
            qwer.GetComponent<DamegText>().Show("방어 성공!");
            GameObject parryingEffect = PoolManager.SpawnFromPool("ParryingEffect", transform.position);
        }
        else
        {
            DataManager.Instance._nowPlayer.CurrentHp -= damage;
            GameObject qwer = PoolManager.SpawnFromPool("DamageText", new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f), transform.position.y, transform.position.z + Random.Range(-0.5f, 0.5f)), Quaternion.Euler(50, 147, 0));
            qwer.GetComponent<DamegText>().ShowPlayerDamge(damage);
            if (DataManager.Instance._nowPlayer.CurrentHp <= 0)
            {
                if (_animationControl == null)
                    _animationControl = GetComponentInParent<PlayerAnimationControl>();
                CameraManager.Instance.FollowCam.CameraOffSet(x: -3, y: 8, z: 5);
                _animationControl.DIe();
            }
        }
    }
}
