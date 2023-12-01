using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverEffect : MonoBehaviour, IPointerClickHandler
{
    private static bool hold;
    public GameObject ActiveWindow;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (Input.GetKey(KeyCode.Mouse2))
        {
            if (!hold)
            {
                ActiveWindow.SetActive(true);
                
            }
        }
    }
}
