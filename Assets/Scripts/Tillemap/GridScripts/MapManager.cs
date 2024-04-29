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

        // Example map layouts
        mapLayouts[0] = new string[]
        {
            "XXXX.................",
            "XXXXX................",
            "XH.XXXXXX............",
            "...XX..XX............",
            "...XXXXXXXXXXXXXXXXXX",
            "X.XXXXXXXXXXXXXXXXXXX",
            "X..XXXXXXXXXXXXXXXXXX",
            "....XXX......XXX..XX.",
            "XXX...X.......X..XX..",
            "XXXX.....XXX.........",
            "XXXXXX..XXX.........X",
            "XXX......XX.X......XX",
            "XX.......XXXX.....XXX",
            "XX...XX...XXX.XXXXXXX",
            "....XXXX...XXXXXXXXXX"
        };

        mapLayouts[1] = new string[]
        {
            "XXXX.................",
            "XXXXX................",
            "XX.XXXXXX............",
            "...XX..XX............",
            "...XXXXXXXXXXXXXXXXXX",
            "X.XXXXXX....XXXXXXXXX",
            "X..XXXXXX..XXXXXXXXXX",
            "....XXX......XXX..XX.",
            "XXX...X.......X..XX..",
            "XXXX.....XXX.........",
            "XXXXXX..XXX.........X",
            "Xxx......XX.X......XX",
            "XX.......XXXX.....XXX",
            "XX...XX...XXX.XXXXXXX",
            "....XXXX...XXXXXXXXXX"



        };
        mapLayouts[2] = new string[]
        {
            "XXXX.................",
            "XXXXX................",
            "XX.XXXXXX............",
            "...XX..XX............",
            "...XXXXXXXXXXXXXXXXXX",
            "X.XXXXXX....XXXXXXXXX",
            "X..XXXXXX..XXXXXXXXXX",
            "....XXX......XXX..XX.",
            "XXX...X.......X..XX..",
            "XXXX.....XXX.........",
            "XXXXXX..XXX.........X",
            "Xxx......XX.X......XX",
            "XX.......XXXX.....XXX",
            "XX...XX...XXX.XX.....",
            "....XXXX...XXXXXXXXXX",
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
