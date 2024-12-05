using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    private bool _isShow;
    private RectTransform _rectTrm;
    private PlayerInputManager _playerInputManager;
    [SerializeField] private List<ItemSlot> _itemSlot;

    AudioSource asdf;

    private Image _skillimage;
    private TextMeshProUGUI _effectText;

    private TextMeshProUGUI _swordLvText; // 무기 레벨 텍스트
    private TextMeshProUGUI _shieldLvText; // 쉴드 레벨 텍스트
    private TextMeshProUGUI _swordPowerText; // 무기 공격력 텍스트
    private TextMeshProUGUI _shieldPowerText; // 쉴드 공격력 테스트
    private TextMeshProUGUI _swordLvUpCostText; //무기 레벨업 코스트
    private TextMeshProUGUI _shieldLvUpCostText; //쉴드 레벨업 코스트

    private TextMeshProUGUI _currentCoinText; //현재 가지고 있는 코인수

    private void Awake()
    {
        Init();

        _swordLvUpCostText.SetText((DataManager.Instance._nowPlayer.WeaponUpgradeStack * 120).ToString());
        _shieldLvUpCostText.SetText((DataManager.Instance._nowPlayer.ShieldUpgradeStack * 260).ToString());
    }

    private void Start()
    {
        SetUpgradeText();
        SkillLoadSet();
    }

    private void SkillLoadSet()
    {
        for (int i = 0; i < DataManager.Instance._nowPlayer.SkillKeyValue.Count; ++i)
        {
            InventorySaveDataLoad(DataManager.Instance.SkillDictionary[DataManager.Instance._nowPlayer.SkillKeyValue[i]]);
          

        }
    }

    private void Init()
    {
        _playerInputManager = GameObject.Find("Player").GetComponent<PlayerInputManager>();
        _rectTrm = GetComponent<RectTransform>();
        _skillimage = transform.Find("ItemProfile/ItemProfileImgae").GetComponent<Image>();
        _effectText = transform.Find("ItemProfile/Image/EffectText").GetComponent<TextMeshProUGUI>();

        _swordLvText = transform.Find("SwordWindow/WeaponText/WeaponLvText/WeaponLv").GetComponent<TextMeshProUGUI>();
        _swordPowerText = transform.Find("SwordWindow/WeaponText/WeaponDamgeText/WeaponDamge").GetComponent<TextMeshProUGUI>();
        _swordLvUpCostText = transform.Find("SwordWindow/WeaponText/WeaponCoinText/WeaponCoin").GetComponent<TextMeshProUGUI>();
        _shieldLvText = transform.Find("ShieldWindow/WeaponText/WeaponLvText/WeaponLv").GetComponent<TextMeshProUGUI>();
        _shieldPowerText = transform.Find("ShieldWindow/WeaponText/WeaponDamgeText/WeaponDamge").GetComponent<TextMeshProUGUI>();
        _shieldLvUpCostText = transform.Find("ShieldWindow/WeaponText/WeaponCoinText/WeaponCoin").GetComponent<TextMeshProUGUI>();
        _currentCoinText = transform.Find("Status/Text/Coin/CoinValue").GetComponent<TextMeshProUGUI>();
    }

    public void Show()
    {
        if (_isShow == true)
        {
            Sequence q1 = DOTween.Sequence();
            q1.Append(_rectTrm.DOScale(new Vector3(0.5f, 0.5f, 1), 0.6f).SetEase(Ease.InOutBack));
            q1.AppendCallback(() => _rectTrm.localScale = new Vector3(0, 0, 0));
            q1.OnComplete(() => { q1.Kill(); });
            _isShow = false;
            _playerInputManager.PlayerInputEnable();
        }
        else if (_isShow == false)
        {
            Sequence q1 = DOTween.Sequence();
            _rectTrm.localScale = new Vector3(0.5f, 0.5f, 1);

            q1.Append(_rectTrm.DOScale(new Vector3(1.5f, 1.5f, 1), 0.6f).SetEase(Ease.InOutBack));

            _isShow = true; ;
            _playerInputManager.PlayerInputDisable();
        }


    }

    public void Hidden()
    {
        if (_isShow == true)
        {
            Sequence q1 = DOTween.Sequence();
            q1.Append(_rectTrm.DOScale(new Vector3(0.5f, 0.5f, 1), 0.6f).SetEase(Ease.InOutBack));
            q1.AppendCallback(() => _rectTrm.localScale = new Vector3(0, 0, 0));
            q1.OnComplete(() => { q1.Kill(); });
            _isShow = false;
            _playerInputManager.PlayerInputEnable();
        }
    }

    public void TakeSkiil(SkillDataSO takeSkillDataSO)
    {
        if (DataManager.Instance.SKillDuplicatedChake(takeSkillDataSO))
        {
            return;
        }
        _itemSlot[nullSlot()].TakeSkill(takeSkillDataSO);
    }

    public void InventorySaveDataLoad(SkillDataSO takeSkillDataSO)
    {
        if (DataManager.Instance.SKillInventoryDuplicatedChake(takeSkillDataSO))
        {
            return;
        }
        _itemSlot[nullSlot()].TakeSkill(takeSkillDataSO);
    }
    private int nullSlot()
    {
        for (int i = 0; i < _itemSlot.Count; i++)
        {
            if (_itemSlot[i].CurrentSkillDataSO is null)
            {

                return i;
            }
        }
        return 0;
    }

    public void SkillChoice(SkillDataSO _skillDataSO)
    {
        _skillimage.color = new Color(1, 1, 1, 1);
        _skillimage.sprite = _skillDataSO.Sprite;
        _effectText.SetText($"{_skillDataSO.SkillName}\n{_skillDataSO.Info}");
    }
    public void UpgradeSword()
    {
        if (DataManager.Instance._nowPlayer.Coin > DataManager.Instance._nowPlayer.WeaponUpgradeStack * 120)
        {
            DataManager.Instance._nowPlayer.Coin -= DataManager.Instance._nowPlayer.WeaponUpgradeStack * 120;
            SetCoin();
            DataManager.Instance._nowPlayer.WeaponUpgradeStack += 1;
            DataManager.Instance._nowPlayer.WeaponPower += 8;
            DataManager.Instance.SaveData();
            SetUpgradeText();
        }
    }
    public void UpgradeShield()
    {
        if (DataManager.Instance._nowPlayer.Coin > DataManager.Instance._nowPlayer.ShieldUpgradeStack * 260)
        {
            DataManager.Instance._nowPlayer.Coin -= DataManager.Instance._nowPlayer.ShieldUpgradeStack * 260;
            SetCoin();
            DataManager.Instance._nowPlayer.ShieldUpgradeStack += 1;
            DataManager.Instance._nowPlayer.ShieldPower += 1;
            DataManager.Instance.SaveData();
            SetUpgradeText();
        }
    }

    private void SetUpgradeText()
    {
        _swordLvText.SetText($"{DataManager.Instance._nowPlayer.WeaponUpgradeStack.ToString()} >> {(DataManager.Instance._nowPlayer.WeaponUpgradeStack + 1).ToString()}");
        _swordPowerText.SetText($"{DataManager.Instance._nowPlayer.WeaponPower.ToString()} >> {(DataManager.Instance._nowPlayer.WeaponPower + 4).ToString()}");


        _shieldLvText.SetText($"{DataManager.Instance._nowPlayer.ShieldUpgradeStack.ToString()} >> { (DataManager.Instance._nowPlayer.ShieldUpgradeStack + 1).ToString()}");
        _shieldPowerText.SetText($"{DataManager.Instance._nowPlayer.ShieldPower.ToString()} >> {(DataManager.Instance._nowPlayer.ShieldPower + 0.5).ToString()}");

        _swordLvUpCostText.SetText((DataManager.Instance._nowPlayer.WeaponUpgradeStack * 120).ToString());
        _shieldLvUpCostText.SetText((DataManager.Instance._nowPlayer.ShieldUpgradeStack * 260).ToString());
    }

    public void SetCoin()
    {
        _currentCoinText.SetText(DataManager.Instance._nowPlayer.Coin.ToString());
    }
}
