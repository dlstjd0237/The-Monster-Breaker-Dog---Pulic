using UnityEngine;
using DG.Tweening;
public class DotweenCapacitySetup : MonoBehaviour
{
    private void Awake()
    {
        DOTween.SetTweensCapacity(1500, 200);
    }
}
