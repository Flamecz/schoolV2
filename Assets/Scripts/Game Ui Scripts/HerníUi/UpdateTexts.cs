using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UpdateTexts : MonoBehaviour
{
    public ResourceManager RM;
    public GameObject Object;

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
    void Start()
    {
        GetData();
        SetData();
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
        ResourceText.text  = RM.Wood.ToString();
        ResourceText1.text = RM.Iron.ToString();
        ResourceText2.text = RM.Stone.ToString();
        ResourceText3.text = RM.Sulfur.ToString();
        ResourceText4.text = RM.Minerals.ToString();
        ResourceText5.text = RM.Gems.ToString();
        ResourceText6.text = RM.Gold.ToString();
    }
}
