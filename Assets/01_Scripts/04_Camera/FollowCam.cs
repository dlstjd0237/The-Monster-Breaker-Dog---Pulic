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
    /// ī�޶� ������ ���� ����
    /// </summary>
    /// <param name="x">����Ʈ �� : -3, ������ �� : -6.5</param>
    /// <param name="y">����Ʈ �� : 8, ������ �� : 14</param>
    /// <param name="z">����Ʈ �� : 5, ������ �� : 11</param>
    public void CameraOffSet(float x, float y, float z)
    {
        DOTween.To(() => _offset, x => _offset = x, new Vector3(x, y, z), 3);
    }

  
}
