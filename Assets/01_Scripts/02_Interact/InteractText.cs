using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class InteractText : MonoBehaviour
{
    private TextMeshPro _text;
    [SerializeField] private float _duration = 1.0f;
 
    private void Awake()
    {
        _text = GetComponent<TextMeshPro>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnText();
          
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OffText();
        }
    }
    public void OnText()
    {
        _text.fontMaterial.DOFloat(0, ShaderUtilities.ID_FaceDilate, _duration);
    }
    public void OffText()
    {
        _text.fontMaterial.DOFloat(-1, ShaderUtilities.ID_FaceDilate, _duration);
    }
}
