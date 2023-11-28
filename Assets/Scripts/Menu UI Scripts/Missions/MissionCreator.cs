using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionCreator : MonoBehaviour
{
    
    MissionData missionD = new MissionData();
    List<BonusThingsinMission> myObjects = new List<BonusThingsinMission>();
    // BonusThingsinMission BTIM = new BonusThingsinMission("More Ores" , )
    void Start()
    {
        myObjects.Add(new BonusThingsinMission("additional resources", Resources.Load<Sprite>("Sprites/resources"), "Gives you additional resources to create buildings"));
        myObjects.Add(new BonusThingsinMission("12 ", Resources.Load<Sprite>("Sprites/resources"), "Gives you additional resources to create buildings"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
