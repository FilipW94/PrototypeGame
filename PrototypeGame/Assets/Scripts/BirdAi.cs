using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BirdAi : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;

    private Transform target;
    private Vector3 originalPosition;
    private bool isMovingTowardsCharacter = false;
    [SerializeField] private GameObject player;
    private string playerTag;
    private void Start()
    {
        originalPosition = transform.position;
    }

    private void Update()
    {
        playerTag = player.tag;
        switch(playerTag) 
        {
            case "SmallSize":
                SetTarget(player.transform);
                break;
            case "NormalSize":
                isMovingTowardsCharacter = false;
                break;
            case "LargeSize":
                isMovingTowardsCharacter = false;
                break;
            default: break;
        }
        {

        }
        if(target != null && Vector3.Distance(transform.position,  target.position) < detectionRange)
        {
            if(isMovingTowardsCharacter )
            {
                transform.position = Vector3.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, originalPosition, moveSpeed * Time.deltaTime);
            }
        }
    }

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        isMovingTowardsCharacter = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("LargeSize"))
        {
            Destroy(this.gameObject);
        }
        else if(other.CompareTag("SmallSize"))
        {
            player.GetComponent<Brain>().RespawnPlayer();
        }
    }

}
