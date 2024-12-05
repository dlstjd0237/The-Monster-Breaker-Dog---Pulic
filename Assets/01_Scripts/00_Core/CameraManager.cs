using UnityEngine;
using Cinemachine;
public class CameraManager : MonoSingleton<CameraManager>
{
    private CinemachineVirtualCamera _baseCam;
    private CinemachineBasicMultiChannelPerlin _virtualCam;
    public FollowCam FollowCam;

    private void Awake()
    {
        _baseCam = GetComponent<CinemachineVirtualCamera>();
        FollowCam = GetComponent<FollowCam>();
        _virtualCam = _baseCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    public void FindTarget()
    {
        if (GameObject.Find("Player"))
        {
            FollowCam.Target = GameObject.Find("Player").transform;
        }
        else
        {
            FollowCam.Target = this.transform;
        }

    }

    public void Shake(float time)
    {
        _virtualCam.m_PivotOffset.x = 3;
        _virtualCam.m_PivotOffset.y = 3;
        _virtualCam.m_PivotOffset.z = 3;
        _virtualCam.m_AmplitudeGain = 3;
        _virtualCam.m_FrequencyGain = 3;
        Invoke("offShake", time);
    }
    private void offShake()
    {
        _virtualCam.m_PivotOffset.x = 0;
        _virtualCam.m_PivotOffset.y = 0;
        _virtualCam.m_PivotOffset.z = 0;
        _virtualCam.m_AmplitudeGain = 0;
        _virtualCam.m_FrequencyGain = 0;
    }


}
