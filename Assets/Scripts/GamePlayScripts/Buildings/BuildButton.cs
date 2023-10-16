using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    [Header("Important Resources")]
    public ResourceManager resourceManager; // reference to the ResourceManager script
    public Canvas canvas;
    public Transform Position;
    public GameObject objectToBuild; // the object to build
    public Text NameOfTheButton;
    [Header("Settings")]
    public string BuildingName;
    public int woodCost;
    public int mineralsCost;
    public int stoneCost;
    public int ironCost;

    private void Start()
    {
        // Add a click listener to the button
        GetComponent<Button>().onClick.AddListener(HandleClick);
        NameOfTheButton.text = BuildingName;
    }

    private void HandleClick()
    {
        if (resourceManager.Wood >= woodCost &&
            resourceManager.Iron >= ironCost &&
            resourceManager.Minerals >= mineralsCost &&
            resourceManager.Stone >= stoneCost)
        {
            // Subtract the costs from the resources
            resourceManager.ModifyResources("Wood", -woodCost);
            resourceManager.ModifyResources("Iron", -ironCost);
            resourceManager.ModifyResources("Minerals", -mineralsCost);
            resourceManager.ModifyResources("Stone", -stoneCost);

            // Instantiate the object to build
            Instantiate(objectToBuild, new Vector3(Position.position.x, Position.position.y, Position.position.z), Quaternion.identity,canvas.transform);
        }
        else
        {
            Debug.Log("Not enough resources to build this object.");
        }
    }
}
