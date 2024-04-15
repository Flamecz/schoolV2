using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Townhall : MonoBehaviour
{
    public bool upgraded;
    public CityBuldings save;
    private int incomeAmount;
    public void income()
    {
        if(save.upgraded)
        {
            incomeAmount = 1500;
            FindObjectOfType<ResourceManager>().Data.Gold += incomeAmount;
        }
        else
        {
            incomeAmount = 500;
            FindObjectOfType<ResourceManager>().Data.Gold += incomeAmount;
        }
    }
}
