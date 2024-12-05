using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
public class SceneControlManager : MonoSingleton<SceneControlManager>
{
    private Image _image = null;
    private Color _cr;
    private float _fadeCool = 2; public float FadeCool { get => _fadeCool; set => _fadeCool = value; }
    private void Awake()    
    {
        _image = transform.Find("Canvas/FadeImage").GetComponent<Image>();
       
    }
    private void Start()
    {
        FadeIn(null);

    }

    /// <summary>
    /// 1=>0
    /// </summary>
    /// <param name="action"></param>
    public void FadeIn(Action action)
    {
        StartCoroutine(fadeIn(action));
    }
    private IEnumerator fadeIn(Action action)
    {
        _cr = _image.color;
        while (_image.color.a >= 0)
        {
            _cr.a -= Time.deltaTime / _fadeCool;
            _image.color = _cr;
            yield return null;
        }
        action?.Invoke();
    }

    /// <summary>
    /// 0=>1
    /// </summary>
    /// <param name="action"></param>
    public void FadeOut(Action action)
    {
        StopAllCoroutines();
        StartCoroutine(fadeOut(action));
    }
    private IEnumerator fadeOut(Action action)
    {
        _cr = _image.color;
        while (_image.color.a <= 1)
        {
            _cr.a += Time.deltaTime / _fadeCool;
            _image.color = _cr;
            yield return null;
        }
        action?.Invoke();
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        CameraManager.Instance.FindTarget();
        DataManager.Instance._nowPlayer.CurrentHp = DataManager.Instance._nowPlayer.MaxHp;
        DataManager.Instance.SaveData();
        FadeIn(()=> { });
        InputReader.Instance.FindInputManager();
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
