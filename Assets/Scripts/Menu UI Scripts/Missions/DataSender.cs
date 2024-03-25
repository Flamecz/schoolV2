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
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            SceneManager.LoadScene(2);
        }
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