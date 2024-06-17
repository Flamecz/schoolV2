using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitDisplay : MonoBehaviour
{
    public Image[] images;
    public InvetorySaver inventorysaver;
    void Awake()
    {
        for(int i = 0; i < inventorysaver.unitList.Length- 1;i++)
        {
            if(inventorysaver.unitList[i] != null)
            {
                var tempColor = images[i].color;
                tempColor.a = 1f;
                images[i].color = tempColor;
                images[i].sprite = inventorysaver.unitList[i].sprite;
            }
        }
    }
}
