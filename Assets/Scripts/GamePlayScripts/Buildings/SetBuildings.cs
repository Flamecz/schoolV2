using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetBuildings : MonoBehaviour
{
    public BuildingManager buildingmanager;
    public GameObject[] building;
    public GameObject[] UnitsToSet;
    private int index;
    void Awake()
    {
        SetData();
    }
    public void SetData()
    {
        buildingmanager = FindObjectOfType<BuildingManager>();
        for (int i = 0; i < buildingmanager.CityBuldings.Length; i++)
        {
            BuildButton BB = building[i].GetComponent<BuildButton>();
            BB.cityBuldings = buildingmanager.CityBuldings[i];
        }
    }
}
