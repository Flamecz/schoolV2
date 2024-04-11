using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStatsOfUnits : MonoBehaviour
{
    public Unit  ut;
    public GrowthManager gM;
    public string nameOfTrueBuilding;
    public GameObject Canvas;
    public CityBuldings building;
    public int buildingNumber;

    private Text UnitName;
    private Image BuildingSprite;
    private Text BuildingName;
    private Text UnitsAvaible;

    private Image UnitSprite;

    private Image ImageStats1;
    private Text TextOfStats1;
    private Text TextStats1;

    private Image ImageStats2;
    private Text TextOfStats2;
    private Text TextStats2;

    private Image ImageStats3;
    private Text TextOfStats3;
    private Text TextStats3;

    private Image ImageStats4;
    private Text TextOfStats4;
    private Text TextStats4;

    private Image ImageStats5;
    private Text TextOfStats5;
    private Text TextStats5;

    private Image ImageStats6;
    private Text TextOfStats6;
    private Text TextStats6;

    void Start()
    {
        building = FindObjectOfType<BuildingManager>().CityBuldings[buildingNumber];
        GetData();
    }

    // Update is called once per frame
    void Update()
    {
        SetData();
    }
    public void GetData()
    {
        UnitName = Canvas.transform.Find("Image/Unit Name Holder/Name").GetComponent<Text>();
        BuildingName = Canvas.transform.Find("Image/Bulding Name Holder/Name").GetComponent<Text>();
        UnitsAvaible = Canvas.transform.Find("Image/Unit Amount Holder/Available").GetComponent<Text>();
        BuildingSprite = Canvas.transform.Find("Image/Bulding Sprite").GetComponent<Image>();

        UnitSprite = Canvas.transform.Find("Unit Sprite").GetComponent<Image>();

        ImageStats1 = Canvas.transform.Find("stats/Unit Image Holder").GetComponent<Image>();
        TextOfStats1 = Canvas.transform.Find("stats/Unit Amount Holder/Available").GetComponent<Text>();
        TextStats1 = Canvas.transform.Find("stats/Unit Amount Holder/Text").GetComponent<Text>();

        ImageStats2 = Canvas.transform.Find("stats1/Unit Image Holder").GetComponent<Image>();
        TextOfStats2 = Canvas.transform.Find("stats1/Unit Amount Holder/Available").GetComponent<Text>();
        TextStats2 = Canvas.transform.Find("stats1/Unit Amount Holder/Text").GetComponent<Text>();

        ImageStats3 = Canvas.transform.Find("stats2/Unit Image Holder").GetComponent<Image>();
        TextOfStats3 = Canvas.transform.Find("stats2/Unit Amount Holder/Available").GetComponent<Text>();
        TextStats3 = Canvas.transform.Find("stats2/Unit Amount Holder/Text").GetComponent<Text>();

        ImageStats4 = Canvas.transform.Find("stats3/Unit Image Holder").GetComponent<Image>();
        TextOfStats4 = Canvas.transform.Find("stats3/Unit Amount Holder/Available").GetComponent<Text>();
        TextStats4 = Canvas.transform.Find("stats3/Unit Amount Holder/Text").GetComponent<Text>();

        ImageStats5 = Canvas.transform.Find("stats4/Unit Image Holder").GetComponent<Image>();
        TextOfStats5 = Canvas.transform.Find("stats4/Unit Amount Holder/Available").GetComponent<Text>();
        TextStats5 = Canvas.transform.Find("stats4/Unit Amount Holder/Text").GetComponent<Text>();

        ImageStats6 = Canvas.transform.Find("stats5/Unit Image Holder").GetComponent<Image>();
        TextOfStats6 = Canvas.transform.Find("stats5/Unit Amount Holder/Available").GetComponent<Text>();
        TextStats6 = Canvas.transform.Find("stats5/Unit Amount Holder/Text").GetComponent<Text>();
    }
    public void SetData()
    {
        //left side of Data
        UnitName.text = ut.unitName;
        //BuildingSprite.sprite = 
        BuildingName.text = nameOfTrueBuilding;
        if(building.builded)
        {
            this.gameObject.GetComponent<Button>().enabled = true;
            UnitsAvaible.text = "Available : " + gM.currentBuyableUnits.ToString();
        }
        else
        {
            this.gameObject.GetComponent<Button>().enabled = false;
        }
        //Image Data
        UnitSprite.sprite = ut.sprite;
        //UnitSprite.sprite = ut.sprite;

        //Right side of Data
        TextStats1.text = "Attack :";
        TextOfStats1.text = ut.damage.ToString();

        TextStats2.text = "Defence :";
        TextOfStats2.text = ut.defence.ToString();

        TextStats3.text = "Damage :";
        TextOfStats3.text = ut.minDamage.ToString() + "-" + ut.maxDamage.ToString();

        TextStats4.text = "Health :";
        TextOfStats4.text = ut.health.ToString();

        TextStats5.text = "Speed :";
        TextOfStats5.text = ut.speed.ToString();

        TextStats6.text = "Growth :";
        TextOfStats6.text = ut.growth.ToString();


    }
}
