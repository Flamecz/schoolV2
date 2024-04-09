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
    public InvetorySaver inventorySaver;
    public UnitStructure[] unitStruc;
    private int var;
    private void Awake()
    {
        GetData();
        AddResourceBonus();
        FindObjectOfType<Testing>().selectedMap = whatMission;
        FindObjectOfType<Testing>().width = MDS.Width;
        FindObjectOfType<Testing>().height = MDS.Height;
    }

    private void GetData()
    {
        whatResource = MDS.whatResource;
        whatMission = MDS.whatMission;
        whatDificulty = MDS.whatDificulty;
        if(MDS.whatMission == 0)
        {
            MDS.Width = 20;
            MDS.Height = 10;
        }
        if (MDS.whatMission == 1)
        {
            MDS.Width = 50;
            MDS.Height = 20;
        }
        if (MDS.whatMission == 2)
        {
            MDS.Width = 50;
            MDS.Height = 20;
        }
    }

    public void AddResourceBonus()
    {
        switch (whatDificulty)
        {
            case 0:
                resources.Wood = 30;
                resources.Stone = 30;
                resources.Iron = 25;
                resources.Minerals = 25;
                resources.Gems = 25;
                resources.Sulfur = 25;
                resources.Gold = 30000;
                break;
            case 1:
                resources.Wood = 20;
                resources.Stone = 20;
                resources.Iron = 15;
                resources.Minerals = 15;
                resources.Gems = 15;
                resources.Sulfur = 15;
                resources.Gold = 20000;
                break;
            case 2:
                resources.Wood = 15;
                resources.Stone = 15;
                resources.Iron = 10;
                resources.Minerals = 10;
                resources.Gems = 10;
                resources.Sulfur = 10;
                resources.Gold = 15000;
                break;
            case 3:
                resources.Wood = 10;
                resources.Stone = 10;
                resources.Iron = 5;
                resources.Minerals = 5;
                resources.Gems = 5;
                resources.Sulfur = 5;
                resources.Gold = 10000;
                break;
            case 4:
                resources.Wood = 5;
                resources.Stone = 5;
                resources.Iron = 0;
                resources.Minerals = 0;
                resources.Gems = 0;
                resources.Sulfur = 0;
                resources.Gold = 5000;
                break;
        }

        switch (whatResource)
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
                    case 1:
                        FindObjectOfType<BuildingManager>().GetBuildingByName("Archer Tower");
                        break;
                    case 2:
                        FindObjectOfType<BuildingManager>().GetBuildingByName("Archer Tower");
                        break;
                }
                break;
        }
    }
}
