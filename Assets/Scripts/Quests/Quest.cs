using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public bool isActive;
    public bool Finnished;


    public void complete()
    {
        isActive = false;
        Finnished = true;
    }
}
