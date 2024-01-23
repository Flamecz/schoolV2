using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenPrefabUnits : MonoBehaviour
{
    public GameObject buyUnitprefab;
    public GameObject parent;
    public ResourceManager resourceManger;
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
    void Start()
    {
        Instantiate(buyUnitprefab, parent.transform);
        GetData();
    }

    public void GetData()
    {
        Transform image = buyUnitprefab.transform.Find("Image");
        recruteText = image.Find("RecruteText").GetComponent<Text>();
        unitImage1 = image.Find("UpgradedImage").GetComponent<Image>();
        unitImage2 = image.Find("NonUpgradedImage").GetComponent<Image>();
        unitImage1Button = image.Find("UpgradedImage").GetComponent<Button>();
        unitImage2Button = image.Find("NonUpgradedImage").GetComponent<Button>();


        costForOne = image.Find("CostPerTroope").Find("Frame").Find("Cost").Find("Text").GetComponent<Text>();
        costForOne = image.Find("CostForAll").Find("Frame").Find("Cost").Find("Text").GetComponent<Text>();
        availableRecrutes = image.Find("AvaibleToRecruteUnits").Find("Amount").GetComponent<Text>();
        recrutableRecrutes = image.Find("RecruteToRecruteUnits").Find("Amount").GetComponent<Text>();
        slider = image.Find("Slider").GetComponent<Slider>();
        somethingButton = image.Find("SomethingButton").GetComponent<Button>();
        buyUnitsButton = image.Find("BuyUnitsButton").GetComponent<Button>();
        cancelButton = image.Find("CancelButton").GetComponent<Button>();
    }
    public void SetDataWithUpgradedBuilding(Unit unit1, Unit unit2)
    {
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
    public void SetDataWithoutUpgradedBuilding(Unit unit1, Unit unit2)
    {
        recruteText.text = "Recrute " + unit2.unitName;
        unitImage1.sprite = unit1.imageInBattle;
        unitImage2.sprite = unit2.imageInBattle;

        costForOne.text = unit2.cost.ToString();
        float moneyCost = slider.value * unit2.cost;
        costForAll.text = moneyCost.ToString();

        float howManyToRecrute = resourceManger.Gold / unit2.cost;

    }
    public void CalculateUnits(Unit unit)
    {
        int numberOfUnits = resourceManger.Gold / unit.cost;

        // Ensure we have enough gold to buy at least one unit
        if (numberOfUnits > 0)
        {
            int totalCost = numberOfUnits * unit.cost;
            Debug.Log("Number of Units you can buy: " + numberOfUnits);
            Debug.Log("Total Cost: " + totalCost + " gold");

            // Deduct the cost from available gold
            resourceManger.Gold  -= totalCost;
            Debug.Log("Remaining Gold: " + resourceManger.Gold + " gold");
        }
        else
        {
            Debug.Log("Not enough gold to buy any units.");
        }
    }
}
