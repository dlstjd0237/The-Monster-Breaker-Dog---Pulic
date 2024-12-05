using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueData _dialogData;
    [SerializeField] private UnityEvent _dialogEvent;
    [SerializeField] private Transform _target;
    [SerializeField] private CinemachineVirtualCamera _cam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_target != null)
            {
                DialogueManager.StartDialogue(_dialogData, () => { _cam.Priority = 11; _cam.LookAt = _target; },
                    () => { _cam.Priority = 9; _cam.LookAt = null; });

            }
            else
            {
                DialogueManager.StartDialogue(_dialogData);
            }
            _dialogEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
