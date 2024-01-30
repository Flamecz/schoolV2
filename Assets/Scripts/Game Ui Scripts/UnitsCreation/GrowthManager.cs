using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public ResourceManager resourceManager;
    public Unit unit;
    public int currentBuyableUnits;
    private void Start()
    {
        currentBuyableUnits = unit.growth;
    }
    public void CalculateUnits()
    {
        int numberOfUnits = resourceManager.Gold / unit.cost;

        // Ensure we have enough gold to buy at least one unit
        if (numberOfUnits > 0)
        {
            int totalCost = numberOfUnits * unit.cost;
            Debug.Log("Number of Units you can buy: " + numberOfUnits);
            Debug.Log("Total Cost: " + totalCost + " gold");

            // Deduct the cost from available gold
            resourceManager.Gold -= totalCost;
            Debug.Log("Remaining Gold: " + resourceManager.Gold + " gold");
        }
        else
        {
            Debug.Log("Not enough gold to buy any units.");
        }
    }
    public void AddAditionalGrowth()
    {
        currentBuyableUnits += unit.growth;
    }
}
