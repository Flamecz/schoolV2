using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="building in City",menuName = "cityBuilding")]
public class CityBuldings : ScriptableObject
{
    public string nazev;
    public Sprite Obrazek;
    public string popis;
    public GameObject objectToBuild;
    public bool canBeBuild;
    public bool builded;
    public bool canBeUpgraded;
    public bool upgraded;

    public CityBuldings required;

    public bool Done()
    {
        if (required)
        {
            if (required.builded == true)
            {
                return canBeBuild = true;
            }
            else if (required == false)
            {
                return canBeBuild = true;
            }
            else
            {
                return canBeBuild = false;
            }
        }
        return canBeBuild = true;
    }

}
