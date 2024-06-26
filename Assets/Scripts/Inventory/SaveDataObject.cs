using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SaveScene", menuName = "save")]
public class SaveDataObject : ScriptableObject
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
    public Sprite cityBackground;

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
