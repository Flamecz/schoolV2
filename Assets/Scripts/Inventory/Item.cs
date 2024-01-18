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


    /*
    public ItemData itemData;
    public GameObject holdingObjectPosition;
    private bool holding;
    private GameObject holdedItem;
    void Start()
    {
       
    }
    private void Update()
    {
        InventoryManagment();
    }
    private void InventoryManagment()
    {
     if(!holding)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                holdedItem = Instantiate(itemData.instance, holdingObjectPosition.transform);
                FindObjectOfType<PickUpScript>().PickUpObject(holdedItem);
                holding = true;
            }
        }
        else if(holding)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Escape))
            {
                Destroy(holdedItem);
                holding = false;
            }
        }
    */
}
