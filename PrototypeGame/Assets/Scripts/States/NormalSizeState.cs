using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utility.StateMachine.BaseStates;

public class NormalSizeState : MonoState
{
    public override void OnEnter()
    {
        GetComponent<PlayerMovement>().distanceToGround = 0.2f;
        playerMovement.moveSpeed = normalMoveSpeed;
        playerMovement.jumpForce = normalJumpForce;
        Vector3 currentSize = this.transform.localScale;
        transform.gameObject.tag = "NormalSize";
        StartCoroutine(ChangeSizeSmoothly(originalSize, currentSize));
    }
    
}
