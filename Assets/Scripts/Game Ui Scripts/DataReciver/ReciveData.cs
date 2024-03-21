using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReciveData : MonoBehaviour
{
    private int whatResource;
    private int whatMission;
    private int whatDificulty;
    public MissionDataShower MDS;
    public ResourceManager RM;
    private void Awake()
    {
        GetData();

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
                RM.Wood += 5;
                RM.Stone += 5;
                RM.Iron+= 2;
                RM.Minerals += 2;
                RM.Gems += 2;
                RM.Sulfur += 2;
                RM.Gold+= 2000;
                break;
            case 1:
                break;
            case 2:
                break;
        }
    }
}
