using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class EnemySpawn : MonoBehaviour
{

    private Renderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    private void OnEnable()
    {
        _renderer.material.SetFloat("_Fadein", 0);
        _renderer.material.DOFloat(1, "_Fadein", 3);
    }
}
