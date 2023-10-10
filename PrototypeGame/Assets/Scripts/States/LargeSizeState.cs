using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.StateMachine;
using Utility.StateMachine.BaseStates;

public class LargeSizeState : MonoState
{
    private Vector3 targetSize;
    public override void OnEnter()
    {
        Vector3 currentSize = this.transform.localScale;
        targetSize = originalSize * 5f;
        playerMovement.moveSpeed = normalMoveSpeed * 2f;
        playerMovement.jumpForce  = normalJumpForce * 1.5f;
        playerMovement.distanceToGround = 4.05f;        //this number seems to work well
        StartCoroutine(ChangeSizeSmoothly(targetSize, currentSize));
        
    }
}
