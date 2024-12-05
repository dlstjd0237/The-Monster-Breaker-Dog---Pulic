using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{
    #region ÇØ½Ì
    private readonly int isRun = Animator.StringToHash("IsRun");
    private readonly int isAttack = Animator.StringToHash("IsAttack");
    private readonly int isHit = Animator.StringToHash("IsHit");
    private readonly int isDie = Animator.StringToHash("IsDie");
    #endregion

    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void IdleAniamtion()
    {
        _animator.SetBool(isRun, false);
    }

    public void Run()
    {
        _animator.SetBool(isRun, true);
    }

    public void Attack()
    {
        _animator.SetTrigger(isAttack);
    }
    public void Hit()
    {
        _animator.SetTrigger(isHit);
    }
    public void DIe()
    {
        _animator.SetTrigger(isDie);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }

}
