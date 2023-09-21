using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildBuildings : MonoBehaviour
{
    public GameObject Blueprint;

    public void spawn_barracks_blueprint()
    {
        Instantiate(Blueprint);
    }
}
