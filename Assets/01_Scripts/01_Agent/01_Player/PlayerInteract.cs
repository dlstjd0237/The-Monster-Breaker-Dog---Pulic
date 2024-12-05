using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    [SerializeField] private float _interactRange = 2.5f;
    public void OnInteract()
    {
        int interactLayer = LayerMask.NameToLayer("Interactive");
        Collider[] colliderArray = Physics.OverlapSphere(transform.position, _interactRange, 1 << interactLayer);
        foreach (Collider collider in colliderArray)
        {
            if (collider.TryGetComponent<Interactable>(out Interactable interactable))
            {
                interactable.BassInteract();

            }
        }
    }
}
