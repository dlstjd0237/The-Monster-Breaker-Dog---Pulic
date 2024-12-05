using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class LvUpText : MonoBehaviour
{
    private TextMeshProUGUI _lvUpText;

    private void Awake()
    {
        _lvUpText = GetComponent<TextMeshProUGUI>();
    }

    public void ShowLvText()
    {

        Sequence q1 = DOTween.Sequence();

        q1.Append(_lvUpText.fontMaterial.DOFloat(0, ShaderUtilities.ID_FaceDilate, 0.5f));
        q1.AppendInterval(2);
        q1.Append(_lvUpText.fontMaterial.DOFloat(-1, ShaderUtilities.ID_FaceDilate, 2));
    }
}
