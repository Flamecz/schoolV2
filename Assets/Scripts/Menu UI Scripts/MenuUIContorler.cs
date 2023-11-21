using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuUIContorler : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject StartMenu;
    public GameObject LoadMenu;
    public GameObject Settings;
    public GameObject Credits;

    public void SetMainCanvas()
    {
        MainCanvas.SetActive(true);
        Settings.SetActive(false);
        StartMenu.SetActive(false);
        LoadMenu.SetActive(false);
        Credits.SetActive(false);
    }
    public void SettingsCanvas()
    {
        MainCanvas.SetActive(false);
        Settings.SetActive(true);
        StartMenu.SetActive(false);
        LoadMenu.SetActive(false);
    }
    public void StartCanvas()
    {
        MainCanvas.SetActive(false);
        Settings.SetActive(false);
        StartMenu.SetActive(true);
        LoadMenu.SetActive(false);
    }
    public void LoadCanvas()
    {
        MainCanvas.SetActive(false);
        Settings.SetActive(false);
        StartMenu.SetActive(false);
        LoadMenu.SetActive(true);
    }
    public void Creddits()
    {
        MainCanvas.SetActive(false);
        Settings.SetActive(false);
        StartMenu.SetActive(false);
        LoadMenu.SetActive(false);
        Credits.SetActive(true);
    }
}
