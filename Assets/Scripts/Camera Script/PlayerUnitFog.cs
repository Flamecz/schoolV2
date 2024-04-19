using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnitFog : MonoBehaviour
{
    public GameObject fogOfWarBig; // Assign the FogOfWar object in the Inspector
    public Material big, small;
    public Testing test;

    void Update()
    {
        if (test.pathfinding.settedValue < 20)
        { 
            fogOfWarBig.GetComponent<MeshRenderer>().material = small;
            fogOfWarBig.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
        }
        else
        {
            fogOfWarBig.GetComponent<MeshRenderer>().material = big;
            fogOfWarBig.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - 5);
        }
    }
}
