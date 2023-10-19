using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    public BuildData buildData;
    
    [Header("Important Resources")]
    public ResourceManager resourceManager; // reference to the ResourceManager script
    public GameObject MainScreenParrent;
    public GameObject PopUpParrent;
    public Transform Position;
    public GameObject objectToBuild; // the object to build
    public Text NameOfTheButton;
    public Image colorImageOfButton;
    public GameObject PopUpWindow;
    [Header("Settings")]
    public string BuildingName;
    public int woodCost;
    public int mineralsCost;
    public int stoneCost;
    public int ironCost;

    private bool Builded;
    private GameObject popUpWindow;
    private void Start()
    {
        // Add a click listener to the button
        GetComponent<Button>().onClick.AddListener(CreatePopUp);
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
        }
    }
    public void CreatePopUp()
    {
        if(!Builded)
        {
            //centring object in middle and creating popUp

            popUpWindow = Instantiate(PopUpWindow, PopUpParrent.transform);
            RectTransform rectTransform = popUpWindow.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;

            //Working with children of the object and adding listeners

            Transform acceptButtonTransform = popUpWindow.transform.Find("BuyButton");
            Button acceptButton = acceptButtonTransform.GetComponent<Button>();
            acceptButton.onClick.AddListener(BuildObject);
            Transform CancelButtonTransform = popUpWindow.transform.Find("CanceledButton");
            Button CancelButton = CancelButtonTransform.GetComponent<Button>();
            CancelButton.onClick.AddListener(DestroyPopUp);

            //Adding text in Popup;

            Transform NameObjectTransform = popUpWindow.transform.Find("NameOfBuildingInPopUp");
            Text TextNameOfOBject = NameObjectTransform.GetComponent<Text>();
            TextNameOfOBject.text = buildData.nazev;

            Transform DescriptionObjectTransform = popUpWindow.transform.Find("DescriptionOfBuildingInPopUp");
            Text TextDescriptionOfOBject = DescriptionObjectTransform.GetComponent<Text>();
            TextDescriptionOfOBject.text = buildData.popis;

            //Adding Sprite to the object
            Transform SpriteImageTransform = popUpWindow.transform.Find("SpriteOfTheBuildingInPopUp");
            Renderer renderer = SpriteImageTransform.GetComponent<Renderer>();
            /*
            Transform SpriteImageTransform = popUpWindow.transform.Find("SpriteOfTheBuildingInPopUp");
            Image PopUpSprite = SpriteImageTransform.GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Sprites/Holder");
            PopUpSprite.sprite = sprite;*/
        }
        else if(Builded)
        {
            popUpWindow = Instantiate(PopUpWindow, PopUpParrent.transform);
            RectTransform rectTransform = popUpWindow.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = Vector2.zero;

            //Working with children of the object and adding listeners

            Transform acceptButtonTransform = popUpWindow.transform.Find("BuyButton");
            Button acceptButton = acceptButtonTransform.GetComponent<Button>();
            acceptButton.gameObject.SetActive(false);
            Transform CancelButtonTransform = popUpWindow.transform.Find("CanceledButton");
            Button CancelButton = CancelButtonTransform.GetComponent<Button>();
            CancelButton.onClick.AddListener(DestroyPopUp);

            //Adding text in Popup;

            Transform NameObjectTransform = popUpWindow.transform.Find("NameOfBuildingInPopUp");
            Text TextNameOfOBject = NameObjectTransform.GetComponent<Text>();
            TextNameOfOBject.text = buildData.nazev;

            Transform DescriptionObjectTransform = popUpWindow.transform.Find("DescriptionOfBuildingInPopUp");
            Text TextDescriptionOfOBject = DescriptionObjectTransform.GetComponent<Text>();
            TextDescriptionOfOBject.text = buildData.popis;
        }

        }
        public void CheckStatus()
    {
        if(!Builded)
        {
           if (resourceManager.Wood >= woodCost &&
           resourceManager.Iron >= ironCost &&
           resourceManager.Minerals >= mineralsCost &&
           resourceManager.Stone >= stoneCost)
           {
                colorImageOfButton.color = new Color32(255, 205, 114, 255);
                
            }
           else
           {
                colorImageOfButton.color = new Color32(255, 0, 0, 255);
                
           }
        }
        else
        {
            colorImageOfButton.color = new Color32(70, 230, 70, 255);
           
        }
        
    }
    public void OnLoadUpdate()
    {
        SaveManager saveManager = new SaveManager();
        var resourceData = saveManager.Load();

        Builded = resourceData.Builded;
    }
    public void BuildObject()
    {
        Instantiate(objectToBuild, new Vector3(Position.position.x, Position.position.y, Position.position.z), Quaternion.identity, MainScreenParrent.transform);
        Builded = true;
        SaveManager saveManager = new SaveManager();
        saveManager.Save(new ResourceData { Builded = Builded });
        FindObjectOfType<MainCanvasControler>().CloseBuildingUI();
        DestroyPopUp();
    }
    public void DestroyPopUp()
    {
        Destroy(popUpWindow);
    }

}
