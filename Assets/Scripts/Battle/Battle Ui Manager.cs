using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleUiManager : MonoBehaviour
{
    public Sprite alliedHero, enemyHero;
    public string alliedHeroName, enemyHeroName;
    private Transform main;
    private Image alliedHeroImage, enemyHeroImage;
    private Text alliedHeroNameText, enemyHeroNameText;
    private Text alliedStatus, enemyStatus;
    private Image gif;
    private Text StateDescription, BattleDescription;

    private void Awake()
    {
        
    }
    public void GetData()
    {
        main = gameObject.transform.Find("Leather");
        alliedHeroImage = main.transform.Find("AlliedFrame").Find("HeroImage").GetComponent<Image>();
        enemyHeroImage = main.transform.Find("EnemyFrame").Find("EnemyHero").GetComponent<Image>();
        alliedHeroNameText = main.transform.Find("AlliedNameFrame").Find("Name").GetComponent<Text>();
        enemyHeroNameText = main.transform.Find("EnemyNameFrame").Find("Name").GetComponent<Text>();
        alliedStatus = main.transform.Find("AlliedStateOfBattle").Find("Name").GetComponent<Text>();
        enemyStatus = main.transform.Find("EnemyStateOfBattle").Find("Name").GetComponent<Text>();
        gif = main.transform.Find("Gif").GetComponent<Image>();
        StateDescription = main.transform.Find("DescriptionFrame").Find("StateDescription").GetComponent<Text>();
        BattleDescription = main.transform.Find("DescriptionFrame").Find("BattleDescription").GetComponent<Text>();
    }
    public void SetData()
    {
        alliedHeroImage.sprite = alliedHero;
        enemyHeroImage.sprite = enemyHero;
    }
    public string NameReturn(string name)
    {
        return 
    }
}
