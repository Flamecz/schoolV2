using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

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
    public GameObject cutScene;
    public VideoClip win, loss;
    public Button GoBack;
    public GameObject End;

    private Text Condition;
    private Text Description;
    private Button Accept;
    private bool Set = false;
    private bool beenseen;
    private Button Resume,abandon,SaveandBack;

    private string sceneName;

    private void Start()
    {
        sceneName = SceneManager.GetActiveScene().name;
        Debug.Log(sceneName);

        if (!beenseen && !PlayerPrefs.HasKey(sceneName))
        {
            OpenQuest();
        }
    }
    void Awake()
    {
        if (Set)
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
        }
    }

    private void Update()
    {
        bool isdone = Selected.QG.QuestDone();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
        }
    }
    public void Pause()
    {
        End.SetActive(true);
        Resume = End.transform.Find("Resume").GetComponent<Button>();
        abandon = End.transform.Find("Abandon").GetComponent<Button>();
        SaveandBack = End.transform.Find("SaveandBack").GetComponent<Button>();

        Resume.onClick.AddListener(ResumeTime);
        abandon.onClick.AddListener(Abandon);
        SaveandBack.onClick.AddListener(LoadScene0);
        Time.timeScale = 0; 
    }
    private void ResumeTime()
    {
        Time.timeScale = 1;
        End.SetActive(false);
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
            Debug.Log("Hap1");
        }
        else if (MDS.whatMission == 1)
        {
            Selected = data[1];
            Selected.isActive = true;
            Selected.QG.requiredAmount = data[1].QG.requiredAmount;
            Debug.Log("Hap1");
        }
        else if (MDS.whatMission == 2)
        {
            Selected = data[2];
            Selected.isActive = true;
            Selected.QG.requiredAmount = data[2].QG.requiredAmount;
            Debug.Log("Hap1");
        }
        else
        {
            Debug.Log("error");
        }
        Condition = QuestWindow.gameObject.transform.Find("Condition").GetComponent<Text>();
        if (Condition != null)
        {
            Debug.Log(Condition.name);
        }
        Description = QuestWindow.gameObject.transform.Find("Description").GetComponent<Text>();
        if (Description != null)
        {
            Debug.Log(Description.name);
        }
        Accept = QuestWindow.gameObject.transform.Find("Accept").GetComponent<Button>();
        if (Accept != null)
        {
            Debug.Log(Accept.name);
        }
        Condition.text = Selected.condition;
        Description.text = Selected.description;
        Accept.onClick.AddListener(ActivateQuest);
        Set = true;
        DontDestroyOnLoad(gameObject);
        PlayerPrefs.SetInt(sceneName, 1);
        PlayerPrefs.Save();
    }
    public void ActivateQuest()
    {
        QuestWindow.SetActive(false);
        FindObjectOfType<Testing>().CanBeAccest(true);
        beenseen = true;
    }
    public void FinnishedQuest()
    {
        FinnishedQuestTemp.SetActive(true);
        FindObjectOfType<Testing>().CanBeAccest(false);

        Text Condition = FinnishedQuestTemp.transform.Find("Condition").GetComponent<Text>();
        Text Description = FinnishedQuestTemp.transform.Find("Description").GetComponent<Text>();
        Button Finnish = FinnishedQuestTemp.transform.Find("Accept").GetComponent<Button>();

        Condition.text = "Victory";
        Description.text = "Your servis has been noted in history";
        Finnish.onClick.AddListener(OpenWinCutscene);
        FindObjectOfType<AudioManager>().Stop("HeroesInWorld");
    }
    public void OpenWinCutscene()
    {
        FinnishedQuestTemp.SetActive(false);
        cutScene.SetActive(true);
        VideoPlayer VP = cutScene.transform.Find("Video Player").GetComponent<VideoPlayer>();
        VP.clip = win;
        GoBack.onClick.AddListener(LoadScene0);
        PlayerPrefs.SetInt("Achivment", 1);
        int c = PlayerPrefs.GetInt("Achivment");
        PlayerPrefs.SetInt("Achivment", c + 1);
        FindObjectOfType<AudioManager>().Play("victory");
    }
    public void Abandon()
    {
        PlayerPrefs.SetInt("Setted", 0);
        End.SetActive(false);
        cutScene.SetActive(true);
        VideoPlayer VP = cutScene.transform.Find("Video Player").GetComponent<VideoPlayer>();
        VP.clip = loss;
        GoBack.onClick.AddListener(LoadScene0);
        FindObjectOfType<AudioManager>().Play("lost");
    }
    public void LoadScene0()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Stop("victory");
        FindObjectOfType<AudioManager>().Play("mainTheme");
    }
}
