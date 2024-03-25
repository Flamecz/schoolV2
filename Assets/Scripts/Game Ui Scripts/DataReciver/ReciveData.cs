using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciveData : MonoBehaviour
{
    private int whatResource;
    private int whatMission;
    private int whatDificulty;
    public MissionDataShower MDS;
    public Resources resources;
    private void Awake()
    {
        GetData();
        AddResourceBonus();
    }

    private void GetData()
    {
        whatResource = MDS.whatResource;
        whatMission = MDS.whatMission;
        whatDificulty = MDS.whatDificulty;
    }

    public void AddResourceBonus()
    {
        switch(whatResource)
        {
            case 0:
                resources.Wood += 5;
                resources.Stone += 5;
                resources.Iron+= 2;
                resources.Minerals += 2;
                resources.Gems += 2;
                resources.Sulfur += 2;
                resources.Gold+= 2000;
                break;
            case 1:
                break;
            case 2:
                switch(whatMission)
                {
                    case 0:
                        FindObjectOfType<BuildingManager>().GetBuildingByName("Archer Tower");
                            break;
                }
                break;
        }
    }
}
