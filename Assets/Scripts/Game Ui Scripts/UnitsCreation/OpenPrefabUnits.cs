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
    public CityBuldings buildingToCheck;
    public int unitNumber1, unitNumber2;
    public int buildingNumber;
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
        unit1 = FindObjectOfType<BuildingManager>().UnitSetting[unitNumber1];
        unit2 = FindObjectOfType<BuildingManager>().UnitSetting[unitNumber2];
        buildingToCheck = FindObjectOfType<BuildingManager>().CityBuldings[buildingNumber];
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
        Transform cancel = image.Find("CancelButton");
        cancelButton = cancel.GetComponent<Button>();
        cancelButton.onClick.AddListener(DemolishPopUp);
    }
    public void SetDataWithUpgradedBuilding()
    {
        GetData();
        recruteText.text = "Recrute " + unit1.unitName;
        unitImage1.sprite = unit1.imageInBattle;
        unitImage2.sprite = unit2.imageInBattle;

        // Button click handlers
        unitImage1Button.onClick.AddListener(() =>
        {
            SelectedLeft();
            UpdateUI(unit1);
            buyUnitsButton.onClick.RemoveAllListeners(); // Remove previous listeners
            buyUnitsButton.onClick.AddListener(() => buyUnits(unit1)); // Add new listener for buying units
        });

        unitImage2Button.onClick.AddListener(() =>
        {
            SelectedRight();
            UpdateUI(unit2);
            buyUnitsButton.onClick.RemoveAllListeners(); // Remove previous listeners
            buyUnitsButton.onClick.AddListener(() => buyUnits(unit2)); // Add new listener for buying units
        });
    }
    void UpdateUI(Unit unit)
    {
        Debug.Log("Updating UI for " + unit.unitName);
        slider.onValueChanged.RemoveAllListeners();
        slider.onValueChanged.AddListener(delegate { UpdateStats(unit); });

        costForOne.text = unit.cost.ToString();
        int max = growthManager.CalculateUnits(unit);
        slider.maxValue = max;
        float moneyCost = slider.value * unit.cost;
        costForAll.text = moneyCost.ToString();
        availableRecrutes.text = max.ToString();
        int wholeCount = (int)slider.value;
        recrutableRecrutes.text = wholeCount.ToString();
    }
    public void SetDataWithoutUpgradedBuilding()
    {
        GetData();
        slider.onValueChanged.AddListener(delegate { UpdateStats(unit2); });
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
        if(buildingToCheck.builded && buildingToCheck.upgraded)
        {
            SetDataWithUpgradedBuilding();
            unitImage1Button.enabled = true;
        }
        else if(buildingToCheck.builded && !buildingToCheck.upgraded)
        {
            SetDataWithoutUpgradedBuilding();
            unitImage1Button.enabled = false;
        }
        else
        {

        }
    }
    public void DemolishPopUp()
    {
        Destroy(Instance);
    }
    private void UpdateStats(Unit unit)
    {
        float moneyCost = slider.value * unit.cost;
        costForAll.text = moneyCost.ToString();
        int wholeCount = (int)slider.value;
        recrutableRecrutes.text = wholeCount.ToString();
    }
    public void buyUnits(Unit selected)
    {
        int wholeCount = (int)slider.value;
        int moneycost = wholeCount * selected.cost;

        growthManager.currentBuyableUnits -= wholeCount;
        resourceManger.Data.Gold -= moneycost;

        FindObjectOfType<InvenotoryManagement>().AddItem(selected, wholeCount);
        DemolishPopUp();
    }
    private void SelectedLeft()
    {
        Debug.Log("left");
        leftSelected = true;
    }
    private void SelectedRight()
    {
        Debug.Log("Right");
        leftSelected = false ;
    }
}
