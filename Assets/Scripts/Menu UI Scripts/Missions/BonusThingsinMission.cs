using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusThingsinMission 
{
    public Sprite image;
    public string name;
    public string description;

    public int count;
    
    public bool isBool;

    // public bool isUpgradeable;

    public BonusThingsinMission(string name, Sprite image, string description)
    {
       this.name = name;
       this.image = image;
       this.description = description;
    }
    public BonusThingsinMission(string name, Sprite image, string description, int count)
    {
        this.name = name;
        this.image = image;
        this.description = description;
        this.count = count;
    }
    public BonusThingsinMission(string name, Sprite image, string description, bool isBool)
    {
        this.name = name;
        this.image = image;
        this.description = description;
        this.isBool = isBool;
    }

}
