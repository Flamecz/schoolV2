using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuestControll : MonoBehaviour
{
    private static QuestControll instance;


    public Quest[] data;
    public MissionDataShower MDS;

    public Quest Selected;
    public GameObject FinnishedQuestTemp;
    public CameraMovement CM;
    public GameObject QuestWindow;
    public SaveDataObject SDO;

    private Text Condition;
    private Text Description;
    private Button Accept;
    private bool Set = false;
    private bool beenseen;

    private void Start()
    {
        if (!beenseen)
        {
            OpenQuest();
        }
    }
    void Awake()
    {
        Condition = QuestWindow.gameObject.transform.Find("Condition").GetComponent<Text>();
        if (Condition == null)
        {
            Debug.Log("1");
        }
        Description = QuestWindow.gameObject.transform.Find("Description").GetComponent<Text>();
        if (Description == null)
        {
            Debug.Log("2");
        }
        Accept = QuestWindow.gameObject.transform.Find("Accept").GetComponent<Button>();
        if (Accept == null)
        {
            Debug.Log("3");
        }
        SetData();
    }

    private void Update()
    {
        bool isdone = Selected.QG.QuestDone();
        if (isdone == true)
        {
            FinnishedQuest();
        }
    }
    private void GoToMenu()
    {
        SceneManager.LoadScene(0);
        Destroy(gameObject);
    }
    public void OpenQuest()
    {
        Debug.Log("Hap");
        FindObjectOfType<Testing>().CanBeAccest(false);
        QuestWindow.SetActive(true);
        if (MDS.whatMission == 0)
        {
            Selected = data[0];
            Selected.isActive = true;
            Selected.QG.requiredAmount = data[0].QG.requiredAmount;
        }
        else if (MDS.whatMission == 1)
        {
            Selected = data[1];
            Selected.isActive = true;
            Selected.QG.requiredAmount = data[1].QG.requiredAmount;
        }
        else if (MDS.whatMission == 2)
        {
            Selected = data[2];
            Selected.isActive = true;
            Selected.QG.requiredAmount = data[2].QG.requiredAmount;
        }
        else
        {
            Debug.Log("error");
        }
        Set = true;
        beenseen = true;
    }
    private void SetData()
    {
        Condition.text = Selected.condition;
        Description.text = Selected.description;
        Accept.onClick.AddListener(ActivateQuest);
    }
    public void ActivateQuest()
    {
        QuestWindow.SetActive(false);
        FindObjectOfType<Testing>().CanBeAccest(true);
    }
    public void FinnishedQuest()
    {
        FinnishedQuestTemp.SetActive(true);
        FindObjectOfType<Testing>().CanBeAccest(false);

    }
}
