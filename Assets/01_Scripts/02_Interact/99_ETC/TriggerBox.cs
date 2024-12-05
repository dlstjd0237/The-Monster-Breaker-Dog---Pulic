using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class TriggerBox : MonoBehaviour
{
    [SerializeField] private UnityEvent _triggerEvent;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _triggerEvent?.Invoke();
            gameObject.SetActive(false);
        }
    }
}
