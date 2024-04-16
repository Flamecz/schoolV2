using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWeeks : MonoBehaviour
{
    public Days daysPassed;
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
        FindFirstObjectByType<Townhall>().income(); 
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
