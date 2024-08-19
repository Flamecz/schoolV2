using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DataSender : MonoBehaviour
{
    public static DataSender instance;
    public MissionDataShower show;
    public MissionDataShower Load;
    public BuildingManager buildingManager;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    public void GetIndex(int index)
    {
        Load.whatResource = index;
    }
    public void GetMission(int index)
    {
        Load.whatMission = index;
    }
    public void GetDificulty(int index)
    {
        Load.whatDificulty = index;
    }
}