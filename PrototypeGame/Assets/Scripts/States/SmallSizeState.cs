using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.StateMachine.BaseStates;

public class SmallSizeState : MonoState
{
    private Vector3 targetSize;

    public override void OnEnter()
    {
        playerMovement.distanceToGround = 0.2f;
        playerMovement.moveSpeed = normalMoveSpeed * 0.3f;
        playerMovement.jumpForce = normalJumpForce * 0.7f;
        Vector3 currentSize = this.transform.localScale;
        targetSize = originalSize * 0.1f;
        transform.gameObject.tag = "SmallSize";
        StartCoroutine(ChangeSizeSmoothly(targetSize, currentSize));
    }
}
