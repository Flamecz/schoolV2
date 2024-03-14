using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mapCreator : MonoBehaviour
{
    public PathVisual pathVisual;
    public string[] map;

    void Start()
    {
        // Define a simple map as a string array
        map = new string[]
        {
            "*****",
            "*X*X*",
            "*****",
        };

        // Create grid based on the map
    }
}
