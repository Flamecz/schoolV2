using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetData : MonoBehaviour
{
    public SaveDataObject SDO;
    public Days days;
    
    // Start is called before the first frame update
    public void ResetDataTesting()
    {
        FindObjectOfType<Testing>().pathfinding.settedValue = 300;
        if(!SDO.CityBuldings[0].upgraded)
        {
            FindObjectOfType<ResourceManager>().ModifyResources("Gold", 1000);
        }
        else if(SDO.CityBuldings[0].upgraded)
        {
            FindObjectOfType<ResourceManager>().ModifyResources("Gold", 3000);
        }
        if(days.days == 7)
        {
            FindObjectOfType<AudioManager>().Stop("HeroesInWorld");
            FindObjectOfType<AudioManager>().Play("NewWeek");
            StartCoroutine(PlaySound());
            days.days = 1;
            days.weeks++;
        }
        days.days++;
        
    }
    IEnumerator PlaySound()
    {
        yield return new WaitForSeconds(4f);
        FindObjectOfType<AudioManager>().Play("HeroesInWorld");
    }
}
