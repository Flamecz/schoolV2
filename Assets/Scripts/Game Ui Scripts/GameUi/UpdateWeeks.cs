using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateWeeks : MonoBehaviour
{
    private int daysPassed = 0;
    private int currentWeek = 1;

    public Text weekText; // UI Text to display the current week

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            OnButtonClick();
        }
    }
    // Function to call when the button is clicked
    public void OnButtonClick()
    {
        daysPassed++; // Advance one day
        if (daysPassed >= 7) // A week has passed
        {
            currentWeek++; // Advance to the next week
            daysPassed = 0; // Reset the days passed
        }

        UpdateWeekDisplay(); // Update the UI to show the current week
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
