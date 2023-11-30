using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionCreator : MonoBehaviour
{
    public MissionData missionD;
    public GameObject Canvas;
    private string nazev;
    private Button GetSome;
    private Transform MissionInfo;
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

    List<BonusThingsinMission> myObjects = new List<BonusThingsinMission>();
    // BonusThingsinMission BTIM = new BonusThingsinMission("More Ores" , )
    void Start()
    {
        myObjects.Add(new BonusThingsinMission("additional resources", Resources.Load<Sprite>("Sprites/resources"), "Gives you additional resources to create buildings"));
        myObjects.Add(new BonusThingsinMission("12 ", Resources.Load<Sprite>("Sprites/resources"), "Gives you additional resources to create buildings"));
        myObjects.Add(new BonusThingsinMission("Budova", Resources.Load<Sprite>("Sprites/resources"), "přidá ti novou buduovu pro hraní"));
        nazev = gameObject.name;
        getSceneData();

        GetSome.onClick.AddListener(SetSceneData);
        ButtonClose.onClick.AddListener(FindObjectOfType<MenuUIContorler>().ScenarioSetupClose);
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
    }

    public void SetSceneData()
    {
        FindObjectOfType<MenuUIContorler>().ScenarionSetup();

        nazevMise.text = missionD.misionName;
        popisMise.text = missionD.missionDescription;
        nazevScenar.text = missionD.scenarionName;
        popisScenar.text = missionD.scenarioDescription;

        TeamColor1.color = missionD.allies;
        TeamColor2.color = missionD.Enemy;
    }
}
