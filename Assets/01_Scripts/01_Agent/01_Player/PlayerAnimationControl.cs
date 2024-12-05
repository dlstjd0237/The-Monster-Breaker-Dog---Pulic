using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.AI;
using System.Threading.Tasks;
using UnityEngine.SceneManagement;

public class PlayerAnimationControl : MonoBehaviour
{
    private readonly int _moveSpeed = Animator.StringToHash("Speed");
    private readonly int _attack = Animator.StringToHash("IsAttack");
    private readonly int _attackSpeed = Animator.StringToHash("AttackSpeed");
    private readonly int _isCombo = Animator.StringToHash("Combo");
    private readonly int _isRoll = Animator.StringToHash("IsRoll");
    private readonly int _isSkill = Animator.StringToHash("IsSkill");
    private readonly int _isDie = Animator.StringToHash("IsDie");

    private Animator _animator;

    [SerializeField] private List<Renderer> _renderer = new List<Renderer>();
    [SerializeField] private Material _mtrlDissolve;
    [SerializeField] private Collider _SwordCollider;
    [SerializeField] private string _lobbyName;
    private int _combo = 0;
    private Camera _mainCam;
    private PlayerInputManager _playerInputManager;
    private NavMeshAgent _agent;
    private int _floor;
    private void Awake()
    {
        _mainCam = Camera.main;
        _playerInputManager = GetComponent<PlayerInputManager>();
        _animator = GetComponent<Animator>();
        _animator.SetFloat(_attackSpeed, DataManager.Instance._nowPlayer.AttackSpeed);
        _agent = GetComponent<NavMeshAgent>();
        for (int i = 0; i < _renderer.Count; i++)
        {
            _renderer[i].material = _mtrlDissolve;

        }
        _floor = (-1) - (1 << LayerMask.NameToLayer("Decoration"));
    }

    public async void OnSkillAni()
    {
        _agent.isStopped = true;
        _combo = 0;
        _animator.SetTrigger(_isSkill);
        await Task.Delay(1000);
        _agent.isStopped = false;
    }

    public void OnRoll()
    {
        _animator.SetTrigger(_isRoll);
    }


    public void OnMat()
    {
        for (int i = 0; i < _renderer.Count; i++)
        {
            _renderer[i].material.SetFloat("_Cutoff_Height", 0);
            _renderer[i].material.DOFloat(3, "_Cutoff_Height", 2);
        }
    }
    public void OffMat()
    {
        for (int i = 0; i < _renderer.Count; i++)
        {
            _renderer[i].material.SetFloat("_Cutoff_Height", 3);
            _renderer[i].material.DOFloat(0, "_Cutoff_Height", 1);
        }
    }
    public void Walking(float Value)
    {
        _animator.SetFloat(_moveSpeed, Value);
    }
    public void Stop()
    {
        _animator.SetFloat(_moveSpeed, 0);
    }
    public void AttackOn()
    {
        if (!_playerInputManager.Input && _combo == 0)
        {
            _SwordCollider.enabled = true;
            _animator.SetBool(_attack, true);
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _floor))
            {
                transform.LookAt(hit.point);

            }
        }
        else if (_playerInputManager.Input && _combo == 0)
        {
            _combo++;
        }


    }

    public void IsAttackOff()
    {
        _combo = 0;
    }
    public void AttackOff()
    {
        if (_combo == 1)
        {

            _combo++;
            _animator.SetInteger(_isCombo, _combo);
            return;
        }
        _SwordCollider.enabled = false;
        _combo = 0;
        _animator.SetInteger(_isCombo, _combo);
        _animator.SetBool(_attack, false);

    }

    public void DIe()
    {
        _animator.SetTrigger(_isDie);
    }

    public void DIeEvent()
    {
        SceneControlManager.Instance.FadeOut(() => SceneManager.LoadScene(_lobbyName));
    }
}
