using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement ;

public class BattleUiManager : MonoBehaviour
{
    public GameObject cavas;
    public SavePlayerImages heroes;
    public string alliedHeroName, enemyHeroName;
    public RuntimeAnimatorController winAnimation, lossAnimation;
    private Transform main;
    private Image alliedHeroImage, enemyHeroImage;
    private Text alliedHeroNameText, enemyHeroNameText;
    private Text alliedStatus, enemyStatus;
    private Animator animator;
    private Text StateDescription, BattleDescription;
    private GameObject PlayerLosses, EnemyLosses;
    public EnemysToRemove remove;
    private Button Confirm;
    public GameObject Loading;
    public Image LoadingFill;
    public UnitsLost Ul;
    public GameObject lostUnitPrefab;
    public InvetorySaver PlayerUnits;
    private bool isSceneLoaded = false;
    private void Awake()
    {
        GetData();
    }
    public void GetData()
    {

        main = cavas.transform.Find("Leather");
        alliedHeroImage = main.transform.Find("AlliedFrame").Find("HeroImage").GetComponent<Image>();
        enemyHeroImage = main.transform.Find("EnemyFrame").Find("EnemyHero").GetComponent<Image>();
        alliedHeroNameText = main.transform.Find("AlliedNameFrame").Find("Name").GetComponent<Text>();
        enemyHeroNameText = main.transform.Find("EnemyNameFrame").Find("Name").GetComponent<Text>();
        alliedStatus = main.transform.Find("AlliedStateOfBattle").Find("Name").GetComponent<Text>();
        enemyStatus = main.transform.Find("EnemyStateOfBattle").Find("Name").GetComponent<Text>();
        animator = main.transform.Find("Gif").GetComponent<Animator>();
        StateDescription = main.transform.Find("DescriptionFrame").Find("StateDescription").GetComponent<Text>();
        //    BattleDescription = main.transform.Find("DescriptionFrame").Find("BattleDescription").GetComponent<Text>();
        PlayerLosses = main.transform.Find("Player").Find("Sorter").gameObject;
        EnemyLosses = main.transform.Find("Enemy").Find("Sorter").gameObject;
        Confirm = main.transform.Find("Confirm").GetComponent<Button>();
    }
    public void SetWinData()
    {
        alliedHeroImage.sprite = heroes.player;
        enemyHeroImage.sprite = heroes.enemy;
        alliedHeroNameText.text = alliedHeroName;
        enemyHeroNameText.text = enemyHeroName;
        alliedStatus.text = "Victory";
        enemyStatus.text = "Defeat";
        animator.runtimeAnimatorController = winAnimation;
        Confirm.onClick.AddListener(sendToWinMenu);
        AddLostUnits();
    }
    public void SetLossData()
    {
        alliedHeroImage.sprite = heroes.player;
        enemyHeroImage.sprite = heroes.enemy;
        alliedHeroNameText.text = alliedHeroName;
        enemyHeroNameText.text = enemyHeroName;
        alliedStatus.text = "Defeat";
        enemyStatus.text = "Victory";
        animator.runtimeAnimatorController = lossAnimation;
        Confirm.onClick.AddListener(sendToLoss);
        AddLostUnits();
    }
    public void sendToWinMenu()
    {
        if (!isSceneLoaded)
        {
            StartCoroutine(LoadScene());
            isSceneLoaded = true;
        }
        FindObjectOfType<AudioManager>().Stop("Battle");
        FindObjectOfType<AudioManager>().Play("HeroesInWorld");
        FindObjectOfType<QuestControll>().Selected.QG.currentAmount++;
        remove.Dead = true;
    }
    public void sendToLoss()
    {
        if (!isSceneLoaded)
        {
            StartCoroutine(LoadScene());
            isSceneLoaded = true;
        }
        FindObjectOfType<AudioManager>().Stop("Battle");
        FindObjectOfType<AudioManager>().Play("HeroesInWorld");
    }
    private IEnumerator LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(2);
        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
    private void AddLostUnits()
    {
        for (int i = 0; i < Ul.PlayerUnitsStart.Length; i++)
        {
            int lost1 = Ul.PlayerUnitsStart[i] - Ul.PlayerUnitsCountLost[i];
            if (Ul.PlayerUnitsStart[i] != 0)
            {
                GameObject Create = Instantiate(lostUnitPrefab, PlayerLosses.transform);
                Create.GetComponent<Image>().sprite = Ul.PlayerUnitsLost[i].sprite;
                Text text = Create.transform.Find("Count").GetComponent<Text>();
                text.text = lost1.ToString();
            }
            if(Ul.PlayerUnitsLost[i] == PlayerUnits.unitList[i])
            {
                PlayerUnits.unitCount[i] = Ul.PlayerUnitsCountLost[i];
            }
        }
        for (int i = 0; i < Ul.EnemyUnitsStart.Length; i++)
        {
            int lost2 = Ul.EnemyUnitsStart[i] - Ul.EnemyUnitsCountLost[i];
            if (Ul.EnemyUnitsStart[i] != 0)
            {
                GameObject Create = Instantiate(lostUnitPrefab, EnemyLosses.transform);
                Create.GetComponent<Image>().sprite = Ul.EnemyUnitsLost[i].sprite;
                Text text = Create.transform.Find("Count").GetComponent<Text>();
                text.text = lost2.ToString();
            }
        }
    }
}
