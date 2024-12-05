using UnityEngine;
using DG.Tweening;
public class Skillscroll : Interactable
{
    [SerializeField] private Renderer[] _mat;
    [SerializeField] private SkillDataSO _skillDataSO;
    [SerializeField] private InventoryUI _inventoryUI;
    protected override void Interact()
    {
        for (int i = 0; i < _mat.Length; i++)
        {
            _mat[i].material.SetFloat("_Fadein", 1);
            _mat[i].material.DOFloat(0, "_Fadein", 3);
        }
        _inventoryUI.TakeSkiil(_skillDataSO);
        Destroy(gameObject);
    }


}
