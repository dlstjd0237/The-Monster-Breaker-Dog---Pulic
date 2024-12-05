using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;
using System;

public class PlayerInputManager : MonoBehaviour
{

    private PlayerInput _playerInput; //인풋 시스템

  

    private PlayerInput.OnFloorActions _OnFloor;
    private PlayerInput.InventoryActions _OnInventory;
    private PlayerMovement _playerMovement; // 플레이어 움직임 스크립트
    private PlayerAttack _playerAttack; // 플레이어 공격 스크립트
    private PlayerInteract _playerInteract; // 플레이어 상호작용 스크립트
    private PlayerSkill _playerSkill;
    private InventoryUI _inventoryUI;
    private ActionBar _actionBar;
    public NavMeshAgent Agent;
    public bool Input { get; set; }


    private void Awake()
    {

        Init();

    }
    public PlayerInput GetPlayerInput()
    {
        return _playerInput;
    }

    private void Init()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        Agent = GetComponent<NavMeshAgent>();

        _playerInput = new PlayerInput();



        _playerAttack = GetComponent<PlayerAttack>();
        _playerInteract = GetComponent<PlayerInteract>();
        _inventoryUI = GameObject.Find("Canvas/Inventory").GetComponent<InventoryUI>();
        _actionBar = GameObject.Find("Canvas/Action bar").GetComponent<ActionBar>();
        _playerSkill = GetComponent<PlayerSkill>();

        _OnInventory = _playerInput.Inventory;
        _OnFloor = _playerInput.OnFloor;
        _OnFloor.Move.performed += ctx => _playerMovement.Move(); //이동
        _OnFloor.Attack.performed += ctx => _playerAttack.Attack(); // 공격
        _OnFloor.Interact.performed += ctx => _playerInteract.OnInteract(); // 상호작용       
        _OnFloor.J_Healing.performed += ctx => _actionBar.HealItem(); // 힐
        _OnFloor.Roll.performed += ctx => _playerMovement.Roll();
        _OnFloor.Q_Skill.performed += ctx => _playerSkill.OnSkill(SkillKey.Q);
        _OnFloor.W_Skill.performed += ctx => _playerSkill.OnSkill(SkillKey.W);
        _OnFloor.E_Skill.performed += ctx => _playerSkill.OnSkill(SkillKey.E);

        _OnInventory.Inventory.performed += ctx => _inventoryUI.Show(); // 인벤토리 open
        _OnInventory.Exit.performed += ctx => _inventoryUI.Hidden();

        Input = false;
    }

    /// <summary>
    /// 입력을 받으면 Input을 True로
    /// </summary>
    public void OnInput()
    {
        Input = true;
    }
    public void OffInput()
    {
        Input = false;
    }

    public void PlayerInputEnable()
    {
        _OnFloor.Enable();
    }
    public void PlayerInputDisable()
    {
        _OnFloor.Disable();

    }

    private void OnEnable()
    {
        _playerInput.Enable();
    }



    private void OnDisable()
    {
        _playerInput.Disable();
    }



}
