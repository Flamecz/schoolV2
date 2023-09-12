using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewRotation : MonoBehaviour
{
    public bool rotation;
    public float rotationSpeed = 50.0f; // Adjust the rotation speed as needed

    void Update()
    {
        if(!rotation)
        {
            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.Rotate(Vector3.up * -rotationSpeed * Time.deltaTime);
        }
        // Rotate the sphere to the right (around its up axis)

    }
}
