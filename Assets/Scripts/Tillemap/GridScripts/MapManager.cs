using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    // Array to store map layouts
    public string[][] mapLayouts;

    // Singleton instance
    public static MapManager Instance { get; private set; }

    private void Awake()
    {
        // Ensure there is only one instance of MapManager
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogWarning("Another instance of MapManager already exists. Destroying this one.");
            Destroy(gameObject);
        }

        // Initialize map layouts
        InitializeMapLayouts();
    }

    // Method to initialize map layouts
    private void InitializeMapLayouts()
    {
        mapLayouts = new string[5][];

        //X - zeï
        //. - práznı prostor
        //H - hrad
        //R - rudy
        //B - Budovy
        //E - nepøítel
        mapLayouts[0] = new string[]
        {
            "...XXXXXBXXXXXXXXXXXX",
            "X..XXXXX.RXXXX..RXXXX",
            "X..XXXXX....X...XXXXX",
            "XR.XXXXX.......XXXXXX",
            "XX..XXX..XX...XXXXXXX",
            "XXX.XX...XXXX.E..XXXX",
            "XX..XX.BXXXXXXX..XXXX",
            "XXEXX...XXXXXXX..XXXX",
            "......XXXXXXXXXX...XX",
            ".X..RXXXXXXXXX......X",
            ".X...XXXXXXXXXB.XXX..",
            ".XX...XXXXXXXXXXXXX..",
            ".BXX..XXXXXXXXXXXXXEX",
            "XXXX...XXXXXXXXXXX...",
            "XXXXB.RXXXXXXXXXXR..H"
        };

        mapLayouts[1] = new string[]
        {
            "XXXXXXXXXXXXXXXXXXXXX",
            "XXXXR...XX....XXXX.BX",
            "XXXXX....E......X..XX",
            "XXXXXXXXXXXXX......XX",
            "XXXXXXXXXXXXXXXX...XX",
            "XXXXXXXXXHXXXXX..XXXX",
            "XXXXXXXX...BXX...BXXX",
            "XR...BXXX..XX...XXXXX",
            "XXX....X.......XXXXXX",
            "XXXXX......XXXXXXXXXX",
            "XRXXXEXXBX..XXXXXXXXX",
            "X..X..XXXX...XXXXX.RX",
            "X.....XXXXX...XXX...X",
            "XR...XXXXXXB...E...RX",
            "XXXXXXXXXXXXXXXXXXXXX"



        };
        mapLayouts[2] = new string[]
        {
            "XXXXR....BXXX..BXXXXX",
            "XXXXX......XX.....RXX",
            "XH.XXXRXX..........XX",
            "...XXXXXX....XXXX...B",
            "R..XXXXXX..XXXXXXXXXX",
            "X.XXXXXX....XXXXXXXXX",
            "X..XXXXXX..XXXXXXXXXX",
            "R...XXXB.....XXX.BXX.",
            "XXX...X.......X..XX..",
            "XXXX.....XXX.........",
            "XXXXXX..XXX.........X",
            "Xxx......XXBX.....BXX",
            "XX.......XXXX.....XXX",
            "XX...XX...XXX.XX....B",
            "E...XXXX...XXXXXXXXXX",
        };
        mapLayouts[3] = new string[]
        {
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
            "......................",
        };
    }
    public string[] GetMapLayout(int index)
    {
        if (index >= 0 && index < mapLayouts.Length)
        {
            return mapLayouts[index];
        }
        else
        {
            Debug.LogError("Invalid map index: " + index);
            return null;
        }
    }
}
