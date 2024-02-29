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
    private Button leftButton, rightButton;
    private Button somethingButton, buyUnitsButton, cancelButton;

    private bool leftSelected;
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
        somethingButton = image.Find("SomethingButton").GetComponent<Button>();
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

        if(leftSelected)
        {
            costForOne.text = unit1.cost.ToString();
            float moneyCost = slider.value * unit1.cost;
            costForAll.text = moneyCost.ToString();
        }
        else
        {
            costForOne.text = unit2.cost.ToString();
            float moneyCost = slider.value * unit2.cost;
            costForAll.text = moneyCost.ToString();
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
        growthManager.CalculateUnits(unit2);
        slider.maxValue = growthManager.currentBuyableUnits;
        float moneyCost = slider.value * unit2.cost;
        costForAll.text = moneyCost.ToString();
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
    }
}
