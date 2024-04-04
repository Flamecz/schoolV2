using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrowthManager : MonoBehaviour
{
    public ResourceManager resourceManager;
    public int currentBuyableUnits;
    public Unit unit;
    private void Start()
    {
        
        currentBuyableUnits = unit.growth;
    }
    public int CalculateUnits(Unit unit)
    {
        int numberOfUnits = Mathf.Min(currentBuyableUnits, resourceManager.Data.Gold / unit.cost);

        if (numberOfUnits > 0)
        {
            Debug.Log("You can buy " + numberOfUnits + " units.");
            return numberOfUnits;
        }
        else
        {
            Debug.Log("Not enough gold to buy any units.");
            return 0;
        }
    }
    public void AddAditionalGrowth()
    {
        currentBuyableUnits += unit.growth;
    }
}
