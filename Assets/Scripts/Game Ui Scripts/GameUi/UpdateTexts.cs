using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateTexts : MonoBehaviour
{
    public ResourceManager RM;
    public MainCanvasControler MCC;
    public GameObject Object;
    public bool isRight = false;

    private Image ResourceImage;
    private Text ResourceText;

    private Image ResourceImage1;
    private Text ResourceText1;

    private Image ResourceImage2;
    private Text ResourceText2;

    private Image ResourceImage3;
    private Text ResourceText3;

    private Image ResourceImage4;
    private Text ResourceText4;

    private Image ResourceImage5;
    private Text ResourceText5;

    private Image ResourceImage6;
    private Text ResourceText6;
    public Button utilityButton;

    [HideInInspector]
    public int WoodCost, StoneCost, IronCost, SulfurCost, MineralsCost, GemsCost, GoldCost;
    private void awake()
    {
        utilityButton.onClick.AddListener(MCC.CloseAllScreens);
    }
    void Update()
    {
        GetData();
        SetData();
        if (isRight)
        {
            SetRightSide();
        }
    }
    public void GetData()
    {
        ResourceImage = Object.transform.Find("Resource").GetComponent<Image>();
        ResourceText = Object.transform.Find("Resource/Amount").GetComponent<Text>();

        ResourceImage1 = Object.transform.Find("Resource1").GetComponent<Image>();
        ResourceText1 = Object.transform.Find("Resource1/Amount").GetComponent<Text>();

        ResourceImage2 = Object.transform.Find("Resource2").GetComponent<Image>();
        ResourceText2 = Object.transform.Find("Resource2/Amount").GetComponent<Text>();

        ResourceImage3 = Object.transform.Find("Resource3").GetComponent<Image>();
        ResourceText3 = Object.transform.Find("Resource3/Amount").GetComponent<Text>();

        ResourceImage4 = Object.transform.Find("Resource4").GetComponent<Image>();
        ResourceText4 = Object.transform.Find("Resource4/Amount").GetComponent<Text>();

        ResourceImage5 = Object.transform.Find("Resource5").GetComponent<Image>();
        ResourceText5 = Object.transform.Find("Resource5/Amount").GetComponent<Text>();

        ResourceImage6 = Object.transform.Find("Resource6").GetComponent<Image>();
        ResourceText6 = Object.transform.Find("Resource6/Amount").GetComponent<Text>();
    }

    public void SetData()
    {
        ResourceText.text = RM.Data.Wood.ToString();
        ResourceText1.text = RM.Data.Iron.ToString();
        ResourceText2.text = RM.Data.Stone.ToString();
        ResourceText3.text = RM.Data.Sulfur.ToString();
        ResourceText4.text = RM.Data.Minerals.ToString();
        ResourceText5.text = RM.Data.Gems.ToString();
        ResourceText6.text = RM.Data.Gold.ToString();
    }
    public void SetRightSide()
    {
        if (WoodCost != 0)
        {
            ResourceText.text = WoodCost.ToString() + "/1";
        }
        else { ResourceText.text = "-"; }
        if (IronCost != 0)
        {
            ResourceText1.text = IronCost.ToString() + "/1";
        }
        else { ResourceText1.text = "-"; }
        if (StoneCost != 0)
        {
            ResourceText2.text = StoneCost.ToString() + "/1";
        }
        else { ResourceText2.text = "-"; }
        if (MineralsCost != 0)
        {
            ResourceText3.text = MineralsCost.ToString() + "/1";
        }
        else { ResourceText3.text = "-"; }
        if (SulfurCost != 0)
        {
            ResourceText4.text = SulfurCost.ToString() + "/1";
        }
        else { ResourceText4.text = "-"; }
        if (GemsCost != 0)
        {
            ResourceText5.text = GemsCost.ToString() + "/1";
        }
        else { ResourceText5.text = "-"; }
        if (GoldCost != 0)
        {
            ResourceText6.text = "1/" + GoldCost.ToString();
        }
        else { ResourceText6.text = "-"; }
    }
    public void Debugger(int Wood, int Stone, int Iron, int Sulfur, int Minerals, int Gems, int Gold)
    {
        WoodCost = Wood;
        StoneCost = Stone;
        IronCost = Iron;
        SulfurCost = Sulfur;
        MineralsCost = Minerals;
        GemsCost = Gems;
        GoldCost = Gold;
    }
}
