using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadSceneAction : MonoBehaviour
{
    [SerializeField] private string _sceneName;
    public void SceenLoad()
    {
        SceneControlManager.Instance.FadeOut(() => SceneManager.LoadScene(_sceneName));
    }
}
