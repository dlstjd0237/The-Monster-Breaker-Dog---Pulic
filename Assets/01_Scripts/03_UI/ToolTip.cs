using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class ToolTip : MonoBehaviour, IPointerExitHandler
{
    private RectTransform canvasRectTransform;
    [SerializeField] private Button[] _btn;
    private SkillDataSO _currentSkillDataSO;
    private ActionBar _actionBar;

    private void Awake()
    {
        canvasRectTransform = GetComponent<RectTransform>();
        _actionBar = GameObject.Find("Canvas/Action bar").GetComponent<ActionBar>();
    }



    private void Start()
    {
        Hidden();
        _btn[0].onClick.AddListener(SetSkillQ);
        _btn[1].onClick.AddListener(SetSkillW);
        _btn[2].onClick.AddListener(SetSkillE);
    }


    public void ToolBoxShow()
    {
        gameObject.SetActive(true);
        Vector2 anchoredPosition = Input.mousePosition / canvasRectTransform.localScale.x;
        canvasRectTransform.anchoredPosition = anchoredPosition;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Hidden();
    }

    public void Hidden()
    {
        gameObject.SetActive(false);
    }

    public SkillDataSO GetSkillData()
    {
        return _currentSkillDataSO;
    }
    public void SetSkillData(SkillDataSO skillData)
    {
        _currentSkillDataSO = skillData;
        //for (int i = 0; i < 3; i++)
        //{
        //    _btn[i].onClick.RemoveAllListeners();           
        //}
       
    }

    private void SetSkillE()
    {
        _actionBar.EBtnChaneg(_currentSkillDataSO);
    }

    private void SetSkillW()
    {
        _actionBar.WBtnChange(_currentSkillDataSO);

    }

    private void SetSkillQ()
    {
        _actionBar.QBtnChange(_currentSkillDataSO);
    }


}
