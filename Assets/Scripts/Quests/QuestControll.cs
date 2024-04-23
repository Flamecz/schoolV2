using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class QuestControll : MonoBehaviour
{
    private static QuestControll instance;



    [Header("Instances")]
    public GameObject questWindow;
    public GameObject finnishedQuestTemp;
    public GameObject cutScene;
    public GameObject pauseMenu;
    [Header("Quest Data")]
    public Quest Selected;
    [Header("Controlers")]
    public MissionDataShower MDS;
    public SaveDataObject SDO;
    [Header("Misc")]
    public VideoClip win, loss;
    public Canvas canvas;
    public Texture2D StartCursor;

    private Button GoBack;
    private Text Condition;
    private Text Description;
    private Button Accept;
    private Button Resume,abandon,SaveandBack;
    private GameObject questOpen,finnishOpen,cutOpen,pauseOpen;
    private static bool OneWorks;
    private string sceneName;
    private bool sceneFound;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
       if (instance == null)
       {
         instance = this;
       }
       else
       {
         Destroy(gameObject);
         return;
       }
        Debug.Log("h");
    }

    private void Update()
    {
        if(!sceneFound)
        {
            Scene scene = SceneManager.GetActiveScene();
            sceneName = scene.name;
            canvas = FindObjectOfType<Canvas>();
            if (sceneName == "Test Scene")
            {
                sceneFound = true;
                OpenQuest();
            }
        }
        bool isdone = Selected.QG.QuestDone();
        if (Input.GetKeyDown(KeyCode.Escape) && !OneWorks)
        {
            Pause();
        }
    }
    public void Pause()
    {
        pauseOpen = Instantiate(pauseMenu, canvas.transform);
        Resume = pauseOpen.transform.Find("Resume").GetComponent<Button>();
        abandon = pauseOpen.transform.Find("Abandon").GetComponent<Button>();
        SaveandBack = pauseOpen.transform.Find("SaveandBack").GetComponent<Button>();

        Resume.onClick.AddListener(ResumeTime);
        abandon.onClick.AddListener(Abandon);
        SaveandBack.onClick.AddListener(LoadScene0);
        Time.timeScale = 0; 
    }
    private void ResumeTime()
    {
        Time.timeScale = 1;
        Destroy(pauseOpen);
    }
    public void OpenQuest()
    {
        Debug.Log("Hap");
        FindObjectOfType<Testing>().CanBeAccest(false);
        questOpen = Instantiate(questWindow, canvas.transform);
        Condition = questOpen.gameObject.transform.Find("Condition").GetComponent<Text>();
        if (Condition != null)
        {
            Debug.Log(Condition.name);
        }
        Description = questOpen.gameObject.transform.Find("Description").GetComponent<Text>();
        if (Description != null)
        {
            Debug.Log(Description.name);
        }
        Accept = questOpen.gameObject.transform.Find("Accept").GetComponent<Button>();
        if (Accept != null)
        {
            Debug.Log(Accept.name);
        }
        Condition.text = Selected.condition;
        Description.text = Selected.description;
        Accept.onClick.AddListener(ActivateQuest);
        OneWorks = true;
    }
    public void ActivateQuest()
    {
        Destroy(questOpen);
        FindObjectOfType<Testing>().CanBeAccest(true);
        OneWorks = false;
    }
    public void FinnishedQuest()
    {
        finnishOpen = Instantiate(finnishedQuestTemp, canvas.transform);
        FindObjectOfType<Testing>().CanBeAccest(false);

        Text Condition = finnishOpen.transform.Find("Condition").GetComponent<Text>();
        Text Description = finnishOpen.transform.Find("Description").GetComponent<Text>();
        Button Finnish = finnishOpen.transform.Find("Accept").GetComponent<Button>();

        Condition.text = "Victory";
        Description.text = "Your servis has been noted in history";
        Finnish.onClick.AddListener(OpenWinCutscene);
        FindObjectOfType<AudioManager>().Stop("HeroesInWorld");
        OneWorks = true;
    }
    public void OpenWinCutscene()
    {
        Destroy(finnishOpen);
        cutOpen = Instantiate(cutScene, canvas.transform);
        GoBack = cutOpen.transform.Find("BackButton").GetComponent<Button>();
        VideoPlayer VP = cutOpen.transform.Find("Video Player").GetComponent<VideoPlayer>();
        VP.clip = win;
        GoBack.onClick.AddListener(LoadScene0);
        PlayerPrefs.SetInt("Achivment", 1);
        int c = PlayerPrefs.GetInt("Achivment");
        PlayerPrefs.SetInt("Achivment", c + 1);
        FindObjectOfType<AudioManager>().Play("victory");
        sceneFound = false;
        OneWorks = true;
    }
    public void Abandon()
    {
        PlayerPrefs.SetInt("Setted", 0);
        Destroy(pauseOpen);
        cutOpen = Instantiate(cutScene, canvas.transform);
        GoBack = cutOpen.transform.Find("BackButton").GetComponent<Button>();
        VideoPlayer VP = cutOpen.transform.Find("Video Player").GetComponent<VideoPlayer>();
        VP.clip = loss;
        GoBack.onClick.AddListener(LoadScene0);
        FindObjectOfType<AudioManager>().Play("lost");
        sceneFound = false;
        OneWorks = true;
    }
    public void LoadScene0()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().Stop("victory");
        FindObjectOfType<AudioManager>().Play("mainTheme");
        OneWorks = true;
    }
}
