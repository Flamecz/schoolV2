using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public int Wood;
    public int Iron;
    public int Minerals;
    public int Stone;

    public void Awake()
    {
        if(this.gameObject)
        {
            DontDestroyOnLoad(gameObject);
        }
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
}


