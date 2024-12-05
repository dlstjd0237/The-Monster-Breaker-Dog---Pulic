using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemySetSO")]
public class EnemySetSO : ScriptableObject
{
    [Header("몬스터 이름")]
    public string Name;
    [Header("먼스터 보이는 이름")]
    public string ShowName;
    [Header("몬스터 레벨")]
    public int Lv;
    [Header("몬스터 최대HP")]
    public float MaxHp;
    [Header("몬스터 공격력")]
    public float AttackDamage;
    [Header("몬스터 공격후딜레이")]
    public float AttackCoolDown;
    [Header("몬스터 스피드")]
    public float MoveSpeed;

    //죽을때
    [Header("죽었을때 드롭할 최대 골드")]
    public int DropGoldMax;
    [Header("죽었을때 드롭할 최소 골드")]
    public int DropGoldMin;
    [Header("죽었을때 드롭할 경험치")]
    public float DropExp;

    //범위
    [Header("감지 범위")]
    public float ChaseRange;
    [Header("공격 범위")]
    public float AttackRange;

}
