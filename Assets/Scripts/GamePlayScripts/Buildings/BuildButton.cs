using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class BuildButton : MonoBehaviour
{
    public BuildData buildData;
    public CityBuldings cityBuldings;

    [Header("Important Resources")]
    public ResourceManager resourceManager; // reference to the ResourceManager script
    public Canvas canvas;
    public string NameOfPosition;
    public string nameOfTheButtonBackground;


    public GameObject objectToBuild; // the building to build 
    private Text NameOfTheButton;//its the text in the button of the building button

    [HideInInspector]
    public Image colorImageOfButton;// just select the button which you want to collor
    public GameObject PopUpWindow;//its the 
    [Header("Settings")]
    private Image Image;

    public int woodCost;
    public int mineralsCost;
    public int stoneCost;
    public int ironCost;

    private bool Builded;
    private GameObject popUpWindow;
    private Transform Position;
    private Transform MainScreenParrent;
    private Transform PopUpParrent;
    private Button Checker;
    private void Start()
    {
        // Add a click listener to the button


        GetPosition(NameOfPosition);
        GetParents(nameOfTheButtonBackground);
        GetComponent<Button>().onClick.AddListener(CreatePopUp);
        Checker.onClick.AddListener(CheckStatus) ;

        NameOfTheButton.text = buildData.nazev;
        Image.sprite = buildData.Obrazek;
        resourceManager = FindObjectOfType<ResourceManager>();

        if (cityBuldings.builded)
        {
            BuildObjectFromData();
        }

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
    private void Update()
    {
        CheckStatus();
    }

    public void CreatePopUp()
    {
        if (!cityBuldings.builded)
        {
                if (resourceManager.Wood >= woodCost &&
                resourceManager.Iron >= ironCost &&
                resourceManager.Minerals >= mineralsCost &&
                resourceManager.Stone >= stoneCost)
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
                    Image Image = SpriteImageTransform.GetComponent<Image>();
                    Image.GetComponent<Image>().sprite = buildData.Obrazek;

                    //Adding cost of the building in resources;
                    Transform GetTextResources = popUpWindow.transform.Find("ResourseText");
                    Text ResourcesText = GetTextResources.GetComponent<Text>();
                    StringBuilder sb = new StringBuilder();
                    if (woodCost > 0)
                    {
                        sb.Append("Wood : " + woodCost + " ,");
                    }
                    if (stoneCost > 0)
                    {
                        sb.Append("Stone : " + stoneCost + " ,");
                    }
                    if (ironCost > 0)
                    {
                        sb.Append("Iron : " + ironCost + " ,");
                    }
                    if (mineralsCost > 0)
                    {
                        sb.Append("Mineral : " + mineralsCost + " ,");
                    }

                    ResourcesText.text = sb.ToString();
                }
                else
                {
                    CreateBuildedPopUp();
                }  
        }
        else if (cityBuldings.builded)
        {
            CreateInfoPopUp();
        }

    }
    public void CheckStatus()
    {
        if (!cityBuldings.builded)
        {

                if (resourceManager.Wood >= woodCost &&
                    resourceManager.Iron >= ironCost &&
                    resourceManager.Minerals >= mineralsCost &&
                    resourceManager.Stone >= stoneCost)
                {
                    if (cityBuldings.Done())
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

                    colorImageOfButton.color = new Color32(255, 0, 0, 255);
                }
         
         }
        else
        {

            colorImageOfButton.color = new Color32(70, 230, 70, 255);

            cityBuldings.builded = true;
        }
        
  
    }


    public void CostOfBuilding()
    {
        resourceManager.Wood -= woodCost;
        resourceManager.Iron -= ironCost;
        resourceManager.Minerals -= mineralsCost;
        resourceManager.Stone -= stoneCost; 
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
        cityBuldings.builded = true;
        SaveManager saveManager = new SaveManager();
        saveManager.Save(new ResourceData { Builded = Builded });
        FindObjectOfType<MainCanvasControler>().CloseBuildingUI();
        CostOfBuilding();
        DestroyPopUp();
    }
    public void BuildObjectFromData()
    {
        Instantiate(objectToBuild, new Vector3(Position.position.x, Position.position.y, Position.position.z), Quaternion.identity, MainScreenParrent.transform);
        cityBuldings.builded = true;
        SaveManager saveManager = new SaveManager();
        saveManager.Save(new ResourceData { Builded = Builded });
    }

    public void DestroyPopUp()
    {
        Destroy(popUpWindow);
    }

    public void GetPosition(string PositionName)
    {
        Transform EveryPosition = canvas.transform.Find("Citypositions");
        Position = EveryPosition.transform.Find(PositionName);
    }
    public void GetParents(string nameOfTheButtonBackground)
    {
            MainScreenParrent = canvas.transform.Find("mainScreen");
            PopUpParrent = canvas.transform.Find("BuildUI");
            Transform BuldingBackground = PopUpParrent.transform.Find(nameOfTheButtonBackground);
            Transform spriteTransform = BuldingBackground.transform.Find("sprite"); 
            Transform ButtonOfThis = BuldingBackground.transform.Find("BuildingButton");
            Transform NameOfTheButtonTranform = ButtonOfThis.transform.Find("NameOfButton");
            Transform OpenBuildButtonTransform = canvas.transform.Find("OpenBuildBuildingsButton");
            NameOfTheButton = NameOfTheButtonTranform.GetComponent<Text>();
            colorImageOfButton = ButtonOfThis.GetComponent<Image>();
            Image = spriteTransform.GetComponent<Image>();
            Checker = OpenBuildButtonTransform.GetComponent<Button>();
    }

    private void CreateBuildedPopUp()
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

        //Adding Sprite to the object
        Transform SpriteImageTransform = popUpWindow.transform.Find("SpriteOfTheBuildingInPopUp");
        Image Image = SpriteImageTransform.GetComponent<Image>();
        Image.GetComponent<Image>().sprite = buildData.Obrazek;

        //Adding cost of the building in resources;
        Transform GetTextResources = popUpWindow.transform.Find("ResourseText");
        Text ResourcesText = GetTextResources.GetComponent<Text>();
        StringBuilder sb = new StringBuilder();
        if (woodCost > 0)
        {
            sb.Append("Wood : " + woodCost + " ,");
        }
        if (stoneCost > 0)
        {
            sb.Append("Stone : " + stoneCost + " ,");
        }
        if (ironCost > 0)
        {
            sb.Append("Iron : " + ironCost + " ,");
        }
        if (mineralsCost > 0)
        {
            sb.Append("Mineral : " + mineralsCost + " ,");
        }

        ResourcesText.text = sb.ToString();

        //Adding Required Buildings
        Transform GetTextBuildings = popUpWindow.transform.Find("BuildingsRequared");
        Text BuildingText = GetTextBuildings.GetComponent<Text>();
        if(cityBuldings.required != null)
        {

        }
    }
    private void CreateInfoPopUp()
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

        //Adding Sprite to the object
        Transform SpriteImageTransform = popUpWindow.transform.Find("SpriteOfTheBuildingInPopUp");
        Image Image = SpriteImageTransform.GetComponent<Image>();
        Image.GetComponent<Image>().sprite = buildData.Obrazek;

        Transform GetTextResources = popUpWindow.transform.Find("ResourseText");
        Text ResourcesText = GetTextResources.GetComponent<Text>();
        ResourcesText.text = "";
    }
}
