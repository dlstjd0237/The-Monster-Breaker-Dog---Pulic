using UnityEngine;
using System.IO;
using System.Collections.Generic;
using System;

public class PlayerData
{
    public int Level;
    public float MaxLevelParameters;
    public float CurrentLevelParameters;
    public int Coin;
    public int WeaponUpgradeStack;
    public int WeaponPower;
    public int ShieldUpgradeStack;
    public float ShieldPower;
    public int AttackPower;
    public float DefensePercentage;
    public float MaxHp;
    public float CurrentHp;
    public float AttackSpeed;
    public List<int> SkillKeyValue;
    public bool Continue;
}


public class DataManager : MonoSingleton<DataManager>
{
    public PlayerData _nowPlayer = new PlayerData();
    public Dictionary<int, SkillDataSO> SkillDictionary = new();
    [SerializeField] private SkillDataSOList _skillDataSOList;
    private string path;
    private string filename = "save";
    private void Awake()
    {
        path = Application.persistentDataPath + "/";//��� ����
        Debug.Log(path);
        LoadData();
        if (_nowPlayer.Level == 0)
        {
            InitState();
        }
        SkillDataDictionarySet();


    }

    private void SkillDataDictionarySet()
    {
        for (int i = 0; i < _skillDataSOList.SkillSOList.Count; i++)
        {
            SkillDictionary.Add(_skillDataSOList.SkillSOList[i].SkillKey, _skillDataSOList.SkillSOList[i]);
        }
    }

    public void InitState()
    {

        _nowPlayer.Level = 1;
        _nowPlayer.MaxHp = 50;
        _nowPlayer.MaxLevelParameters = 1000;
        _nowPlayer.CurrentLevelParameters = 0;
        _nowPlayer.AttackPower = 7;
        _nowPlayer.CurrentHp = _nowPlayer.MaxHp;
        _nowPlayer.DefensePercentage = 5;
        _nowPlayer.WeaponPower = 1;
        _nowPlayer.WeaponUpgradeStack = 1;
        _nowPlayer.ShieldPower = 1;
        _nowPlayer.ShieldUpgradeStack = 1;
        _nowPlayer.AttackSpeed = 2;
        _nowPlayer.Continue = true;
        _nowPlayer.SkillKeyValue = new();
        _nowPlayer.Coin = 0;
        SaveData();

    }

    public void SaveData()
    {
        Debug.Log("�����");
        string data = JsonUtility.ToJson(_nowPlayer);
        File.WriteAllText(path + filename, data);
    }

    public void LoadData()
    {
        string data = File.ReadAllText(path + filename);
        _nowPlayer = JsonUtility.FromJson<PlayerData>(data);
    }

    public void SkillChake(SkillDataSO skillDataSO)
    {
        for (int i = 0; i < _nowPlayer.SkillKeyValue.Count; i++)
        {
            if (_nowPlayer.SkillKeyValue[i] == skillDataSO.SkillKey)
            {
                return;
            }
        }
        _nowPlayer.SkillKeyValue.Add(skillDataSO.SkillKey);
    }


    /// <summary>
    /// �̹� ���� ��ų�ΰ�?
    /// ��ų ������ ���°�
    /// </summary>
    /// <param name="skillDataSO"></param>
    /// <returns></returns>
    public bool SKillDuplicatedChake(SkillDataSO skillDataSO)
    {

        for (int i = 0; i < _nowPlayer.SkillKeyValue.Count; i++)
        {
            if (_nowPlayer.SkillKeyValue[i] == skillDataSO.SkillKey)//���� �����Ϳ� ���� ������ ��ų �����Ϳ� ������ ��
            {
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// �κ��丮 �ε��Ҷ� ��ų üũ
    /// </summary>
    /// <param name="skillDataSO"></param>
    /// <returns></returns>
    public bool SKillInventoryDuplicatedChake(SkillDataSO skillDataSO)
    {

        for (int i = 0; i < _nowPlayer.SkillKeyValue.Count; i++)
        {
            if (_nowPlayer.SkillKeyValue[i] == skillDataSO.SkillKey)//���� �����Ϳ� ���� ������ ��ų �����Ϳ� ������ ��
            {
                return false;
            }
        }
        return true;
    }


}
