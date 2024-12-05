using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class EnemyDead : MonoBehaviour
{
    private Enemy _enemy;
    private Collider _collider;
    private NavMeshAgent _agent;
    private EnemyAnimator _animator;
    private ActionBar _actionbar;
    private InventoryUI _inventoryUI;
    private void OnEnable()
    {
        _actionbar = GameObject.Find("Canvas/Action bar")?.GetComponent<ActionBar>();
        _inventoryUI = GameObject.Find("Canvas/Inventory")?.GetComponent<InventoryUI>();
    }
    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        _collider = GetComponent<Collider>();
        _agent = GetComponentInParent<NavMeshAgent>();
        _animator = _enemy.GetComponent<EnemyAnimator>();
     
    }
    public void Dead(Vector3 dir)
    {
        _collider.enabled = false;
        _agent.SetDestination(dir);
        _animator.DIe();
        _actionbar.LevelParameterSet(_enemy.DropExp);
        DataManager.Instance._nowPlayer.Coin += Random.Range(_enemy.DropGoldMin, _enemy.DropGoldMax);
    }
}
