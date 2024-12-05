using UnityEngine;
using UnityEngine.SceneManagement;
public class Portal : Interactable
{
    [SerializeField] private string _nextSceneName;
    private bool _isInteract;

    protected override void Interact()
    {
        if (!_isInteract)
            SceneControlManager.Instance.FadeOut(MoveScene);
    }

    private void MoveScene()
    {
        _isInteract = true;
        SceneManager.LoadScene(_nextSceneName);
    }



}
