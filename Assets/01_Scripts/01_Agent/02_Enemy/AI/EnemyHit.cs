using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour,IDamage
{
    private Enemy _enemy;
    private EnemyDead _enemyDead;
    private EnemyHealthbar _enemyHealthbar;
    [SerializeField] private Material _hitMat, _parryingMat;
    private Material _defultMat;
    [SerializeField] private Renderer _renderer;
    private void Awake()
    {
        _enemy = GetComponentInParent<Enemy>();
        _enemyDead = GetComponent<EnemyDead>();
        _enemyHealthbar = transform.Find("HpCanvas").GetComponent<EnemyHealthbar>();
        _defultMat = _renderer.material;
    }

    public void ParryingTakeDamge(float Damge)
    {
        _enemy.CurrentHp -= Damge;
        _enemyHealthbar.UpdateHealthbar(_enemy.CurrentHp / _enemy.MaxHp);

        GameObject qwer = PoolManager.SpawnFromPool("DamageText", new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f), transform.position.y, transform.position.z + Random.Range(-0.5f, 0.5f)), Quaternion.Euler(50, 147, 0));
        qwer.GetComponent<DamegText>().Show(Damge.ToString());


        if (_enemy.CurrentHp <= 0)
        {
            _enemy.EnemyState = Enemy.MonsterState.Dead;
            _enemy.IsDie = true;
            _enemyDead.Dead(_enemy.transform.position);
            return;

        }
        StartCoroutine(HitSetMat(_parryingMat));
    }

    private IEnumerator HitSetMat(Material material)
    {
        CameraManager.Instance.Shake(0.3f);
        _renderer.material = material;
        yield return new WaitForSeconds(0.2f);
        _renderer.material = _defultMat;
    }

    public void TakeDamage(float damage)
    {
        PoolManager.SpawnFromPool("EnemyHitSound", transform.position);
        _enemy.CurrentHp -= damage;
        _enemyHealthbar.UpdateHealthbar(_enemy.CurrentHp / _enemy.MaxHp);

        GameObject qwer = PoolManager.SpawnFromPool("DamageText", new Vector3(transform.position.x + Random.Range(-0.3f, 0.3f), transform.position.y, transform.position.z + Random.Range(-0.5f, 0.5f)), Quaternion.Euler(50, 147, 0));
        qwer.GetComponent<DamegText>().Show(damage);



        if (_enemy.CurrentHp <= 0)
        {
            _enemy.EnemyState = Enemy.MonsterState.Dead;
            _enemy.IsDie = true;
            _enemyDead.Dead(_enemy.transform.position);
            return;

        }
        StartCoroutine(HitSetMat(_hitMat));
    }
}
