using UnityEngine;

public class Spear : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<PlayerHit>(out PlayerHit playerHit))
        {
            playerHit.TakeDamge(DataManager.Instance._nowPlayer.MaxHp/10);
        }
    }
}
