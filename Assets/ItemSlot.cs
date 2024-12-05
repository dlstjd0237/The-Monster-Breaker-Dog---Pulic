using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    private ToolTip _tooltip;
    private Image _icon;
    private InventoryUI _inventoryUI;
    [HideInInspector] public SkillDataSO CurrentSkillDataSO;

    private void Awake()
    {
        _tooltip = GameObject.Find("Canvas/ToolBox").GetComponent<ToolTip>();
        _icon = GetComponent<Image>();
        _inventoryUI = transform.parent.parent.parent.GetComponent<InventoryUI>();

    }

    public void TakeSkill(SkillDataSO takeSkillDataSO)
    {
        Debug.Log("ø©±‚±Ó¡ˆø»");
        CurrentSkillDataSO = takeSkillDataSO;
        DataManager.Instance.SkillChake(CurrentSkillDataSO);
        _icon.color = new Color(_icon.color.r, _icon.color.g, _icon.color.b, 1);
        _icon.sprite = takeSkillDataSO.Sprite;
        Debug.Log("¿Ã±Ó¡ˆµı");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            _tooltip.ToolBoxShow();

            _tooltip.SetSkillData(CurrentSkillDataSO);


        }
        if (eventData.button == PointerEventData.InputButton.Left && CurrentSkillDataSO is not null)
        {
            Debug.Log("≈¨∏Ø¿∫ µ ");
            _inventoryUI.SkillChoice(CurrentSkillDataSO);
        }
    }



}
