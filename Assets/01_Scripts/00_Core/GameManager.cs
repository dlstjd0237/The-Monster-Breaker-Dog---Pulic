using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    public Transform Player;
    private void Awake()
    {
        Player = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if(Player == null)
        {
            Player = GameObject.Find("Player").transform;
        }
    }
}
