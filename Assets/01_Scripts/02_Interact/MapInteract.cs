using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class MapInteract : Interactable
{
    [SerializeField] private UnityEvent _showMap;
    protected override void Interact()
    {
        _showMap?.Invoke();
    }
}
