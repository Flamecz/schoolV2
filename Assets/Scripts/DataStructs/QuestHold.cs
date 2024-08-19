using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "QuestHold", menuName = "QuestHold/QuestHold")]
public class QuestHold : ScriptableObject
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
