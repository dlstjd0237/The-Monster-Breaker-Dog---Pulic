using UnityEngine;


public abstract class Enemy : MonoBehaviour
{
    public enum MonsterState { Idle, Patrol, Chase, Attack, Dead, Hit, Stun }
    public MonsterState EnemyState = MonsterState.Idle;
    protected string Name; //���� �̸�
    [HideInInspector] public string ShowName; //���̴� �̸�
    [HideInInspector] public int Lv; //���� ����
    [HideInInspector] public float MaxHp; //���� �ƽ� ����
    [HideInInspector] public float CurrentHp;
    [HideInInspector] public float AttackDamage; //���� ���� ������
    protected float AttackCoolDown; //���� ������ ������
    protected float MoveSpeed; //���� �̵� ���ǵ�

    //������
    [HideInInspector] public int DropGoldMax; //���� ������ ������ ��� �ִ� ��
    [HideInInspector] public int DropGoldMin;//���� ������ ������ ��� �ּ� ��
    [HideInInspector] public float DropExp; //���Ͱ� ������ ������ ����ġ ��

    //����
    protected float ChaseRange; //���� �÷��̾� Ž�� ����
    protected float AttackRange; // ���� �÷��̾� ���� ����

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
