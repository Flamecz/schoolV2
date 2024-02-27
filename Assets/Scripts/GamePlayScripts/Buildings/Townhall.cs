using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Townhall : MonoBehaviour
{
    public bool upgraded;
    private int incomeAmount;
    public void income()
    {
        if(upgraded)
        {
            incomeAmount = 1500;
            FindObjectOfType<ResourceManager>().Gold += incomeAmount;
        }
        else
        {
            incomeAmount = 500;
            FindObjectOfType<ResourceManager>().Gold += incomeAmount;
        }
    }
}
