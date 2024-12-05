using UnityEngine;
using UnityEngine.SceneManagement;
[CreateAssetMenu(menuName = "ScriptableObject/MapData")]

public class MapData : ScriptableObject
{
    [SerializeField] private string _head; public string Head { get { return _head; } }
    [SerializeField] private string _body; public string Body { get { return _body; } }
    [SerializeField] private Texture2D _image; public Texture2D Image { get { return _image; } }

    [SerializeField] private string _loadSceneName; public string LoadSceneName { get { return _loadSceneName; } }


}
