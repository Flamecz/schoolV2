using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public CityBuldings[] CityBuldings;


    // Method to get a building by name
    public CityBuldings GetBuildingByName(string buildingName)
    {
        foreach (CityBuldings building in CityBuldings)
        {
            if (building.buildingName == buildingName)
            {
                building.builded = true;
            }
        }
        return null; 
    }
}
