using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCity : MonoBehaviour
{
    public BuildingImage buildingImage;
    private bool Done;
    void Update()
    {
        if(!Done)
        {
            gameObject.GetComponent<MeshRenderer>().material = buildingImage.image;
            Done = true;
        }
    }
}
