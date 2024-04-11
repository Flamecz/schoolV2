using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public enum type
    {
        Castel,
        Rampart,
        Necropolis
    }
    public type CityType;
    public CityBuldings[] CityBuldings;
    public Unit[] UnitSetting;

    private void Start()
    {
        CityBuldings = new CityBuldings[11];
        UnitSetting = new Unit[14];
    }
    // Method to get a building by name
    public CityBuldings GetBuildingByName(string buildingName)
    {
        foreach (CityBuldings building in CityBuldings)
        {
            if (building.nazev == buildingName)
            {
                building.builded = true;
            }
        }
        return null; 
    }
}
