
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    public void BassInteract()
    {
        Interact();
    }
    protected abstract void Interact();




}
