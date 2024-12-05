using System;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObject/SkillDataSO")]



public class SkillDataSO : ScriptableObject
{


    public enum SkillTypeEnum { Passive, Active }
    public enum SKillUsePosEnum { Player, Mouse}
    public SKillUsePosEnum SkillUsePos;
    public SkillTypeEnum SkillType;
    public Quaternion SkiilRoot;
    public string SkillName;
    public int SkillKey;
    public string Info;
    public Sprite Sprite;
    public float UpPower;
    public float UpAttakSpeed;
    public float UpHp;
    public GameObject Effect;
    public float CoolTime;


}
