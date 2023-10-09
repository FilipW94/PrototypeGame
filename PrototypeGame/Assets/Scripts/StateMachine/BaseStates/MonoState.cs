using System.Collections;
using TMPro;
using UnityEngine;

namespace Utility.StateMachine.BaseStates
{
    public class MonoState : MonoBehaviour, 
        IState
    {
        protected bool isChangingSize = false;
        public Vector3 originalSize;
        private float transitionDuration = 0.75f;
        //private float raycastDistance = 2f;


        private void Awake()
        {
            originalSize = transform.localScale;
        }
        public virtual bool HasEntered => false;

        public virtual void OnDrawGizmos()
        {}

        public virtual void OnEnter()
        {
            transform.localScale = originalSize;
        }
        public virtual void OnExit()
        {
            ///transform.localScale = originalSize;
            transform.localPosition = Vector3.zero;
            Debug.Log("state exited");
        }

        public virtual StateReturn OnUpdate()
        {
            return StateReturn.Running;
        }
        public virtual IEnumerator ChangeSizeSmoothly(Vector3 targetSize, Vector3 currentSize)
        {
            isChangingSize = true;
            float startTime = Time.time;
            float endTime = startTime + transitionDuration;
            //CharacterController characterController = GetComponent<CharacterController>();
            //Vector3 originalPosition = transform.position;

            while (Time.time < endTime)
            {
                
                float progress = (Time.time - startTime) / transitionDuration;
                transform.localScale = Vector3.Lerp(currentSize, targetSize, progress);
                //yield return null; // Wait for the next frame.

                //RaycastHit hit;
                //Vector3 raycastStartPoint = transform.position + Vector3.up * characterController.height * 0.5f; // Adjust the height.
                //if (Physics.Raycast(raycastStartPoint, Vector3.down, out hit, raycastDistance))
                //{
                //    // Set the target position to keep the character grounded.
                //    Vector3 targetPosition = hit.point;
                //    targetPosition.y += characterController.height * 0.5f; // Adjust the height.
                //    characterController.Move(targetPosition - transform.position);
                //}
                //else
                //{
                //    Debug.LogWarning("No ground found beneath the character.");
                //    // Handle the case where there's no ground detected.
                //}

                yield return null; // Wait for the next frame.
            }

            // Ensure the final scale is exactly the target size.
            //transform.localScale = targetSize;

            // Restore the original position.
            //transform.position = originalPosition;
            isChangingSize = false;
        }
        public bool IsChangingSize()
        {
            return isChangingSize;
        }
    }
}