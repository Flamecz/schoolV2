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
    public Claim[] buildingReset;
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
    public DataForEnemy[] dataForEnemy;
    public EnemysToRemove[] ETR;
    [Header("Misc")]
    public GameObject Canvas;
    private int selectedUnits;
    private bool Check = false;
    public SaveLoadData SLD;
    public StoredData SD;
    public IsSomethingBuild isSomethingBuild;
    public BuildingImage buildingImage;
    public Material CityImage;


    public Unit[] Enemy1Units;
    public Unit[] Enemy2Units;
    public Unit[] Enemy3Units;

    public int[] enemy1Count;
    public int[] enemy2Count;
    public int[] enemy3Count;

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
    public string playerName,enemyName;
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
            if (MIssionLoader.whatResource == 1 && invetorySaver.unitList[i] == unitStructure.unit && var == 0)
            {
                invetorySaver.unitCount[i] += unitStructure.count;
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
            sendBuildings[i].canBeUpgraded = false;
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
        isSomethingBuild.isBuilded = false;
        for(int i = 0; i < ETR.Length; i++)
        {
            ETR[i].Dead = false;
        }
        for(int i = 0; i < buildingReset.Length; i++)
        {
            buildingReset[i].claimed = false;
        }
        SLD.SavedQuit = false;
        SD.storeTag = new string[7];
        if (MIssionLoader.whatMission == 0)
        {
            ClearData();
            if (Theme == sound.good)
            {
                PlayerPrefs.SetFloat("PosX", 5);
                PlayerPrefs.SetFloat("PosY", 5);
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
                for (int i = 0; i < storeData.ResourcesTaken.Length; i++)
                {
                    storeData.ResourcesTaken[i].claimed = false;
                }
                for (int i = 0; i < dataForEnemy.Length; i++)
                {
                    for (int x = 0; x < dataForEnemy[i].unitsData.Length; x++)
                    {
                        dataForEnemy[i].unitsData[x].unit = null;
                        dataForEnemy[i].unitsData[x].count = 0;
                    }
                }
                for (int i = 0; i < Enemy1Units.Length; i++)
                {
                    dataForEnemy[0].unitsData[i].unit = Enemy1Units[i];
                    dataForEnemy[0].unitsData[i].count = enemy1Count[i];
                }
                for (int i = 0; i < Enemy2Units.Length; i++)
                {
                    dataForEnemy[1].unitsData[i].unit = Enemy2Units[i];
                    dataForEnemy[1].unitsData[i].count = enemy2Count[i];
                }
                for (int i = 0; i < Enemy3Units.Length; i++)
                {
                    dataForEnemy[2].unitsData[i].unit = Enemy3Units[i];
                    dataForEnemy[2].unitsData[i].count = enemy3Count[i];
                }
                SDO.cityBackground = cityBackground;
                savePlayerImages.player = playerImage;
                savePlayerImages.enemy = EnemyImage;
                savePlayerImages.cityPicture = cityImage;
                savePlayerImages.playerName = playerName;
                savePlayerImages.enemyName = enemyName;
                savePlayerImages.cityName = "Gateway";
                GetBonus();
                buildingImage.image = CityImage;
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
                Debug.Log("Yes it Happened");
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
                PlayerPrefs.SetFloat("PosX", 95);
                PlayerPrefs.SetFloat("PosY", 65);
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
                for (int i = 0; i < dataForEnemy.Length; i++)
                {
                    for (int x = 0; x < dataForEnemy[i].unitsData.Length; x++)
                    {
                        dataForEnemy[i].unitsData[x].unit = null;
                        dataForEnemy[i].unitsData[x].count = 0;
                    }
                }
                for (int i = 0; i < Enemy1Units.Length; i++)
                {
                    dataForEnemy[0].unitsData[i].unit = Enemy1Units[i];
                    dataForEnemy[0].unitsData[i].count = enemy1Count[i];
                }
                for (int i = 0; i < Enemy2Units.Length; i++)
                {
                    dataForEnemy[1].unitsData[i].unit = Enemy2Units[i];
                    dataForEnemy[1].unitsData[i].count = enemy2Count[i];
                }
                for (int i = 0; i < Enemy3Units.Length; i++)
                {
                    dataForEnemy[2].unitsData[i].unit = Enemy3Units[i];
                    dataForEnemy[2].unitsData[i].count = enemy3Count[i];
                }
                SDO.cityBackground = cityBackground;
                savePlayerImages.player = playerImage;
                savePlayerImages.enemy = EnemyImage;
                savePlayerImages.cityPicture = cityImage;
                savePlayerImages.playerName = playerName;
                savePlayerImages.enemyName = enemyName;
                savePlayerImages.cityName = "Elfwind";
                if (MIssionLoader.whatMission == LevelIndex)
                {
                    QC.Selected.condition = data.condition;
                    QC.Selected.description = data.description;
                    QC.Selected.isActive = true;
                    QC.Selected.QG = data.QG;
                }
                GetBonus();
                buildingImage.image = CityImage;
            }   
            PlayerPrefs.SetInt("den", 1);
            PlayerPrefs.DeleteKey("Test Scene");
            PlayerPrefs.SetInt("Setted", 1);
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
                for (int i = 0; i < dataForEnemy.Length; i++)
                {
                    for (int x = 0; x < dataForEnemy[i].unitsData.Length; x++)
                    {
                        dataForEnemy[i].unitsData[x].unit = null;
                        dataForEnemy[i].unitsData[x].count = 0;
                    }
                }
                for (int i = 0; i < Enemy1Units.Length; i++)
                {
                    dataForEnemy[0].unitsData[i].unit = Enemy1Units[i];
                    dataForEnemy[0].unitsData[i].count = enemy1Count[i];
                }
                for (int i = 0; i < Enemy2Units.Length; i++)
                {
                    dataForEnemy[1].unitsData[i].unit = Enemy2Units[i];
                    dataForEnemy[1].unitsData[i].count = enemy2Count[i];
                }
                for (int i = 0; i < Enemy3Units.Length; i++)
                {
                    dataForEnemy[2].unitsData[i].unit = Enemy3Units[i];
                    dataForEnemy[2].unitsData[i].count = enemy3Count[i];
                }
                SDO.cityBackground = cityBackground;
                savePlayerImages.player = playerImage;
                savePlayerImages.enemy = EnemyImage;
                savePlayerImages.cityPicture = cityImage;
                savePlayerImages.playerName = playerName;
                savePlayerImages.enemyName = enemyName;
                savePlayerImages.cityName = "Blackquarter";
                GetBonus();
                buildingImage.image = CityImage;
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