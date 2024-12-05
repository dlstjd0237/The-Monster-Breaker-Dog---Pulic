using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using DG.Tweening;
public class FollowCam : MonoBehaviour
{

    public Transform Target;
    [SerializeField] private Vector3 _offset;
    private CinemachineVirtualCameraBase _baseCam;

    private void Awake()
    {
        //Target = null;
    }

    private void Update()
    {
        if (Target is not null)
            transform.position = Target.position + _offset;
    }

    /// <summary>
    /// 카메라 오프셋 설정 가능
    /// </summary>
    /// <param name="x">디폴트 값 : -3, 보스전 값 : -6.5</param>
    /// <param name="y">디폴트 값 : 8, 보스전 값 : 14</param>
    /// <param name="z">디폴트 값 : 5, 보스전 값 : 11</param>
    public void CameraOffSet(float x, float y, float z)
    {
        DOTween.To(() => _offset, x => _offset = x, new Vector3(x, y, z), 3);
    }

  
}
