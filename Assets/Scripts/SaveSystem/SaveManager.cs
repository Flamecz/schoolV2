using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public void Save(ResourceData data)
    {
        // Serialize to json
        var jsonData = JsonUtility.ToJson(data);

        // Now save the json locally
        File.WriteAllText(Application.persistentDataPath + "/ResourceData.json", jsonData);
    }

    public ResourceData Load()
    {
        // Retrieve json data from storage of your choice
        var jsonData = File.ReadAllText(Application.persistentDataPath + "/ResourceData.json");

        // Then deserialize it back to an object
        var resourceData = JsonUtility.FromJson<ResourceData>(jsonData);

        return resourceData;
    }
}
