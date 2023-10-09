using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.StateMachine.BaseStates;

public class SmallSizeState : MonoState
{
    private Vector3 targetSize;
    public override void OnEnter()
    {
        Vector3 currentSize = this.transform.localScale;
        targetSize = originalSize * 0.1f;
        StartCoroutine(ChangeSizeSmoothly(targetSize, currentSize));
    }
}
