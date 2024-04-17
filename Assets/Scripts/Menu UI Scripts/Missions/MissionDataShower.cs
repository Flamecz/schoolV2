using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "DataContainer", menuName = "ScriptableObjects/DataContainer")]
public class MissionDataShower : ScriptableObject
{
    public int whatResource;
    public int whatMission = 0;
    public int whatDificulty;
    public int Width, Height;
}
