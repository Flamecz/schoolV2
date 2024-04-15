using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckColision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("hrad"))
        {
            Debug.Log("Collision with object tagged as 'YourTag' detected.");
            // Add your collision handling code here
        }
    }
}
