using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum SkillKey
{
    Q,
    W,
    E
}
public class PlayerSkill : MonoBehaviour
{
    private PlayerAnimationControl _ani;
    private Camera _mainCam;
    private int _floor;
    private ActionBar _actionBar;
    [SerializeField] GameObject a;
    private SkillDataSO skillDataSO;
    private void Awake()
    {
        _ani = transform.GetComponent<PlayerAnimationControl>();
        _mainCam = Camera.main;
        _floor = (-1) - (1 << LayerMask.NameToLayer("Decoration"));
        _actionBar = GameObject.Find("Canvas/Action bar").GetComponent<ActionBar>();
    }
    public void OnSkill(SkillKey skillKey)
    {
        switch (skillKey)
        {
            case SkillKey.Q:
                skillDataSO = _actionBar.GetSkillData(SkillKey.Q);
                break;
            case SkillKey.W:
                skillDataSO = _actionBar.GetSkillData(SkillKey.W);
                break;
            case SkillKey.E:
                skillDataSO = _actionBar.GetSkillData(SkillKey.E);
                break;
        }
        Ray ray = _mainCam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, _floor))
        {

            //Instantiate(a, hit.point, Quaternion.identity);
            try
            {

                if (skillDataSO.SkillUsePos == SkillDataSO.SKillUsePosEnum.Player)
                {
                    PoolManager.SpawnFromPool(skillDataSO.SkillKey.ToString(), transform.position, skillDataSO.SkiilRoot);
                }
                else if (skillDataSO.SkillUsePos == SkillDataSO.SKillUsePosEnum.Mouse)
                {
                    PoolManager.SpawnFromPool(skillDataSO.SkillKey.ToString(), hit.point, skillDataSO.SkiilRoot);
                }
                _ani.OnSkillAni();
            }
            catch (Exception)
            {
                _ani.OnSkillAni();
            }
        }



    }
}
