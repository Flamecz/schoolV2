using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int Wood;
    public int Iron;
    public int Minerals;
    public int Stone;
    public int Sulfur;
    public int Gems;
    public int Gold;

    public static ResourceManager instance;

    private int dayCounter = 0,weekCounter = 0,monthCounter = 0;

    public void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        if (this.gameObject)
        {
            DontDestroyOnLoad(gameObject);
        }

        instance = this;
    }

    public void ModifyResources(string resource, int amount)
    {
        switch (resource)
        {
            case "Wood":
                Wood += amount;
                break;
            case "Iron":
                Iron += amount;
                break;
            case "Minerals":
                Minerals += amount;
                break;
            case "Stone":
                Stone += amount;
                break;
            case "Sulfur":
                Sulfur += amount;
                break;
            case "Gems":
                Gems += amount;
                break;
            case "Gold":
                Gold += amount;
                break;
            default:
                Debug.Log("Invalid resource type.");
                break;
        }
        SaveManager saveManager = new SaveManager();
        saveManager.Save(new ResourceData { Wood = Wood, Iron = Iron, Minerals = Minerals, Stone = Stone });
    }
    public void LoadResources()
    {
        // Load the resource data
        SaveManager saveManager = new SaveManager();
        var resourceData = saveManager.Load();

        // Apply the loaded resource data
        Wood = resourceData.Wood;
        Iron = resourceData.Iron;
        Minerals = resourceData.Minerals;
        Stone = resourceData.Stone;
    }
    public void IncrementDay()
    {
        dayCounter++;

        if (dayCounter % 7 == 0)
        {
            weekCounter++;
        }

        if (weekCounter % 4 == 0)
        {
            monthCounter++;
        }
    }
    public string DisplayTimePeriod()
    {
        return dayCounter + " days, " + weekCounter + " weeks, " + monthCounter + " months";
    }
}


