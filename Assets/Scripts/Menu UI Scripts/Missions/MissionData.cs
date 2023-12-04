using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class MissionData 
{

    public string misionName;
    public string scenarionName;
    public string missionDescription;
    public string scenarioDescription;

    public Color allies = Color.red;
    public Color Enemy = Color.blue;

    public Sprite UvodObraz;
    public Sprite Map;

}
