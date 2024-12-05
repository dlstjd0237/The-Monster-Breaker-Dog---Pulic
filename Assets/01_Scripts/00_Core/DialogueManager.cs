using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.InputSystem;
using System;

public class DialogueManager : MonoSingleton<DialogueManager>
{
    [SerializeField] private float _textTypingSpeed = 0.15f;
 
    private AudioSource _audioSource;

    #region  툴킷 관련
    private UIDocument _doc;
    private VisualElement _contain;
    private Label _currentSpeakingText;
    private Label _infoText;
    #endregion

    private void Awake()
    {
        Init();
    }

    private void Init()
    {
        _audioSource = GetComponent<AudioSource>();
        _doc = GetComponent<UIDocument>();
        var _root = _doc.rootVisualElement;
        _contain = _root.Q<VisualElement>("contain");
        _currentSpeakingText = _root.Q<Label>("name-label");
        _infoText = _root.Q<Label>("content-label");
    }




    public static void StartDialogue(DialogueData dialogueData) =>
        Instance._StartDialogue(dialogueData, null, null);

    public static void StartDialogue(DialogueData dialogueData, Action startAction, Action endAction) =>
    Instance._StartDialogue(dialogueData, startAction, endAction);


    private void _StartDialogue(DialogueData dialogueData, Action startAction, Action endAction)
    {
        _contain.RemoveFromClassList("off");
        StartCoroutine(SetText(dialogueData.InfoList, startAction, endAction));
    }

    private IEnumerator SetText(List<string> textList, Action startAction, Action endAction)
    {
        InputReader.Instance.OnFloorDisable();
        startAction?.Invoke();
        var Wait = new WaitForSeconds(_textTypingSpeed); //타입핑 속도
        int nameCount = 0;
        for (int i = 0; i < textList.Count / 2; i++)
        {
            _audioSource.Play();
            _currentSpeakingText.text = "";
            string name = textList[nameCount];
            _currentSpeakingText.text = name;
            nameCount++;
            _infoText.text = "";

            string info = textList[nameCount];
            int count = 0;
            while (count != info.Length)
            {
                if (count < info.Length)
                {
                    _infoText.text += info[count].ToString();
                    count++;
                    yield return Wait;
                }
            }
            yield return new WaitUntil(() => Keyboard.current.fKey.wasPressedThisFrame);
            nameCount++;

        }
        _contain.AddToClassList("off");
        endAction?.Invoke();
        InputReader.Instance.OnFloorEnable();

    }
}
