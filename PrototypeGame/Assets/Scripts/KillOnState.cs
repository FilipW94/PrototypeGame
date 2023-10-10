using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillOnState : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private string killOnState = "Empty";
    [SerializeField] private string killOnStateAlso = "EmptyAlso";
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(killOnState) || other.CompareTag(killOnStateAlso)) 
        {
            other.transform.position = respawnPoint.position;
        }
    }
}
