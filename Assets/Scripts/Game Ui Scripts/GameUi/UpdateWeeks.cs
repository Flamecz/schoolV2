using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWeeks : MonoBehaviour
{
    public Days daysPassed;
    public GrowthManager[] growthManagers;
    public CityBuldings town;
    public Text weekText; // UI Text to display the current week

    private void Start()
    {
        UpdateWeekDisplay();
    }
    public void OnButtonClick()
    {
        daysPassed.days++; 
        if (daysPassed.days >= 7)
        {
            for(int i = 0; i< growthManagers.Length; i++)
            {
                growthManagers[i].AddAditionalGrowth();
            }
            daysPassed.weeks++;
            daysPassed.days = 0; 
        }
        UpdateWeekDisplay();
        if (town.upgraded)
        {
            int incomeAmount = 1500;
            FindObjectOfType<ResourceManager>().Data.Gold += incomeAmount;
        }
        else
        {
            int incomeAmount = 500;
            FindObjectOfType<ResourceManager>().Data.Gold += incomeAmount;
        }
    }

    // Updates the week display text
    private void UpdateWeekDisplay()
    {
        if (weekText != null)
        {
            weekText.text = "Week: " + daysPassed.weeks.ToString() + " " + "Day: " + daysPassed.days.ToString();
        }
    }
}
