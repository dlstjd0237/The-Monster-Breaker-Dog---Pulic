using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.Events;
public class BossTrigger : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _cam;
    [SerializeField] private DialogueData _dialogueData;
    [SerializeField] private GameObject _boss;
    [SerializeField] private UnityEvent <string,string>_dialogueEndEvent;
    [SerializeField] private string _mainText, _subText;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            DialogueManager.StartDialogue(_dialogueData, () => { _cam.Priority = 11; _cam.LookAt = _boss.transform; }, () => { _cam.Priority = 9; CameraManager.Instance.FollowCam.CameraOffSet(-5, 11, 9); _dialogueEndEvent?.Invoke(_mainText,_subText); });
            gameObject.SetActive(false);
        }
    }
}
