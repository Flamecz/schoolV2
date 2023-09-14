using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public GameObject Odkazy;


    private void Start()
    {
        Transform StartCampain = Odkazy.transform.Find("startcampain");
        Transform LoadCampain = Odkazy.transform.Find("loadcampain");
        Transform Options = Odkazy.transform.Find("settings");
        Transform Credits = Odkazy.transform.Find("credits");
        Transform Quit = Odkazy.transform.Find("quit");


        if (StartCampain != null && LoadCampain != null && Options != null && Credits != null && Quit != null)
        {
            GameObject.Find("startcampain").GetComponentInChildren<Text>().text = "Start Campain";
            GameObject.Find("loadcampain").GetComponentInChildren<Text>().text = "Load Campain";
            GameObject.Find("settings").GetComponentInChildren<Text>().text = "options";
            GameObject.Find("credits").GetComponentInChildren<Text>().text = "credits";
            GameObject.Find("quit").GetComponentInChildren<Text>().text = "quit";
        }
        if(StartCampain != null)
        {
            Debug.Log("done");
        }
    }
}
