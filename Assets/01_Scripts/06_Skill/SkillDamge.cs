using UnityEngine;

public class SkillDamge : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if (other.TryGetComponent<IDamage>(out IDamage enemy))
        {
            enemy.TakeDamage((int)Random.Range((DataManager.Instance._nowPlayer.AttackPower + DataManager.Instance._nowPlayer.WeaponPower) / 1.5f, (DataManager.Instance._nowPlayer.AttackPower + DataManager.Instance._nowPlayer.WeaponPower) * 2.5f));
        }

    }
}
