using System.Collections.Generic;
using UnityEngine;

public class ObjectsActive : MonoBehaviour
{
    [SerializeField] private List<GameObject> _activeObject;
    public void ObjectSetActiveTrue()

    {
        for (int i = 0; i < _activeObject.Count; ++i)
        {
            _activeObject[i].SetActive(true);
        }
    }

    public void ObjectSetActiveFalse()
    {
        for (int i = 0; i < _activeObject.Count; ++i)
        {
            _activeObject[i].SetActive(false);
        }
    }
}
