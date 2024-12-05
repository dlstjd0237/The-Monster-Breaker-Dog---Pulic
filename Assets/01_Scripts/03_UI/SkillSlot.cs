using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillSlot : MonoBehaviour
{
    public SkillDataSO _currentDataSO;
    private Image _image;
    //private Sprite _currentSprite;
    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void ChangeSlot(SkillDataSO Data)
    {
        _currentDataSO = Data;
        _image.sprite = _currentDataSO.Sprite;
    }
}
