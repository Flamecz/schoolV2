using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBuildings : MonoBehaviour
{
    public BuildingManager buildingmanager;
    public GameObject[] building;
    public GameObject[] UnitsToSet;
    public Image cityBackgroud;
    private int index;
    void Awake()
    {
        SetData();
    }
    public void SetData()
    {
        buildingmanager = FindObjectOfType<BuildingManager>();
        for (int i = 0; i < buildingmanager.save.CityBuldings.Length; i++)
        {
            BuildButton BB = building[i].GetComponent<BuildButton>();
            BB.cityBuldings = buildingmanager.save.CityBuldings[i];
        }
        cityBackgroud.sprite = buildingmanager.save.cityBackground;
    }
}
