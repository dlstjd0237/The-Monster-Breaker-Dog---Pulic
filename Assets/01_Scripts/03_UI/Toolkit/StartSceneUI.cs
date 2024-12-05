using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using System;

public class StartSceneUI : MonoBehaviour
{
    private UIDocument _doc;

    private Button _startBtn;
    private Button _optionBtn;
    private Button _exitBtn;

    private VisualElement _containDown;

    private VisualElement _newStartContainer;
    private Button _newGameBtn;
    private Button _continueBtn;

    private Label _errorLabel;
    [SerializeField] private string _loadSceneName;
    [SerializeField] private string _newGameSceneName;
    private void Awake()
    {
        _doc = GetComponent<UIDocument>();

        Init();

        _startBtn.clicked += StartBtnOn;
        _newGameBtn.clicked += NewGame;
        _continueBtn.clicked += ContinueGame;
        _exitBtn.clicked += Exit;


    }

    private void Exit()
    {
        SceneControlManager.Instance.FadeOut(() => Application.Quit());
    }

    private void ContinueGame()
    {
        if (DataManager.Instance._nowPlayer.CurrentLevelParameters == 0 && DataManager.Instance._nowPlayer.Level == 1)
        {
            _errorLabel.text = "����� �����Ͱ� �����ϴ�.";
        }
        else
        {
            //DataManager.Instance.InitState();
            SceneControlManager.Instance.FadeOut(() => { SceneManager.LoadScene(_loadSceneName); });

        }
    }

    private void NewGame()
    {
        DataManager.Instance.InitState();
        SceneControlManager.Instance.FadeOut(() => { SceneManager.LoadScene(_newGameSceneName); });
    }

    private void StartBtnOn()
    {
        DownContainOn();
        _newStartContainer.AddToClassList("on");

    }

    private void DownContainOn()
    {
        _containDown.ToggleInClassList("on");
    }


    private void Init()
    {
        var _root = _doc.rootVisualElement;

        _startBtn = _root.Q<Button>("start-btn");    //��ŸƮ ��ư
        _optionBtn = _root.Q<Button>("option-btn");  //�ɼ� ��ư
        _exitBtn = _root.Q<Button>("exit-btn");      //������ ��ư


        _containDown = _root.Q<VisualElement>("contain-down"); //������
        _newStartContainer = _root.Q<VisualElement>("newstartcontain"); //�� ���� �����̳�

        _newGameBtn = _root.Q<Button>("newgame-btn");
        _continueBtn = _root.Q<Button>("continue-btn");

        _errorLabel = _root.Q<Label>("erorr-label");

        _errorLabel.text = "";
    }
}
