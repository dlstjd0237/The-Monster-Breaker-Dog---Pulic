using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;
public class BossHpBar : MonoBehaviour
{
    [SerializeField] private BossDataSO _bossDataSO;
    private float _maxHp;
    private TextMeshProUGUI _bossNameText;
    private Image _hpFill;
    private Image _profill;
    private RectTransform _rectTransform;
    private void Awake()
    {
        _rectTransform = GetComponent<RectTransform>();
        _profill = transform.Find("Icon_1/GameObject/Icon_1Gray").GetComponent<Image>();
        _profill.sprite = _bossDataSO.Icon;
        _bossNameText = transform.Find("BossNameText").GetComponent<TextMeshProUGUI>();
        _bossNameText.SetText(_bossDataSO.BossName);
        _hpFill = transform.Find("Fill").GetComponent<Image>();
        _hpFill.fillAmount =1;
        _maxHp = _bossDataSO.MaxHp;
    }

    public void OnHpBar()
    {
        _rectTransform.DOAnchorPosY(-120, 2);
    }

    public void OffHpBar()
    {
        _rectTransform.DOAnchorPosY(200, 2);
    }


    public void HpBarSet(float currentHp)
    {
        _hpFill.DOFillAmount(currentHp / _maxHp, 0.5f);

    }


}
