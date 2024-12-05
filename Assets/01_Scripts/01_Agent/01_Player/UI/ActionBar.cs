using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using UnityEngine.Events;
using System;

public class ActionBar : MonoBehaviour
{
    private PlayerState _playerState;
    private float _maxLvParameters;
    private float _currentLvParameters;
    [SerializeField] private UnityEvent _lvUp;
    [SerializeField] private TextMeshProUGUI _lvText;
    [SerializeField] private TextMeshProUGUI _currentLvParametersText;
    [SerializeField] private Image _lvFill;
    [SerializeField] private Image _hpFill;
    [SerializeField] private List<Image> _skillImage;
    private SkillDataSO _currentQSkillDataSO;
    private SkillDataSO _currentWSkillDataSO;
    private SkillDataSO _currentESkillDataSO;
    public SkillKey SkillKeyBord;

    private Color _hidenColor, _showColor;

    private TextMeshProUGUI _healCoolTimeText;
    private float _healtimer = 30;
    private Image _healFadeImgae;
    private bool _healCheak;



    private void Awake()
    {
        _playerState = GameObject.Find("Player").GetComponent<PlayerState>();
        _hidenColor = new Color(1, 1, 1, 0);
        _showColor = new Color(1, 1, 1, 1);

        _healCoolTimeText = transform.Find("Skill1/Timer").GetComponent<TextMeshProUGUI>();
        _healFadeImgae = transform.Find("Skill1/FadeIn").GetComponent<Image>();
        _healFadeImgae.fillAmount = 0;
        _healCoolTimeText.SetText("");
    }

    private void Start()
    {
        LevelSet();
    }



    private void LevelSet()
    {
        _playerState.Lv = DataManager.Instance._nowPlayer.Level;
        //_currentLvParameters = _playerState.CurrentLevelParameters;

        _lvText.SetText($"{ _playerState.Lv.ToString()}LV");

        Debug.Log(DataManager.Instance._nowPlayer.CurrentLevelParameters);
        Debug.Log(_playerState.CurrentLevelParameters);
        _currentLvParameters = _playerState.CurrentLevelParameters;
        _maxLvParameters = DataManager.Instance._nowPlayer.MaxLevelParameters;
        _lvFill.fillAmount = _currentLvParameters / _maxLvParameters;
        _currentLvParametersText.SetText($"{_currentLvParameters}/{_maxLvParameters}");

    }

    public void LevelParameterSet(float Exp)//경험치를 얻는 메서드
    {
        _currentLvParameters += Exp;// 경험치 얻음
        DataManager.Instance._nowPlayer.CurrentLevelParameters = _currentLvParameters; //얻은 경험치 저장
        if (_currentLvParameters >= _maxLvParameters)// 만약 최대 경험치량 넘으면 레벨업
        {
            _playerState.Lv += 1; //레벨업
            DataManager.Instance._nowPlayer.Level = _playerState.Lv;//레벨업 저장

            _lvText.SetText($"LV{ _playerState.Lv.ToString()}"); //레벨 표시
            _currentLvParameters = 0; //경험치량 0으로 초기화

            _maxLvParameters += 700;// 경험치 최대량 증가
            DataManager.Instance._nowPlayer.MaxLevelParameters = _maxLvParameters;//경험치 최대량 저장

            DataManager.Instance._nowPlayer.AttackPower += 8; //공격력 증가

            DataManager.Instance._nowPlayer.MaxHp += 55;
            DataManager.Instance._nowPlayer.CurrentHp = DataManager.Instance._nowPlayer.MaxHp;

            DataManager.Instance._nowPlayer.DefensePercentage += 1;

            _lvUp?.Invoke(); // 레벨업 시 일어날 이벤트 ex)레벨업 텍스트

        }
        _lvFill.DOFillAmount(_currentLvParameters / _maxLvParameters, 2);
        _currentLvParametersText.SetText($"{_currentLvParameters}/{_maxLvParameters}");
        DataManager.Instance.SaveData();

    }


    private void Update()
    {
        _hpFill.fillAmount = DataManager.Instance._nowPlayer.CurrentHp / DataManager.Instance._nowPlayer.MaxHp;
    }


    public void QBtnChange(SkillDataSO skillData)
    {
        if (skillData == _currentWSkillDataSO || skillData == _currentESkillDataSO)
            return;



        if (_currentQSkillDataSO is null)
        {
            AddskillStatSet(skillData);
        }
        else if (_currentQSkillDataSO is not null)
        {
            RemoveskillStatSet(_currentQSkillDataSO);
            AddskillStatSet(skillData);
        }


        try
        {
            _currentQSkillDataSO = skillData;
            _skillImage[0].sprite = _currentQSkillDataSO.Sprite;
            _skillImage[0].color = _showColor;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }

    }
    public void WBtnChange(SkillDataSO skillData)
    {
        if (skillData == _currentQSkillDataSO || skillData == _currentESkillDataSO)
            return;

        if (_currentWSkillDataSO is null)
        {
            AddskillStatSet(skillData);
        }
        else if (_currentWSkillDataSO is not null)
        {
            RemoveskillStatSet(_currentWSkillDataSO);
            AddskillStatSet(skillData);
        }

        try
        {
            _currentWSkillDataSO = skillData;
            _skillImage[1].sprite = _currentWSkillDataSO.Sprite;
            _skillImage[1].color = _showColor;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }
    public void EBtnChaneg(SkillDataSO skillData)
    {
        if (skillData == _currentWSkillDataSO || skillData == _currentQSkillDataSO)
            return;

        if (_currentESkillDataSO is null)
        {
            AddskillStatSet(skillData);
        }
        else if (_currentESkillDataSO is not null)
        {
            RemoveskillStatSet(_currentESkillDataSO);
            AddskillStatSet(skillData);
        }
        try
        {
            _currentESkillDataSO = skillData;
            _skillImage[2].sprite = _currentESkillDataSO.Sprite;
            _skillImage[2].color = _showColor;
        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public void HealItem()
    {
        if (_healCheak == false)
        {
            _healCheak = true;
            StartCoroutine(HealCoroutine());


        }
    }
    private IEnumerator HealCoroutine()
    {
        _healtimer = 30;
        DataManager.Instance._nowPlayer.CurrentHp += DataManager.Instance._nowPlayer.MaxHp / 4;
        if (DataManager.Instance._nowPlayer.CurrentHp > DataManager.Instance._nowPlayer.MaxHp)
        {
            DataManager.Instance._nowPlayer.CurrentHp = DataManager.Instance._nowPlayer.MaxHp;
        }
        var Wait = new WaitForSeconds(1);

        while (_healtimer >= 0)
        {
            _healtimer -= 1;
            _healFadeImgae.fillAmount = _healtimer / 30;
            yield return Wait;
        }
        _healtimer = 0;
        _healFadeImgae.fillAmount = _healtimer / 30;
        _healCheak = false;
    }



    private void AddskillStatSet(SkillDataSO SO)
    {
        if (SO != null)
        {

            DataManager.Instance._nowPlayer.AttackPower += (int)SO.UpPower;
            DataManager.Instance._nowPlayer.AttackSpeed += (int)SO.UpAttakSpeed;
            DataManager.Instance._nowPlayer.MaxHp += (int)SO.UpHp;
        }

    }
    private void RemoveskillStatSet(SkillDataSO SO)
    {
        DataManager.Instance._nowPlayer.AttackPower -= (int)SO.UpPower;
        DataManager.Instance._nowPlayer.AttackSpeed -= (int)SO.UpAttakSpeed;
        DataManager.Instance._nowPlayer.MaxHp -= (int)SO.UpHp;

    }

    public SkillDataSO GetSkillData(SkillKey skillKey)
    {
        switch (skillKey)
        {
            case SkillKey.Q:
                return _currentQSkillDataSO;

            case SkillKey.W:
                return _currentWSkillDataSO;

            case SkillKey.E:
                return _currentESkillDataSO;

        }
        return null;

    }
}
