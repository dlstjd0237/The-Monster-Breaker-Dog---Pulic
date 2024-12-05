using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Soul : MonoBehaviour
{
    private int _floor;
    [SerializeField] private float _speed;

    private NavMeshAgent _agent;
    private Camera _mainCam;
    private Animator _animator;
    private PlayerInteract _playerInteract;
    private readonly int _aniSpeed = Animator.StringToHash("Speed");

    private SoulInput _soulInpit;
    private SoulInput.OnFloorActions _onFloor;
    private SoulInput.OnTextActions _onText;

    [SerializeField]private DialogueData _dialogueData;

    private void Awake()
    {
        Invoke(nameof(OnDialogue),2);
        _playerInteract = GetComponent<PlayerInteract>();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _mainCam = Camera.main;
        _floor = (-1) - (1 << LayerMask.NameToLayer("Decoration"));
        InputInit();
    }

    private void InputInit()
    {
        _soulInpit = new SoulInput();
        _onFloor = _soulInpit.OnFloor;
        _onText = _soulInpit.OnText;
        _onText.Disable();

        _onFloor.Move.performed += ctx => Movement();
        _onFloor.Interact.performed += ctx => _playerInteract.OnInteract();
    }
    private void OnDialogue()
    {
        DialogueManager.StartDialogue(_dialogueData);
    }
    private void Update()
    {
        if (_agent.remainingDistance < 0.1f)
        {
            _agent.speed = 0;
            _animator.SetFloat(_aniSpeed, _agent.speed);
        }
    }
    private void Movement()
    {
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _floor))
        {
            _agent.speed = _speed;
            _agent.SetDestination(hit.point);
            _animator.SetFloat(_aniSpeed, _agent.speed);

        }
    }

    private void OnEnable()
    {
        _soulInpit.Enable();
    }
    private void OnDisable()
    {
        _soulInpit.Disable();
    }
}
