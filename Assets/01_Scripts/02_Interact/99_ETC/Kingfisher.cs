using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.AI;
public class Kingfisher : Interactable
{
    [SerializeField] private DialogueData _dialogueData;
    [SerializeField] private CinemachineVirtualCamera _cam;
    [SerializeField] private GameObject _portal;
    private bool isTalk;


    protected override void Interact()
    {
        if (!isTalk)
        {
            isTalk = true;
            Destroy(transform.Find("Text").gameObject);
            DialogueManager.StartDialogue(_dialogueData, DialogStart, End);
        }
    }


    private void DialogStart()
    {
        _cam.Priority = 11;
        _cam.LookAt = transform;
    }

    private void End()
    {
        _portal.SetActive(true);
        _cam.Priority = 9;
        _cam.LookAt = null;
    }

 
}
