using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public ResourceManager resourceManager;
    public int currentBuyableUnits;
    public Unit unit;
    private void startingUnits(Unit unit)
    {
        currentBuyableUnits = unit.growth;
    }
    public void CalculateUnits(Unit unit)
    {
        int numberOfUnits = resourceManager.Gold / unit.cost;

        if (numberOfUnits > 0)
        {
            int totalCost = numberOfUnits * unit.cost;
            resourceManager.Gold -= totalCost;
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
