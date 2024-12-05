using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class TitleControl : MonoBehaviour
{
    [SerializeField] private List<TextMeshPro> _titleText = new List<TextMeshPro>();
    [SerializeField] private TextMeshProUGUI _toych;
    [SerializeField] private string LoadSceneName= "InGameLobby";
    [SerializeField] private List<Renderer> _renderer = new List<Renderer>();
    [SerializeField] private Material _mtrlDissolve;
    [SerializeField] private float _tweeningTime = 3;
    private Color _cr;
    private Animator _animator;
    private bool _isTitle;
    private float Duraion = 3;
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        for (int i = 0; i < _renderer.Count; i++)
        {
            _renderer[i].material = _mtrlDissolve;

        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _isTitle == false)
        {
            _animator.speed = 1000;
        } else if (Input.GetMouseButtonDown(0) && _isTitle == true)
        {
            SceneControlManager.Instance.FadeOut(() => SceneManager.LoadScene(LoadSceneName));
        }
    }

    public void OnTitle()
    {
        _isTitle = true;
        for (int i = 0; i < _titleText.Count; i++)
        {
            _titleText[i].fontMaterial.DOFloat(0, ShaderUtilities.ID_FaceDilate, Duraion);
        }
        for (int i = 0; i < _renderer.Count; i++)
        {
            _renderer[i].material.SetFloat("_Fadein", 0);
            _renderer[i].material.DOFloat(1, "_Fadein", _tweeningTime);
        }
        StartCoroutine(TextFadeOut());
    }

    private IEnumerator TextFadeOut()
    {
        _cr = _toych.color;
        while (_toych.color.a <= 1)
        {
            _cr.a += Time.deltaTime / 2f;
            _toych.color = _cr;
            yield return null;
        }
        StartCoroutine(TextFadeIn());
    }
    private IEnumerator TextFadeIn()
    {
        _cr = _toych.color;
        while (_toych.color.a >= 0)
        {
            _cr.a -= Time.deltaTime / 2f;
            _toych.color = _cr;
            yield return null;
        }
        StartCoroutine(TextFadeOut());
    }

}
