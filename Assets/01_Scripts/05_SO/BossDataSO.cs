using UnityEngine;


[CreateAssetMenu(menuName = "ScriptableObject/BossDataSO")]
public class BossDataSO : ScriptableObject
{
    [SerializeField] private string _bossName; public string BossName { get { return _bossName; } }
    [SerializeField] private float _maxHp; public float MaxHp { get { return _maxHp; } }
    [SerializeField] private Sprite _icon; public Sprite Icon { get { return _icon; } }
    [SerializeField] private float _attackpower; public float AttackPower { get { return _attackpower; } }
}
