using Cinemachine;
using UnityEngine;
using UnityEngine.Events;
public class TalkTrigger : Interactable
{
    [SerializeField] private CinemachineVirtualCamera _cam;
    [SerializeField] private UnityEvent StartDialogEvent, EndDialogEvent;
    [SerializeField] private DialogueData _dialogueData;

    protected override void Interact()
    {
        Destroy(transform.Find("Text").gameObject);
        DialogueManager.StartDialogue(_dialogueData, DialogStart, DialogEnd);
    }

    private void DialogStart()
    {
        StartDialogEvent?.Invoke();
        _cam.LookAt = transform;
        _cam.Priority = 11;
    }
    private void DialogEnd()
    {
        EndDialogEvent?.Invoke();
        _cam.LookAt = null;
        _cam.Priority = 9;
        gameObject.SetActive(false);
    }
}
