using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Quest
{
    public string condition;
    public string description;
    public bool isActive;
    public bool Finnished;
    public QuestGoal QG;
    public void complete()
    {
        isActive = false;
        Finnished = true;
    }
}
