using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float panSpeed = 20f; // Speed of camera movement
    public float panBorderThickness = 10f; // Distance from edge of screen to start moving
    public Vector2 minBoundary; // Minimum boundary of the map
    public Vector2 maxBoundary; // Maximum boundary of the map

    private Camera orthographicCamera;

    void Start()
    {
        orthographicCamera = GetComponent<Camera>();
    }

    void Update()
    {
        // Move camera based on keyboard input (WASD)
        Vector3 keyboardInput = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        Vector3 panDirection = keyboardInput.normalized;

        // Move camera based on mouse position near screen edges
        if (Input.mousePosition.x < panBorderThickness && transform.position.x > minBoundary.x)
        {
            panDirection += Vector3.left;
        }
        if (Input.mousePosition.x > Screen.width - panBorderThickness && transform.position.x < maxBoundary.x)
        {
            panDirection += Vector3.right;
        }
        if (Input.mousePosition.y < panBorderThickness && transform.position.y > minBoundary.y)
        {
            panDirection += Vector3.down;
        }
        if (Input.mousePosition.y > Screen.height - panBorderThickness && transform.position.y < maxBoundary.y)
        {
            panDirection += Vector3.up;
        }

        // Normalize the pan direction to prevent faster diagonal movement
        panDirection.Normalize();

        // Convert screen movement to world movement
        Vector3 pan = orthographicCamera.ScreenToWorldPoint(panDirection) - orthographicCamera.ScreenToWorldPoint(Vector3.zero);

        // Move the camera, clamping the position within boundaries
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + pan.x * panSpeed * Time.deltaTime, minBoundary.x, maxBoundary.x),
            Mathf.Clamp(transform.position.y + pan.y * panSpeed * Time.deltaTime, minBoundary.y, maxBoundary.y),
            transform.position.z
        );
    }
}
