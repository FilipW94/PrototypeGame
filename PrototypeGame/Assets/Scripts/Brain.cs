using System.Collections;
using System.Xml.Serialization;
using TMPro;
using UnityEngine;
using Utility.StateMachine;
using Utility.StateMachine.BaseStates;

public class Brain : MonoBehaviour
{
    private StackMachine _stackMachine;
    private IState[] _states;

    private void Awake()
    {
        _stackMachine = new StackMachine();
        _states = GetComponents<IState>();
        _stackMachine.PushState(_states[0]);
    }

    private void Update()
    {
        _stackMachine.Update();

        switch(Input.inputString)
        {
            case "2":
                SwitchToState("NormalSizeState");
                break;
            case "1":
                SwitchToState("SmallSizeState");
                break;
            case "3":
                SwitchToState("LargeSizeState");
                break;
        }

    }
    private void SwitchToState(string stateName)
    {

        foreach (var state in _states)
        {
            var monoState = state as MonoState;
            if (state.GetType().Name == stateName && !monoState.IsChangingSize())
            {
                
          
                    _stackMachine.Clear();
                    _stackMachine.PushState(state);
                
                return;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (Application.isPlaying)
        {
            _stackMachine.OnDrawGizmosSelected(transform.position);
        }
    }
}