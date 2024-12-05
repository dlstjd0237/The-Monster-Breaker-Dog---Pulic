using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class BossHP : MonoBehaviour, IDamage
{
    [SerializeField] private BossDataSO _bossDataSO;
    private float _maxHP;
    [SerializeField] private UnityEvent _dieEvent;
    [SerializeField] private UnityEvent<float> _hitHpSet;
    private float _currentHP;
    private BossAnimation _bossAnimation;
    [SerializeField] private InventoryUI _inventory;
    [SerializeField] private DialogueData _dieData;
    [SerializeField] private SkillDataSO _giveSkill;

    private void Awake()
    {
        _maxHP = _bossDataSO.MaxHp;
        _currentHP = _maxHP;
        _bossAnimation = transform.Find("AI").GetComponent<BossAnimation>();
    }

    private async void Die()
    {
        _dieEvent?.Invoke();

        await Task.Delay(3000);
        CameraManager.Instance.FollowCam.CameraOffSet(-3, 8, 5);
        DataManager.Instance._nowPlayer.Coin += 500;
        DialogueManager.StartDialogue(_dieData, null, () => SceneControlManager.Instance.FadeOut(() => SceneManager.LoadScene("InGameLobby")));
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        _currentHP -= damage;
        _hitHpSet?.Invoke(_currentHP);
        PoolManager.SpawnFromPool("EnemyHitSound", transform.position);
        GameObject qwer = PoolManager.SpawnFromPool("DamageText", new Vector3(transform.position.x + Random.Range(-1f, 1), transform.position.y, transform.position.z + Random.Range(-1f, 1f)), Quaternion.Euler(50, 147, 0));
        qwer.GetComponent<DamegText>().Show(damage);
        if (_currentHP <= 0)
        {
            _inventory.TakeSkiil(_giveSkill);
            Die();
        }
    }
}
