using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LibraryOfBuildings : MonoBehaviour
{
    List<MyObjectBuilding> myObjects = new List<MyObjectBuilding>();

    void Start()
    {
        myObjects.Add(new MyObjectBuilding("TownHall", false));
        myObjects.Add(new MyObjectBuilding("Citadel", false));
        myObjects.Add(new MyObjectBuilding("BrotherhoodoftheSword", false));
        myObjects.Add(new MyObjectBuilding("BlackSmith", false));
        myObjects.Add(new MyObjectBuilding("Market", false));
        myObjects.Add(new MyObjectBuilding("MageGuild", false));
        myObjects.Add(new MyObjectBuilding("Shipyard", false));
        myObjects.Add(new MyObjectBuilding("Stables", false));
        myObjects.Add(new MyObjectBuilding("GriffinBastion", false));
        myObjects.Add(new MyObjectBuilding("GuardHouse", false));
        myObjects.Add(new MyObjectBuilding("ArcherTower", false));
        myObjects.Add(new MyObjectBuilding("GriffinTower", false));
        myObjects.Add(new MyObjectBuilding("Barracks", false));
        myObjects.Add(new MyObjectBuilding("Monastry", false));
        myObjects.Add(new MyObjectBuilding("TrainingGrounds", false));
        myObjects.Add(new MyObjectBuilding("PortalOfGlory", false));
    }

    public void PrintList()
    {
        foreach (MyObjectBuilding obj in myObjects)
        {
            Debug.Log("Name: " + obj.name + " Is Bool: " + obj.isBool );
        }
    }
    public int GetIndex(string name)
    {
        return myObjects.FindIndex(obj => obj.name == name);
    }
    public void UpdateObject(int index, string newName, bool newBool)
    {
        if (index < 0 || index >= myObjects.Count)
        {
            Debug.Log("Index out of range");
            return;
        }

        MyObjectBuilding obj = myObjects[index];
        obj.name = newName;
        obj.isBool = newBool;
    }
}   
