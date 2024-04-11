using System.Data;
using System.Runtime.Versioning;
using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public Resources Data;



    public void ModifyResources(string resource, int amount)
    {
        switch (resource)
        {
            case "Wood":
                Data.Wood += amount;
                break;
            case "Iron":
                Data.Iron += amount;
                break;
            case "Minerals":
                Data.Minerals += amount;
                break;
            case "Stone":
                Data.Stone += amount;
                break;
            case "Sulfur":
                Data.Sulfur += amount;
                break;
            case "Gems":
                Data.Gems += amount;
                break;
            case "Gold":
                Data.Gold += amount;
                break;
            default:
                Debug.Log("Invalid resource type.");
                break;
        }
    }

}


