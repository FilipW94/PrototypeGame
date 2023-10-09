using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.StateMachine.BaseStates;

public class NormalSizeState : MonoState
{
    public override void OnEnter()
    {
        Vector3 currentSize = this.transform.localScale;
        StartCoroutine(ChangeSizeSmoothly(originalSize, currentSize));
    }
    
}
