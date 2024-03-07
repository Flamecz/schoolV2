using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPrefabUnits : MonoBehaviour
{
    public GameObject buyUnitprefab;
    public GameObject parent;
    public ResourceManager resourceManger;
    public Unit unit1, unit2;
    //Parametrs of Prefab
    private Text recruteText;
    private Image unitImage1, unitImage2;
    private Button unitImage1Button, unitImage2Button;
    private Text costForOne, costForAll;
    private Text availableRecrutes, recrutableRecrutes;
    private Slider slider;
    private Button buyUnitsButton, cancelButton;

    private bool leftSelected = true;
    private GameObject Instance;
    public GrowthManager growthManager;
    void Start()
    {
        var button = gameObject.GetComponent<Button>();
        if (button != null)
        {
            button.onClick.AddListener(CreatePopUp);
        }
    }

    public void GetData()
    {
        Instance = Instantiate(buyUnitprefab, parent.transform);
        Transform image = Instance.transform.Find("Image");
        recruteText = image.Find("RecruteText").GetComponent<Text>();
        unitImage1 = image.Find("UpgradedImageBorder").Find("UpgradedImage").GetComponent<Image>();
        unitImage2 = image.Find("NonUpgradedImageBorder").Find("NonUpgradedImage").GetComponent<Image>();
        unitImage1Button = image.Find("UpgradedImageBorder").Find("UpgradedImage").GetComponent<Button>();
        unitImage2Button = image.Find("NonUpgradedImageBorder").Find("NonUpgradedImage").GetComponent<Button>();


        costForOne = image.Find("CostPerTroope").Find("Frame").Find("Cost").Find("Text").GetComponent<Text>();
        costForAll = image.Find("CostForAll").Find("Frame").Find("Cost").Find("Text").GetComponent<Text>();
        availableRecrutes = image.Find("AvaibleToRecruteUnits").Find("Amount").GetComponent<Text>();
        recrutableRecrutes = image.Find("RecruteToRecruteUnits").Find("Amount").GetComponent<Text>();
        slider = image.Find("Slider").GetComponent<Slider>();
        buyUnitsButton = image.Find("BuyUnitsButton").GetComponent<Button>();
        buyUnitsButton.onClick.AddListener(buyUnits);
        Transform cancel = image.Find("CancelButton");
        cancelButton = cancel.GetComponent<Button>();
        cancelButton.onClick.AddListener(DemolishPopUp);
    }
    public void SetDataWithUpgradedBuilding()
    {
        GetData();
        slider.onValueChanged.AddListener(delegate { UpdateStats(); });
        recruteText.text = "Recrute " + unit1.unitName;
        unitImage1.sprite = unit1.imageInBattle;
        unitImage2.sprite = unit2.imageInBattle;
        unitImage1Button.onClick.AddListener(SelectedLeft);
        unitImage2Button.onClick.AddListener(SelectedRight);

        if (leftSelected)
        {
            costForOne.text = unit1.cost.ToString();
            int max = growthManager.CalculateUnits(unit1);
            slider.maxValue = max;
            float moneyCost = slider.value * unit1.cost;
            costForAll.text = moneyCost.ToString();
            availableRecrutes.text = max.ToString();
            int wholeCount = (int)slider.value;
            recrutableRecrutes.text = wholeCount.ToString();
        }
        else
        {
            costForOne.text = unit2.cost.ToString();
            int max = growthManager.CalculateUnits(unit2);
            slider.maxValue = max;
            float moneyCost = slider.value * unit2.cost;
            costForAll.text = moneyCost.ToString();
            availableRecrutes.text = max.ToString();
            int wholeCount = (int)slider.value;
            recrutableRecrutes.text = wholeCount.ToString();
        }
    }
    public void SetDataWithoutUpgradedBuilding()
    {
        GetData();
        slider.onValueChanged.AddListener(delegate { UpdateStats(); });
        recruteText.text = "Recrute " + unit2.unitName;
        unitImage1.sprite = unit1.imageInBattle;
        unitImage2.sprite = unit2.imageInBattle;

        costForOne.text = unit2.cost.ToString();
        int max = growthManager.CalculateUnits(unit2);
        slider.maxValue = max;
        float moneyCost = slider.value * unit2.cost;
        costForAll.text = moneyCost.ToString();
        availableRecrutes.text = max.ToString();
        int wholeCount = (int)slider.value;
        recrutableRecrutes.text = wholeCount.ToString();
    }   
    public void CreatePopUp()
    {
        parent.gameObject.SetActive(true);

        SetDataWithoutUpgradedBuilding();
    }
    public void DemolishPopUp()
    {
        Destroy(Instance);
    }
    private void UpdateStats()
    {
        float moneyCost = slider.value * unit2.cost;
        costForAll.text = moneyCost.ToString();
        int wholeCount = (int)slider.value;
        recrutableRecrutes.text = wholeCount.ToString();
    }
    public void buyUnits()
    {
        int wholeCount = (int)slider.value;
        int moneycost = wholeCount * unit2.cost;

        growthManager.currentBuyableUnits -= wholeCount;
        resourceManger.Gold -= moneycost;

        FindObjectOfType<InvenotoryManagement>().AddItem(unit2, wholeCount);
        DemolishPopUp();
    }
    private void SelectedLeft()
    {
        leftSelected = true;
    }
    private void SelectedRight()
    {
        leftSelected = false;
    }
}
