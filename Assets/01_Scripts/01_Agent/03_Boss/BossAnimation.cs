using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAnimation : MonoBehaviour
{
    #region 애니메이션 해싱
    private readonly int isWake = Animator.StringToHash("IsWake");
    private readonly int isCurrentSpeed = Animator.StringToHash("Speed");
    private readonly int isShouting = Animator.StringToHash("IsShouting");
    private readonly int isAttack = Animator.StringToHash("IsAttack");
    private readonly int isSpin = Animator.StringToHash("IsSpin");
    private readonly int isDie = Animator.StringToHash("IsDie");
    #endregion






    private Animator _animator;
    private Rigidbody _rig;
    private bool _isDIe;
    private void Awake()
    {
        _animator = GetComponentInParent<Animator>();
        _rig = GetComponentInParent<Rigidbody>();
        Invoke("OnWakeUp", 2);
    }



    private bool DieChake()
    {
        if (_isDIe)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public void OnWakeUp()
    {
        if (DieChake())
            return;
        _animator.SetBool(isWake, true);
    }

    public void OnSpin()
    {
        if (DieChake())
            return;
        _animator.SetBool(isSpin, true);
    }
    public void OffSpin()
    {
        if (DieChake())
            return;
        _animator.SetBool(isSpin, false);
    }

    public void OnRun()
    {
        if (DieChake())
            return;
        _animator.SetFloat(isCurrentSpeed, 1);
    }

    public void OnIdle()
    {
        if (DieChake())
            return;
        _animator.SetFloat(isCurrentSpeed, 0);
    }
    public void OnShouting()
    {
        if (DieChake())
            return;
        _animator.SetTrigger(isShouting);
    }

    public void OnAttack()
    {
        if (DieChake())
            return;
        _animator.SetTrigger(isAttack);
    }

    public void Die()
    {
        _animator.SetTrigger(isDie);
        _isDIe = true;  
    }

}
