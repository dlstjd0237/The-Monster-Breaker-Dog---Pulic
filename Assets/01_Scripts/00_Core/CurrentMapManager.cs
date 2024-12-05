using UnityEngine;
using TMPro;
using DG.Tweening;
public class CurrentMapManager : MonoBehaviour
{
    private TextMeshProUGUI _mainMap;
    private TextMeshProUGUI _subMap;
    [SerializeField] private string _mainText;
    [SerializeField] private string _subText;
    [SerializeField] private float _delay = 1f;
    [SerializeField] private float _startDelay = 3;
    private AudioSource _audio;
    private void Start()
    {
        _audio = GetComponent<AudioSource>();
        _mainMap = transform.Find("MainText").GetComponent<TextMeshProUGUI>();
        _subMap = transform.Find("SubText").GetComponent<TextMeshProUGUI>();
        _mainMap.SetText(_mainText);
        _subMap.SetText("[ " + _subText + " ]");
        Invoke(nameof(OnText), _startDelay);
    }

    public void OnSetText(string mainText, string subText)
    {
        _mainText = mainText;
        _subText = subText;
        _mainMap.SetText(_mainText);
        _subMap.SetText("[ " + _subText + " ]");
        OnText();
    }


    public void OnText()
    {
        Sequence q1 = DOTween.Sequence();
        q1.Append(_mainMap.fontMaterial.DOFloat(0, ShaderUtilities.ID_FaceDilate, 1));
        q1.Join(_subMap.fontMaterial.DOFloat(0, ShaderUtilities.ID_FaceDilate, 1));
        q1.InsertCallback(0f, () => _audio.Play());
        q1.AppendInterval(_delay);
        q1.Append(_mainMap.fontMaterial.DOFloat(-1, ShaderUtilities.ID_FaceDilate, 3));
        q1.Join(_subMap.fontMaterial.DOFloat(-1, ShaderUtilities.ID_FaceDilate, 3));
        q1.OnComplete(() => q1.Kill());
    }
}
