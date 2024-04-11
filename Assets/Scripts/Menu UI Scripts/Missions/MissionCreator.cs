 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class MissionCreator : MonoBehaviour
{
    public MissionData missionD;
    public GameObject Canvas;
    public int LevelIndex;
    public InvetorySaver invetorySaver;
    public Unit[] units;
    public int[] countOfUnits;
    public UnitStructure unitStructure;
    private int selectedUnits;

    private string nazev;
    private Button GetSome;
    private Image Map;
    private Text nazevMise;
    private Text popisMise;

    private Text nazevScenar;
    private Text popisScenar;

    private Image spriteStart;
    private Text nameStart;

    private Image TeamColor1;
    private Image TeamColor2;

    private Button ButtonClose;
    private Button PlayMission;

    private Image vyber1;
    private Image vyber2;
    private Image vyber3;

    public enum sound
    {
        good,
        neutral,
        evil
    }
    public sound Theme;

    public CityBuldings[] sendBuildings;

    public BonusThingsinMission[] BTM;
    void Start()
    {
        nazev = gameObject.name;
        getSceneData();
        nameStart.text = missionD.misionName;
        spriteStart.sprite = missionD.UvodObraz;
        GetSome.onClick.AddListener(SetSceneData);
        ButtonClose.onClick.AddListener(FindObjectOfType<MenuUIContorler>().ScenarioSetupClose);
        PlayMission.onClick.AddListener(FindObjectOfType<MenuUIContorler>().LoadGrid);
    }
    public void getSceneData()
    { 

        Transform MissionsPanel = Canvas.transform.Find("Mission");

        Transform StartMenu = Canvas.transform.Find("StartMenu");
        Transform Image = StartMenu.transform.Find("Image");
        Transform ButtonTag = Image.transform.Find(nazev);
        GetSome = ButtonTag.GetComponent<Button>();

        spriteStart = ButtonTag.transform.Find("sprite").GetComponent<Image>();
        nameStart = ButtonTag.transform.Find("name").GetComponent<Text>();
        

        Map = MissionsPanel.transform.Find("Map").GetComponent<Image>();
        Transform InfoTransform = MissionsPanel.transform.Find("Info");

        Transform MissionNameFrameTransform = InfoTransform.transform.Find("MissionNameFrame");
        nazevMise = MissionNameFrameTransform.transform.Find("Mission").GetComponent<Text>();

        Transform MissionDescriptionTransform = InfoTransform.transform.Find("MissionDescription");
        popisMise = MissionDescriptionTransform.transform.Find("description").GetComponent<Text>();

        Transform ScenarioNameFrameTransform = InfoTransform.transform.Find("ScenarionNameFrame");
        nazevScenar = ScenarioNameFrameTransform.transform.Find("Scenario").GetComponent<Text>();

        Transform ScenarioDescriptionTransform = InfoTransform.transform.Find("ScenarioDescription");
        popisScenar = ScenarioDescriptionTransform.transform.Find("description").GetComponent<Text>();

        Transform tabulka = InfoTransform.transform.Find("Tymytabulka");
        TeamColor1 = tabulka.transform.Find("TeamOneColor").GetComponent<Image>();
        TeamColor2 = tabulka.transform.Find("TeamTwoColor").GetComponent<Image>();

        ButtonClose = InfoTransform.transform.Find("Back").GetComponent<Button>();
        PlayMission = InfoTransform.transform.Find("Confirm").GetComponent<Button>();

        vyber1 = InfoTransform.transform.Find("vyber1").GetComponent<Image>();
        vyber2 = InfoTransform.transform.Find("vyber2").GetComponent<Image>();
        vyber3 = InfoTransform.transform.Find("vyber3").GetComponent<Image>();
    }
    public void SetSceneData()
    {
        FindObjectOfType<AudioManager>().Stop("mainTheme");
        if(Theme == sound.good)
        {
            FindObjectOfType<AudioManager>().Play("HeroesGoodtheme");
            FindObjectOfType<BuildingManager>().CityType = BuildingManager.type.Castel;
        }
        else if(Theme == sound.neutral)
        {
            FindObjectOfType<AudioManager>().Play("Neutral");
            FindObjectOfType<BuildingManager>().CityType = BuildingManager.type.Rampart;
        }
        else if (Theme == sound.evil)
        {
            FindObjectOfType<AudioManager>().Play("Evil");
            FindObjectOfType<BuildingManager>().CityType = BuildingManager.type.Necropolis;
        }
        FindObjectOfType<MenuUIContorler>().ScenarionSetup(LevelIndex);

        nazevMise.text = missionD.misionName;
        popisMise.text = missionD.missionDescription;
        nazevScenar.text = missionD.scenarionName;
        popisScenar.text = missionD.scenarioDescription;

        TeamColor1.color = missionD.allies;
        TeamColor2.color = missionD.Enemy;

        Map.sprite = missionD.Map;

        vyber1.sprite = BTM[0].image;
            vyber2.sprite = BTM[1].image;
            vyber3.sprite = BTM[2].image;

        FindObjectOfType<DataSender>().GetMission(LevelIndex);
        for (int i = 0; i < invetorySaver.unitList.Length; i++)
        {
            invetorySaver.unitList[i] = null;
            invetorySaver.unitCount[i] = 0;
        }
        for (int i = 0; i < units.Length; i++)
        {
            invetorySaver.unitList[i] = units[i];
            invetorySaver.unitCount[i] = countOfUnits[i];
        }
        FindObjectOfType<BuildingManager>().CityBuldings = sendBuildings;
    }
    public void GetBonus()
    {
        for (int i = 0; i < units.Length; i++)
        {
            int var = 0;
            if (selectedUnits == 1 && invetorySaver.unitList[i] == unitStructure.unit && var == 0)
            {
                Debug.Log("fired");
                invetorySaver.unitCount[i] += unitStructure.count / 3;
                var = 1;
            }
        }
    }
    public string GetInfo(int index)
    { 
        return BTM[index].description;
    }
    public int GetSelectedUnit(int index)
    {
        return selectedUnits = index;
    }
    public void IsNotInteractable(bool trueOrFalse)
    {
        PlayMission.interactable = trueOrFalse;
    }
}
