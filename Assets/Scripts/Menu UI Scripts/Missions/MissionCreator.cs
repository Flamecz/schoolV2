 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Android;
using UnityEngine.UI;

public class MissionCreator : MonoBehaviour
{
    [Header("Data about mission")]
    public int LevelIndex;
    public MissionData missionD;
    public MissionDataShower missionDataShower;
    public MissionDataShower MIssionLoader;
    public Quest data;
    public QuestControll QC;
    public sound Theme;
    public BonusThingsinMission[] BTM;
    [Header("Units")]
    public InvetorySaver invetorySaver;
    public Unit[] units;
    public int[] countOfUnits;
    public UnitStructure unitStructure;
    public Sprite cityBackground;
    [Header("invetory")]
    public Unit[] unitsToSet;
    public StoredData storeData;
    public StoreStamina set;
    public Sprite playerImage, EnemyImage;
    public Sprite cityImage;
    [Header("Misc")]
    public GameObject Canvas;
    private int selectedUnits;
    private bool Check = false;
    public EnemysToRemove ETR;
    public SaveLoadData SLD;
    public StoredData SD;

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
    public SaveDataObject SDO;
    public SavePlayerImages savePlayerImages;
    public enum sound
    {
        good,
        neutral,
        evil
    }
    public CityBuldings[] sendBuildings;
    void Start()
    {
        
        nazev = gameObject.name;
        getSceneData();
        nameStart.text = missionD.misionName;
        spriteStart.sprite = missionD.UvodObraz;
        GetSome.onClick.AddListener(SetSceneData);
        ButtonClose.onClick.AddListener(FindObjectOfType<MenuUIContorler>().ScenarioSetupClose);
        PlayMission.onClick.AddListener(LoadGame);
    }
    public void getSceneData()
    {
        QC = FindObjectOfType<QuestControll>();
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
        }
        else if(Theme == sound.neutral)
        {
            FindObjectOfType<AudioManager>().Play("Neutral");
        }
        else if (Theme == sound.evil)
        {
            FindObjectOfType<AudioManager>().Play("Evil");
        }
        FindObjectOfType<MenuUIContorler>().ScenarionSetup(LevelIndex);
        FindObjectOfType<DataSender>().GetMission(LevelIndex);
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
    }
    public void GetBonus()
    {
        for (int i = 0; i < units.Length; i++)
        {
            int var = 0;
            if (selectedUnits == 1 && invetorySaver.unitList[i] == unitStructure.unit && var == 0)
            {
                invetorySaver.unitCount[i] += unitStructure.count / 3;
                var = 1;
            }
        }
    }
    private void ClearData()
    {
        sendBuildings[0].builded = true;
        sendBuildings[1].builded = true;
        sendBuildings[2].builded = true;
        sendBuildings[3].builded = true;
        sendBuildings[4].builded = true;
        sendBuildings[5].builded = true;
        sendBuildings[6].builded = false;
        sendBuildings[7].builded = false;
        sendBuildings[8].builded = false;
        sendBuildings[9].builded = false;
        sendBuildings[10].builded = false;
        for (int i = 0; i < sendBuildings.Length; i++)
        {
            sendBuildings[i].upgraded = false;
        }
        if(MIssionLoader.whatResource == 2)
        {
            sendBuildings[6].builded = true;
        }
        sendBuildings[1].upgraded= true;
        sendBuildings[2].upgraded = true;
        sendBuildings[3].upgraded = true;
    }
    public void LoadGame()
    {
        ETR.Dead = false;
        SLD.SavedQuit = false;
        SD.storeTag = new string[7];
        if (MIssionLoader.whatMission == 0)
        {
            ClearData();
            if (Theme == sound.good)
            {
                PlayerPrefs.SetFloat("PosX", 205);
                PlayerPrefs.SetFloat("PosY", 75);
                PlayerPrefs.SetFloat("PosZ", 5);
                SDO.CityType = SaveDataObject.type.Castel;
                for (int i = 0; i < storeData.storeTag.Length; i++)
                {
                    storeData.storeTag[i] = null;
                }
                for (int i = 0; i < SDO.CityBuldings.Length; i++)
                {
                    SDO.CityBuldings[i] = sendBuildings[i];
                }
                for (int i = 0; i < SDO.UnitSetting.Length; i++)
                {
                    SDO.UnitSetting[i] = unitsToSet[i];
                }
                for (int i = 0; i < invetorySaver.unitList.Length; i++)
                {
                    invetorySaver.unitList[i] = null;
                    invetorySaver.unitCount[i] = 0;
                    Debug.Log("done");
                }
                for (int i = 0; i < units.Length; i++)
                {
                    invetorySaver.unitList[i] = units[i];
                    invetorySaver.unitCount[i] = countOfUnits[i];
                    Debug.Log("done1");
                }
                for(int i = 0; i < storeData.ResourcesTaken.Length; i++)
                {
                    storeData.ResourcesTaken[i].claimed = false;
                }
                SDO.cityBackground = cityBackground;
                savePlayerImages.player = playerImage;
                savePlayerImages.enemy = EnemyImage;
                savePlayerImages.cityPicture = cityImage;
                savePlayerImages.cityName = "Gateway";
            }
            PlayerPrefs.SetInt("den", 1);
            PlayerPrefs.DeleteKey("Test Scene");
            PlayerPrefs.SetInt("Setted", 1);
            if (MIssionLoader.whatMission == LevelIndex)
            {
                QC.Selected.condition = data.condition;
                QC.Selected.description = data.description;
                QC.Selected.isActive = true;
                QC.Selected.QG = data.QG;
            }
            set.stamina = 200;
            missionDataShower.whatDificulty = MIssionLoader.whatDificulty;
            missionDataShower.whatMission = MIssionLoader.whatMission;
            missionDataShower.whatResource = MIssionLoader.whatResource;
            FindObjectOfType<MenuUIContorler>().LoadGrid();
            Debug.Log(QC.Selected.condition);
        }
        else if (MIssionLoader.whatMission == 1)
        {
            ClearData();
            if (Theme == sound.neutral)
            {
                PlayerPrefs.SetFloat("PosX", 15);
                PlayerPrefs.SetFloat("PosY", 45);
                PlayerPrefs.SetFloat("PosZ", 5);
                SDO.CityType = SaveDataObject.type.Rampart;
                for (int i = 0; i < storeData.storeTag.Length; i++)
                {
                    storeData.storeTag[i] = null;
                }
                for (int i = 0; i < SDO.CityBuldings.Length; i++)
                {
                    SDO.CityBuldings[i] = sendBuildings[i];
                }
                for (int i = 0; i < SDO.UnitSetting.Length; i++)
                {
                    SDO.UnitSetting[i] = unitsToSet[i];
                }
                for (int i = 0; i < invetorySaver.unitList.Length; i++)
                {
                    invetorySaver.unitList[i] = null;
                    invetorySaver.unitCount[i] = 0;
                    Debug.Log("done");
                }
                for (int i = 0; i < units.Length; i++)
                {
                    invetorySaver.unitList[i] = units[i];
                    invetorySaver.unitCount[i] = countOfUnits[i];
                    Debug.Log("done1");
                }
                for (int i = 0; i < storeData.ResourcesTaken.Length; i++)
                {
                    storeData.ResourcesTaken[i].claimed = false;
                }
                SDO.cityBackground = cityBackground;
                savePlayerImages.player = playerImage;
                savePlayerImages.enemy = EnemyImage;
                savePlayerImages.cityPicture = cityImage;
                savePlayerImages.cityName = "Elfwind";
            }   
            PlayerPrefs.SetInt("den", 1);
            PlayerPrefs.DeleteKey("Test Scene");
            PlayerPrefs.SetInt("Setted", 1);
            if (MIssionLoader.whatMission == LevelIndex)
            {
                QC.Selected.condition = data.condition;
                QC.Selected.description = data.description;
                QC.Selected.isActive = true;
                QC.Selected.QG = data.QG;
            }
            set.stamina = 200;
            missionDataShower.whatDificulty = MIssionLoader.whatDificulty;
            missionDataShower.whatMission = MIssionLoader.whatMission;
            missionDataShower.whatResource = MIssionLoader.whatResource;
            FindObjectOfType<MenuUIContorler>().LoadGrid();
            Debug.Log(QC.Selected.condition);
        }
        else if (MIssionLoader.whatMission == 2)
        {
            ClearData();
            if (Theme == sound.evil)
            {
                PlayerPrefs.SetFloat("PosX", 15);
                PlayerPrefs.SetFloat("PosY", 45);
                PlayerPrefs.SetFloat("PosZ", 5);
                SDO.CityType = SaveDataObject.type.Necropolis;
                for (int i = 0; i < storeData.storeTag.Length; i++)
                {
                    storeData.storeTag[i] = null;
                }
                for (int i = 0; i < SDO.CityBuldings.Length; i++)
                {
                    SDO.CityBuldings[i] = sendBuildings[i];
                }
                for (int i = 0; i < SDO.UnitSetting.Length; i++)
                {
                    SDO.UnitSetting[i] = unitsToSet[i];
                }
                for (int i = 0; i < invetorySaver.unitList.Length; i++)
                {
                    invetorySaver.unitList[i] = null;
                    invetorySaver.unitCount[i] = 0;
                    Debug.Log("done");
                }
                for (int i = 0; i < units.Length; i++)
                {
                    invetorySaver.unitList[i] = units[i];
                    invetorySaver.unitCount[i] = countOfUnits[i];
                    Debug.Log("done1");
                }
                for (int i = 0; i < storeData.ResourcesTaken.Length; i++)
                {
                    storeData.ResourcesTaken[i].claimed = false;
                }
                SDO.cityBackground = cityBackground;
                savePlayerImages.player = playerImage;
                savePlayerImages.enemy = EnemyImage;
                savePlayerImages.cityPicture = cityImage;
                savePlayerImages.cityName = "Blackquarter";
            }
            PlayerPrefs.SetInt("den", 1);
            PlayerPrefs.DeleteKey("Test Scene");
            PlayerPrefs.SetInt("Setted", 1);
            if(MIssionLoader.whatMission == LevelIndex)
            {
                QC.Selected.condition = data.condition;
                QC.Selected.description = data.description;
                QC.Selected.isActive = true;
                QC.Selected.QG = data.QG;
            }
            set.stamina = 200;
            missionDataShower.whatDificulty = MIssionLoader.whatDificulty;
            missionDataShower.whatMission = MIssionLoader.whatMission;
            missionDataShower.whatResource = MIssionLoader.whatResource;
            FindObjectOfType<MenuUIContorler>().LoadGrid();
            Debug.Log(QC.Selected.condition);
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
/*            else if (Theme == sound.neutral)
            {
                PlayerPrefs.SetFloat("PosX", 20);
                PlayerPrefs.SetFloat("PosY", 45);
                PlayerPrefs.SetFloat("PosZ", 5);
                SDO.CityType = SaveDataObject.type.Rampart;
                Debug.Log("done3");
            }
            else if (Theme == sound.evil)
            {
                PlayerPrefs.SetFloat("PosX", 20);
                PlayerPrefs.SetFloat("PosY", 45);
                PlayerPrefs.SetFloat("PosZ", 5);
                SDO.CityType = SaveDataObject.type.Necropolis;
                Debug.Log("done4");
            }
 * 
 */