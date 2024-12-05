using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class DamegText : MonoBehaviour
{
    private TextMeshPro _text;
    Color _defultColor;
    private void Awake()
    {
        _text = transform.Find("Text").GetComponent<TextMeshPro>();
    }

    private void OnEnable()
    {
        _defultColor = new Color(1, 1, 1, 1);

        Sequence q1 = DOTween.Sequence();
        q1.Append(transform.DOMoveY(transform.position.y + 4, 3).SetEase(Ease.OutBack));
        q1.Insert(1, _text.DOFade(0, 5).SetEase(Ease.OutExpo));
        q1.OnComplete(() => { gameObject.SetActive(false); });
    }

    private void OnDisable()
    {
        PoolManager.ReturnToPool(gameObject);
        CancelInvoke();
    }

    public void Show(float damge)
    {
        _text.color = _defultColor;
        _text.SetText(damge.ToString());

    }

    public void ShowPlayerDamge(float damge)
    {
        _text.color = Color.red;
        _text.SetText(damge.ToString());
    }

    public void Show(string damge)
    {
        _text.color = new Color(0, 0.3057502f, 0.4245283f, 1);
        _text.SetText(damge);
    }
}
