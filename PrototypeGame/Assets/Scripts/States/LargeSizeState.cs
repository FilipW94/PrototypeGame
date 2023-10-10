using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.StateMachine.BaseStates;

public class LargeSizeState : MonoState
{
    private Vector3 targetSize;
    public override void OnEnter()
    {
        Vector3 currentSize = this.transform.localScale;
        targetSize = originalSize * 10f;
        
        StartCoroutine(ChangeSizeSmoothly(targetSize, currentSize));
    }
}
