using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
public class MapUIContorll : MonoBehaviour
{
    private UIDocument _doc;
    private VisualElement _root;
    [SerializeField] private MapData[] _mapdata;
    [SerializeField] private PlayerInputManager _playerInputManager;
    private VisualElement _parentElement;
    private VisualElement _currentElement;
    private VisualElement _fadeElement;
    private Dictionary<int, Button> _stageButton = new Dictionary<int, Button>();
    private Dictionary<string, MapData> _mapDataSO = new Dictionary<string, MapData>();
    private bool _isChoice;
    private Button _exitButton;
    private Button _currentButton;
    private Label _hedeLabel;
    private VisualElement _stageImage;
    private Label _contents;
    private Button _acceptButton;

    private void Awake()
    {
        _doc = GetComponent<UIDocument>();
        _root = _doc.rootVisualElement;

        _playerInputManager = GameObject.Find("Player").GetComponent<PlayerInputManager>();
        _parentElement = _root.Q<VisualElement>("Parent");
        _currentElement = _root.Q<VisualElement>("CurrentMapSet");
        _fadeElement = _root.Q<VisualElement>("Fade");
        _exitButton = _root.Q<Button>("btn-exit");
        _exitButton.RegisterCallback<ClickEvent>(OnEixt);

        _hedeLabel = _root.Q<Label>("lavel-hede");
        _stageImage = _root.Q<VisualElement>("StageImage");
        _contents = _root.Q<Label>("lavel-contents");
        _acceptButton = _root.Q<Button>("btn-accept");
        _acceptButton.RegisterCallback<ClickEvent>(OnAccept);
        for (int i = 1; i < 6; i++)
        {
            Debug.Log(i);
            _stageButton.Add(i, _root.Q<Button>(i.ToString()));
            _stageButton[i].RegisterCallback<ClickEvent>(Choice);
            if (_mapdata[i - 1] != null)
            {
                _mapDataSO.Add(_stageButton[i].name, _mapdata[i - 1]);

            }

        }
    }

    private void OnAccept(ClickEvent evt)
    {
        SceneControlManager.Instance.FadeOut(() => { SceneManager.LoadScene(_mapDataSO[_currentButton.name].LoadSceneName); }) ;
    }

    private void OnEixt(ClickEvent evt)
    {
        if (_isChoice == true)
        {
            HiddenChoice();
        }
        else if (_isChoice == false)
        {
            HiddenMap();
        }
    }

    private void Choice(ClickEvent evt)
    {
        var a = evt.target as Button;
        _isChoice = true;

        _hedeLabel.text = _mapDataSO[a.name].Head;
        _stageImage.style.backgroundImage = _mapDataSO[a.name].Image;
        _contents.text = _mapDataSO[a.name].Body;
       
        _currentButton = a;

        _fadeElement.pickingMode = PickingMode.Position;
        _currentElement.RemoveFromClassList("on");
        _fadeElement.RemoveFromClassList("on");

    }

    private void HiddenChoice()
    {
        _isChoice = false;


        _currentElement.AddToClassList("on");
        _fadeElement.pickingMode = PickingMode.Ignore;
        _fadeElement.AddToClassList("on");
    }


    public void ShowMap()
    {
        _playerInputManager.PlayerInputDisable();
        _currentElement.AddToClassList("on");
        _fadeElement.AddToClassList("on");
        _parentElement.RemoveFromClassList("on");
    }

    private void HiddenMap()
    {
        _playerInputManager.PlayerInputEnable();
        _currentElement.AddToClassList("on");
        _fadeElement.RemoveFromClassList("on");
        _parentElement.AddToClassList("on");
    }




}
