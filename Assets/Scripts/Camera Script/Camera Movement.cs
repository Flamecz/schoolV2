using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public static bool Paused;

    private int HoverAreaLeftX;
    private int HoverAreaRightX;
    private int HoverAreaUp;
    private int HoverAreaDown;
    public float sensitivity;
    float maxHeight;
    float minHeight;
    float currentHeight;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        maxHeight = 30f;
        minHeight = 6f;
        currentHeight = this.gameObject.transform.position.y;
        Paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!Paused)
        {
            HoverAreaRightX = Screen.width - Screen.width / 30;
            HoverAreaLeftX = Screen.width - HoverAreaRightX;
            HoverAreaUp = Screen.height - Screen.height / 20;
            HoverAreaDown = Screen.height - HoverAreaUp;

            if (Input.GetAxisRaw("Mouse ScrollWheel") > 0)
            {
                if (currentHeight < maxHeight)
                {
                    currentHeight += sensitivity * Time.deltaTime;
                    currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);
                    Vector3 newPosition = new Vector3(transform.position.x, currentHeight, transform.position.z);
                    transform.position = newPosition;
                }
            }
            if (Input.GetAxisRaw("Mouse ScrollWheel") < 0)
            {
                if (currentHeight > minHeight)
                {
                    currentHeight -= sensitivity * Time.deltaTime;
                    currentHeight = Mathf.Clamp(currentHeight, minHeight, maxHeight);
                    Vector3 newPosition = new Vector3(transform.position.x, currentHeight, transform.position.z);
                    transform.position = newPosition;
                }
            }
            if (Input.mousePosition.x > HoverAreaRightX)
            {
                rb.AddForce(transform.right * sensitivity);
            }
            if (Input.mousePosition.x < HoverAreaLeftX)
            {
                rb.AddForce(-transform.right * sensitivity);
            }
            if (Input.mousePosition.y > HoverAreaUp)
            {
                rb.AddForce(transform.up * sensitivity);
            }
            if (Input.mousePosition.y < HoverAreaDown)
            {
                rb.AddForce(-transform.up * sensitivity);
            }
        }
    }


    public void PausedGame(bool ON_OFF)
    {
        Paused = ON_OFF;
    }
}
