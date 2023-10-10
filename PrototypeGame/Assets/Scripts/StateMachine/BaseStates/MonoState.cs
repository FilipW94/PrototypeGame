using System.Collections;
using TMPro;
using UnityEngine;

namespace Utility.StateMachine.BaseStates
{
    public class MonoState : MonoBehaviour, 
        IState
    {
        public bool isChangingSize = false;
        protected Vector3 originalSize;
        private float transitionDuration = 0.75f;
        protected float normalMoveSpeed;
        protected float normalJumpForce;
        protected PlayerMovement playerMovement;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
            originalSize = transform.localScale;
            normalMoveSpeed = playerMovement.moveSpeed;
            normalJumpForce = playerMovement.jumpForce;

        }
        public virtual bool HasEntered => false;
        public virtual void OnDrawGizmos() { }
        public virtual void OnEnter() { }
        public virtual void OnExit() { }

        public virtual StateReturn OnUpdate()
        {
            return StateReturn.Completed;
        }
        public virtual IEnumerator ChangeSizeSmoothly(Vector3 targetSize, Vector3 currentSize)
        {
            float startTime = Time.time;
            float endTime = startTime + transitionDuration;

            while (Time.time < endTime)
            {
                float progress = (Time.time - startTime) / transitionDuration;
                transform.localScale = Vector3.Lerp(currentSize, targetSize, progress);

                yield return null;
            }
            transform.localScale = targetSize;

            isChangingSize = false;
        }
        public bool IsChangingSize()
        {
            return isChangingSize;
        }
        public void SetisChangingSize(bool status)
        {
            isChangingSize = status;
        }
    }
}