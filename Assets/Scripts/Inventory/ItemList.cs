using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemList : MonoBehaviour
{
    public InvenotoryManagement Im;
    public Unit[] units;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            Im.AddItem(units[0]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Im.AddItem(units[1]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Im.AddItem(units[2]);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Im.AddItem(units[3]);
        }

    }
}
