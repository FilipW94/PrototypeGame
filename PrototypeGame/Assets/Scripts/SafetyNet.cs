using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafetyNet : MonoBehaviour
{
    [SerializeField] private Transform sendBackUp;
    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = sendBackUp.position;
    }
}
