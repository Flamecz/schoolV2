using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using Unity.VisualScripting;
using UnityEngine;

public class DataSender : MonoBehaviour
{
    public static DataSender instance;
    public MissionDataShower show;
    
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
        show.whatResource = index;
    }
    public void GetMission(int index)
    {
        show.whatMission = index;
    }
    public void GetDificulty(int index)
    {
        show.whatDificulty = index;
    }
}