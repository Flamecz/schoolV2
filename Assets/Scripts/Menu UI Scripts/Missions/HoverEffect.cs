using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverEffect : MonoBehaviour, IPointerClickHandler
{
    private static bool hold = false;
    public int buttonIndex;
    public GameObject[] BackG;
    public GameObject ActiveWindow;
    public Text SetText;
    public bool bonusTaken;
    private void Start()
    {
        imageBack();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (!hold)
            {
                ActiveWindow.SetActive(true);
                SetText.text = FindObjectOfType<MissionCreator>().GetInfo(buttonIndex).ToString();
                hold = true;
            }
            else if (hold)
            {
                ActiveWindow.SetActive(false);
                hold = false;
            }
        }
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            imageBack();
            BackG[buttonIndex].SetActive(true);
            FindObjectOfType<DataSender>().GetIndex(buttonIndex);
            bonusTaken = true;
            FindObjectOfType<MissionCreator>().IsNotInteractable(bonusTaken);
        }

    }
    public void imageBack()
    {
        for (int i = 0; i < BackG.Length; i++)
        {
            BackG[i].SetActive(false);
        }
        bonusTaken = false;
        FindObjectOfType<MissionCreator>().IsNotInteractable(bonusTaken);
    }
}
