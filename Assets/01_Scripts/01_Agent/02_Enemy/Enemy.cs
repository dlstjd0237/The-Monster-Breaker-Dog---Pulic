using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    public enum MonsterState { Idle, Patrol, Chase, Attack, Dead, Hit, Stun }
    public MonsterState EnemyState = MonsterState.Idle;
    protected string Name; //몬스터 이름
    [HideInInspector] public string ShowName; //보이는 이름
    [HideInInspector] public int Lv; //몬스터 레벨
    [HideInInspector] public float MaxHp; //몬스터 맥스 레벨
    [HideInInspector] public float CurrentHp;
    [HideInInspector] public float AttackDamage; //몬스터 공격 데미지
    protected float AttackCoolDown; //몬스터 공격후 딜레이
    protected float MoveSpeed; //몬스터 이동 스피드

    //죽을때
    [HideInInspector] public int DropGoldMax; //몬스터 죽을때 떨구는 골드 최대 값
    [HideInInspector] public int DropGoldMin;//몬스터 죽을때 떨구는 골드 최소 값
    [HideInInspector] public float DropExp; //몬스터가 죽을떄 떨구는 경험치 량

    //범위
    protected float ChaseRange; //몬스터 플레이어 탐지 범위
    protected float AttackRange; // 몬스터 플레이어 공격 범위

    public bool IsComplete;
    public bool IsAttack;
    public bool IsDie;


    protected abstract void Dead();

    protected abstract void AttackOn();
    protected abstract void AttackOff();

    public void CompleteSet()
    {
        Invoke("OnCompleteSet", 5);
    }

    private void OnCompleteSet()
    {
        IsComplete = false;
    }
}
