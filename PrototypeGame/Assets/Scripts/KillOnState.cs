using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillOnState : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private string killOnState = "Empty";
    [SerializeField] private string killOnStateAlso = "EmptyAlso";
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(killOnState) || other.CompareTag(killOnStateAlso)) 
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
            other.transform.position = respawnPoint.position;
        }
    }
}
