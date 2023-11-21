using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    public Button button;
    public Image background;
    public static ButtonController selectedButton;

    public void OnSelect(BaseEventData eventData)
    {
        // If another button is selected, deselect it
        if (selectedButton != null && selectedButton != this)
        {
            selectedButton.button.OnDeselect(eventData);
        }

        // Select this button
        selectedButton = this;

        // Change the background color
        background.color = Color.red;
    }

    public void OnDeselect(BaseEventData eventData)
    {
        // Deselect this button
        selectedButton = null;

        // Change the background color back to normal
        background.color = Color.white;
    }
}
