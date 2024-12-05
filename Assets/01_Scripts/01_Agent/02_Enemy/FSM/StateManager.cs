using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class StateManager : MonoBehaviour
{
    [SerializeField] private State _currentState;
    private float _skillCoolTime = 60; public float SkillCoolTime { get => _skillCoolTime; set => _skillCoolTime = value; }

    private void Update()
    {
        RunStateMachine();
    }
    private void RunStateMachine()
    {
        State nextState = _currentState?.RunCurrentState();
       


        if (nextState != null)
        {
            SwitchToTheNextState(nextState);
        }
    }

    private void SwitchToTheNextState(State nextState)
    {
        _currentState = nextState;
    }


}
