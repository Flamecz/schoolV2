using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

        Button Button1 = StartCampain.GetComponent<Button>();

        Button Button2 = LoadCampain.GetComponent<Button>(); 

        Button Button3 = Options.GetComponent<Button>(); 

        Button Button4 = Credits.GetComponent<Button>();

        Button Button5 = Quit.GetComponent<Button>(); 

        



        if (StartCampain != null && LoadCampain != null && Options != null && Credits != null && Quit != null)
        {
            StartCampain.GetComponentInChildren<Text>().text = "Start Campain";
            LoadCampain.GetComponentInChildren<Text>().text = "Load Campain";
            Options.GetComponentInChildren<Text>().text = "options";
            Credits.GetComponentInChildren<Text>().text = "credits";
            Quit.GetComponentInChildren<Text>().text = "quit";
        }
        Button1.onClick.AddListener(StartCampainScene);
        Button5.onClick.AddListener(QuitScene);



    }
    private void StartCampainScene()
        {
        FindObjectOfType<AudioManager>().Stop("mainTheme");
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("undeadCityTheme");
    }
        private void LoadCampainScene()
        {

        }
        private void OptionsScene()
        {

        }
        private void CreditsScene()
        {

        }
        private void QuitScene()
        {
        Application.Quit();
        }
}
