using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUiManager : MonoBehaviour
{
    public GameObject cavas;
    public Sprite alliedHero, enemyHero;
    public string alliedHeroName, enemyHeroName;
    public RuntimeAnimatorController winAnimation, lossAnimation;
    private Transform main;
    private Image alliedHeroImage, enemyHeroImage;
    private Text alliedHeroNameText, enemyHeroNameText;
    private Text alliedStatus, enemyStatus;
    private Animator animator;
    private Text StateDescription, BattleDescription;
    private GameObject PlayerLosses, EnemyLosses;

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
    }
    public void SetWinData()
    {
        alliedHeroImage.sprite = alliedHero;
        enemyHeroImage.sprite = enemyHero;
        alliedHeroNameText.text = alliedHeroName;
        enemyHeroNameText.text = enemyHeroName;
        alliedStatus.text = "Victory";
        enemyStatus.text = "Defeat";
        animator.runtimeAnimatorController = winAnimation;
    }
    public void SetLossData()
    {
        alliedHeroImage.sprite = alliedHero;
        enemyHeroImage.sprite = enemyHero;
        alliedHeroNameText.text = alliedHeroName;
        enemyHeroNameText.text = enemyHeroName;
        alliedStatus.text = "Defeat";
        enemyStatus.text = "Victory";
        animator.runtimeAnimatorController = lossAnimation;
    }
    public string NameReturn(string name)
    {
        return null;
    }
}
