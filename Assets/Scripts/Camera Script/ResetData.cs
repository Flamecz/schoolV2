using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    public SaveDataObject SDO;
    public Days days;
    public StoredData StoredData;
    public StoreStamina set;
    public IsSomethingBuild isSomethingBuild;

    // Start is called before the first frame update
    public void ResetDataTesting()
    {
        FindObjectOfType<Testing>().pathfinding.settedValue = 200;
        set.stamina = 200;
        isSomethingBuild.isBuilded = false;
        CheckForResourceUpdate();
        if (!SDO.CityBuldings[0].upgraded)
        {
            FindObjectOfType<ResourceManager>().ModifyResources("Gold", 1000);
        }
        else if (SDO.CityBuldings[0].upgraded)
        {
            FindObjectOfType<ResourceManager>().ModifyResources("Gold", 3000);
        }
        if (days.days == 7)
        {
            FindObjectOfType<AudioManager>().Stop("HeroesInWorld");
            FindObjectOfType<AudioManager>().Play("NewWeek");
            StartCoroutine(PlaySound());
            days.days = 1;
            days.weeks++;
        }
        else
        {
            FindObjectOfType<AudioManager>().Stop("HeroesInWorld");
            FindObjectOfType<AudioManager>().Play("NewDay");
            StartCoroutine(PlaySound());
        }
        days.days++;
    }
    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(4f);
        FindObjectOfType<AudioManager>().Play("HeroesInWorld");
    }
    public void CheckForResourceUpdate()
    {
        for (int i = 0; i < StoredData.storeTag.Length; i++)
        {
            if(StoredData.storeTag != null)
            {
                if(StoredData.storeTag[i] == "BuildingG")
                {
                    FindObjectOfType<ResourceManager>().ModifyResources("Gold", 1000);
                }
                else if(StoredData.storeTag[i] == "BuildingGe")
                {
                    FindObjectOfType<ResourceManager>().ModifyResources("Gems", 1);
                }
                else if (StoredData.storeTag[i] == "BuildingM")
                {
                    FindObjectOfType<ResourceManager>().ModifyResources("Minerals", 1);
                }
                else if (StoredData.storeTag[i] == "BuildingS")
                {
                    FindObjectOfType<ResourceManager>().ModifyResources("Sulfur", 1);
                }
                else if (StoredData.storeTag[i] == "BuildingI")
                {
                    FindObjectOfType<ResourceManager>().ModifyResources("Iron", 1);
                }
                else if (StoredData.storeTag[i] == "BuildingSt")
                {
                    FindObjectOfType<ResourceManager>().ModifyResources("Stone", 1);
                }
                else if (StoredData.storeTag[i] == "BuildingW")
                {
                    FindObjectOfType<ResourceManager>().ModifyResources("Wood", 1);
                }
            }
        }
    }
}
