using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class PlayerMovement : MonoBehaviour
{
    private Camera _mainCam;
    private NavMeshAgent _agent;
    private PlayerAnimationControl _playerAnimation;
    private int _floor;
    private PlayerInputManager _playerInputManager;
    private Animator _animator;
    [SerializeField] private float _rollCoolTIme = 3f;
    private float _rollSpeed = 10;
    private bool _isRoll;

    private void Awake()
    {
        _floor = (-1) - (1 << LayerMask.NameToLayer("Decoration"));
        _mainCam = Camera.main;
        _playerAnimation = GetComponent<PlayerAnimationControl>();
        _playerInputManager = GetComponent<PlayerInputManager>();
        _agent = _playerInputManager.Agent;

        if (_agent == null)
        {
            _agent = GetComponentInParent<NavMeshAgent>();
            _agent.autoRepath = true;
        }

    }

    void Update()
    {
        if (_agent == null)
        {
            Debug.Log("에이전트 비었당");
            _agent = _playerInputManager.Agent;
        }
        if (_agent.remainingDistance < 0.1f)
        {
            if (_animator == null)
                _animator = GetComponent<Animator>();
            _animator.SetFloat("Speed", 0);
            Stop();
        }
        if (_isRoll == true)
        {
            _rollCoolTIme -= Time.deltaTime;
            if (_rollCoolTIme <= 0)
            {
                _isRoll = false;
                _rollCoolTIme = 3;
            }
        }
    }



    public void Move()
    {
        if (!_playerInputManager.Input)
        {
            if (_agent == null)
            {
                Debug.Log("기모띠");
                _agent = _playerInputManager.Agent;
            }
            if (_mainCam == null)
            {
                _mainCam = Camera.main;
            }
            Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
            if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _floor))
            {
                _agent.speed = 8;
                _agent.SetDestination(hit.point);

                _playerAnimation.Walking(_agent.speed);

            }
        }

    }

    public void Roll()
    {
        if (_isRoll == false)
        {
            _isRoll = true;
            _playerAnimation.OnRoll();
            StartCoroutine(RollCoroutine());

        }

    }
    public void Stop()
    {

        _playerAnimation.Stop();
    }
    public void ReSetDostance()
    {
        _agent.speed = 0;
    }

    private IEnumerator RollCoroutine()
    {
        float elapsedTime = 0.0f;
        float originalSpeed = _agent.speed;
        _agent.speed = _rollSpeed;
        _playerInputManager.PlayerInputDisable();
        while (elapsedTime < 0.2f)
        {
            Vector3 rollDirection = transform.forward;
            rollDirection.y = 0.0f;
            rollDirection.Normalize();

            Vector3 destination = transform.position + rollDirection * 3.0f;
            _agent.SetDestination(destination);

            elapsedTime += Time.deltaTime;
            yield return null;
        }
        _agent.speed = originalSpeed;
        _playerInputManager.PlayerInputEnable();
    }

}
