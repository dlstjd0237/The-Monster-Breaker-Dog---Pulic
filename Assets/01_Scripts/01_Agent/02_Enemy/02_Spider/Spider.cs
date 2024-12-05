using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using DG.Tweening;
public class Spider : Enemy
{
    [SerializeField] private UnityEvent IdleEvent, PatrolEvent, AttackOnEvent, AttackOffEvent, AttackEvent;
    [SerializeField] private UnityEvent<Vector3> ChaseEvent;
    [SerializeField] private string _path;
    private Transform _playerTrm; // �÷��̾� ��ġ 
    private EnemySetSO _enemySO; //���� ����
    private NavMeshAgent _agent;
    float timer = 0;

    [SerializeField] private Renderer _renderer;
    private void Awake()
    {
        _enemySO = Resources.Load<EnemySetSO>($"{_path}");
        _agent = GetComponent<NavMeshAgent>();
        
        Info();
    }

    private void OnEnable()
    {
        _playerTrm = GameObject.Find("Player")?.transform;
    }


    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 5)
        {
            timer = 0;
            IsComplete = false;
        }



        if (IsAttack == true || IsDie == true) return;


        if(_playerTrm == null)
        {
            gameObject.SetActive(false);
        }

        else if (Vector3.Distance(_playerTrm.position, transform.position) > ChaseRange)//���� ���� ���� ��
        {
            EnemyState = MonsterState.Patrol;
        }
        else if ((Vector3.Distance(_playerTrm.position, transform.position) < ChaseRange && Vector3.Distance(_playerTrm.position, transform.position) >
        AttackRange) && !IsAttack)//�������� �ȿ� �����鼭 ���ݹ��� �ۿ� ���� ��
        {
            EnemyState = MonsterState.Chase;
            transform.LookAt(_playerTrm);
        }
        else if (Vector3.Distance(_playerTrm.position, transform.position) < AttackRange && !IsAttack)//���ݹ��� �ȿ� ���� ��
        {
            EnemyState = MonsterState.Attack;
            transform.LookAt(_playerTrm);
        }

        AgentStateSet();

    }



    private void AgentStateSet()
    {
        switch (EnemyState)
        {
            case MonsterState.Idle:
                IdleEvent?.Invoke();
                break;
            case MonsterState.Chase:
                ChaseEvent?.Invoke(_playerTrm.position);
                break;
            case MonsterState.Patrol:
                PatrolEvent?.Invoke();
                break;
            case MonsterState.Attack:
                AttackEvent?.Invoke();
                Invoke("AttackSet", AttackCoolDown);
                break;



        }
    }


    private void Info()
    {
        Name = _enemySO.Name;
        ShowName = _enemySO.ShowName;
        Lv = _enemySO.Lv;
        MaxHp = _enemySO.MaxHp;
        AttackDamage = _enemySO.AttackDamage;
        AttackCoolDown = _enemySO.AttackCoolDown;
        MoveSpeed = _enemySO.MoveSpeed;
        _agent.speed = MoveSpeed;
        DropGoldMax = _enemySO.DropGoldMax;
        DropGoldMin = _enemySO.DropGoldMin;
        DropExp = _enemySO.DropExp;
        ChaseRange = _enemySO.ChaseRange;
        AttackRange = _enemySO.AttackRange;
        CurrentHp = MaxHp;
    } //���� ����



    protected override void Dead()
    {
        IsDie = true;
        _renderer.material.SetFloat("_Fadein", 1);
        Sequence q1 = DOTween.Sequence();
        q1.Append(_renderer.material.DOFloat(0, "_Fadein", 2));
        q1.OnComplete(() => { gameObject.SetActive(false); });

    }


    protected override void AttackOn()
    {
        AttackOnEvent?.Invoke();
    }

    protected override void AttackOff()
    {
        AttackOffEvent?.Invoke();
    }
    private void AttackSet()
    {
        IsAttack = false;
    }
}
