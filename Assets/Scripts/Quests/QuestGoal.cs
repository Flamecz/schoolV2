using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public string WhatToGet;
    public int requiredAmount;
    public int currentAmount;
    public bool QuestDone()
    {
        return (currentAmount >= requiredAmount);
    }
    public void QuestGatherd()
    {
        if (goalType == GoalType.Kill)
        {
            currentAmount++;
        }
        if (goalType == GoalType.Gather)
        {
            currentAmount++;
        }
        if (goalType == GoalType.GetTo)
        {
            currentAmount++;
        }
    }
}

public enum GoalType
{
    Kill,
    Gather,
    GetTo
}
