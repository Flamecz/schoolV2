using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "ItemDataScript")]
public class Item : ScriptableObject
{
    public Sprite itemSprite;
    public GameObject instance;
    public int id;
    public int price;
    public bool tool;
    [HideInInspector]
    public bool inMarketZone;
}
