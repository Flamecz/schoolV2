using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SmurfCat : MonoBehaviour
{
    public Material[] newMaterial; // Assign the new materials in the Inspector
    public GameObject objectToChange;

    public bool flip;
    void Update()
    {
        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 1000f))
            {
                if (raycastHit.transform != null)
                {
                    //Our custom method. 
                    CurrentClickedGameObject(raycastHit.transform.gameObject);
                }
            }
        }
    }

    public void CurrentClickedGameObject(GameObject gameObject)
    {
        if (gameObject.tag == "Smurf")
        {
            SwitchTree();
        }
    }
    public void SwitchTree()
    {
        flip = !flip;

        if (objectToChange != null)
        {
            Renderer renderer = objectToChange.GetComponent<Renderer>();

            if (renderer != null)
            {
                if (flip && newMaterial.Length > 1)
                {
                    FindObjectOfType<AudioManager>().Play("theme");
                    renderer.material = newMaterial[1];
                    FindObjectOfType<ViewRotation>().speedset(50f);
                }
                else if (!flip && newMaterial.Length > 0)
                {
                    FindObjectOfType<AudioManager>().Stop("theme");
                    renderer.material = newMaterial[0];
                    FindObjectOfType<ViewRotation>().speedset(15f);
                }
                else
                {
                    Debug.LogError("newMaterial array does not have enough elements.");
                }
            }
            else
            {
                Debug.LogError("Renderer component not found on the GameObject to change.");
            }
        }
       
    }
}
