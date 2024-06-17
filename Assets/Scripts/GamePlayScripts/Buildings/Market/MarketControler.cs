using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MarketControler : MonoBehaviour
{
    public int index1;
    public int index2;
    public ResourceManager RM;
    public Button utilityButton;

    private int resource;
    private int count;
    

    private void Awake()
    {
        utilityButton.onClick.AddListener(CalculateSubstraction);
    }
    public void GetResource(int resource)
    {
        this.resource = resource;
    }
    public void GetCount(int count)
    {
        this.count = count;
    }
    public void GetIndex(int index)
    {
        this.index1 = index;
    }
    public void GetIndex2(int index)
    {
        this.index2 = index;
    }
    public int ReturnCount()
    {
        return count * resource;
    }
    public void CalculateSubstraction()
    {
        switch (index1)
        {
            case 0:
                RM.ModifyResources("Wood", -ReturnCount());
                FindObjectOfType<SliderUpdate>().slider.maxValue = 0;
                index1 = 0;
                index2 = 0;
                break;
            case 1:
                RM.ModifyResources("Iron", -ReturnCount());
                FindObjectOfType<SliderUpdate>().slider.maxValue = 0;
                index1 = 0;
                index2 = 0;
                break;
            case 2:
                RM.ModifyResources("Stone", -ReturnCount());
                FindObjectOfType<SliderUpdate>().slider.maxValue = 0;
                index1 = 0;
                index2 = 0;
                break;
            case 3:
                RM.ModifyResources("Sulfur", -ReturnCount());
                FindObjectOfType<SliderUpdate>().slider.maxValue = 0;
                index1 = 0;
                index2 = 0;
                break;
            case 4:
                RM.ModifyResources("Minerals", -ReturnCount());
                FindObjectOfType<SliderUpdate>().slider.maxValue = 0;
                index1 = 0;
                index2 = 0;
                break;
            case 5:
                RM.ModifyResources("Gems", -ReturnCount());
                FindObjectOfType<SliderUpdate>().slider.maxValue = 0;
                index1 = 0;
                index2 = 0;
                break;
            case 6:
                RM.ModifyResources("Gold", +ReturnCount());
                FindObjectOfType<SliderUpdate>().slider.maxValue = 0;
                index1 = 0;
                index2 = 0;
                break;
        }
        switch (index2)
        {
            case 0:
                RM.ModifyResources("Wood", count);
                break;
            case 1:
                RM.ModifyResources("Iron", count);
                break;
            case 2:
                RM.ModifyResources("Stone", count);
                break;
            case 3:
                RM.ModifyResources("Sulfur", count);
                break;
            case 4:
                RM.ModifyResources("Minerals", count);
                break;
            case 5:
                RM.ModifyResources("Gems", count);
                break;
            case 6:
                RM.ModifyResources("Gold", +ReturnCount());
                break;
        }
    }
}
