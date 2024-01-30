using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWeeks : MonoBehaviour
{
    private int daysPassed = 0;
    [HideInInspector]private int currentWeek = 1;
    public GrowthManager[] growthManagers;

    public Text weekText; // UI Text to display the current week

    private void Start()
    {
        UpdateWeekDisplay();
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnButtonClick();
        }
    }
    public void OnButtonClick()
    {
        daysPassed++; 
        if (daysPassed >= 7)
        {
            for(int i = 0; i< growthManagers.Length; i++)
            {
                growthManagers[i].AddAditionalGrowth();
            }
            currentWeek++;
            daysPassed = 0; 
        }
        UpdateWeekDisplay();
    }

    // Updates the week display text
    private void UpdateWeekDisplay()
    {
        if (weekText != null)
        {
            weekText.text = "Week: " + currentWeek.ToString() + " " + "Day: " + daysPassed.ToString();
        }
    }
}
