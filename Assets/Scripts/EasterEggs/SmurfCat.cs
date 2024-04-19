using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SmurfCat : MonoBehaviour
{
    public Material[] newMaterial; // Assign the new materials in the Inspector
    public GameObject objectToChange;

    public bool flip;
    private static bool onMain = true;
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
        if (onMain)
        {
            if (gameObject.tag == "Smurf")
            {
                SwitchTree();
            }
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
                    FindObjectOfType<AudioManager>().ChangeVolume("mainTheme", 0f);
                    FindObjectOfType<AudioManager>().Play("cat");
                    int c = PlayerPrefs.GetInt("Smurfing");
                    PlayerPrefs.SetInt("Smurfing", c+1);
                    FindObjectOfType<Achivements>().Smurin();
                    renderer.material = newMaterial[1];
                    FindObjectOfType<ViewRotation>().speedset(50f);
                }
                else if (!flip && newMaterial.Length > 0)
                {
                    FindObjectOfType<AudioManager>().Stop("cat");
                    FindObjectOfType<AudioManager>().ChangeVolume("mainTheme", 0.3f);
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
    public void SmurfSetter(bool yesAndNo)
    {
        onMain = yesAndNo;
    }
}
