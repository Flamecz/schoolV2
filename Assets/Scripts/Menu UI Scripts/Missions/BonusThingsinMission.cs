using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bonusses", menuName = "Bonusses")]
public class BonusThingsinMission :ScriptableObject
{
    public Sprite image;
    public string name;
    public string description;
    public int count; 
    public bool isBool;
}
