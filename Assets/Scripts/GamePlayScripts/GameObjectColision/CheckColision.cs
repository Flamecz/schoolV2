using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player collider is touching the trigger collider of the object
            Debug.Log("Player is touching the object's trigger collider.");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Player collider is no longer touching the trigger collider of the object
            Debug.Log("Player is no longer touching the object's trigger collider.");
        }
    }
}
