using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/EnemySetSO")]
public class EnemySetSO : ScriptableObject
{
    [Header("���� �̸�")]
    public string Name;
    [Header("�ս��� ���̴� �̸�")]
    public string ShowName;
    [Header("���� ����")]
    public int Lv;
    [Header("���� �ִ�HP")]
    public float MaxHp;
    [Header("���� ���ݷ�")]
    public float AttackDamage;
    [Header("���� �����ĵ�����")]
    public float AttackCoolDown;
    [Header("���� ���ǵ�")]
    public float MoveSpeed;

    //������
    [Header("�׾����� ����� �ִ� ���")]
    public int DropGoldMax;
    [Header("�׾����� ����� �ּ� ���")]
    public int DropGoldMin;
    [Header("�׾����� ����� ����ġ")]
    public float DropExp;

    //����
    [Header("���� ����")]
    public float ChaseRange;
    [Header("���� ����")]
    public float AttackRange;

}
