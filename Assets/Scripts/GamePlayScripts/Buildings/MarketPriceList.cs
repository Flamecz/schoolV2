using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MarketPriceList : MonoBehaviour, IPointerClickHandler
{
    public ResourceManager RM;
    [HideInInspector]
    public int WoodCost;
    [HideInInspector]
    public int StoneCost;
    [HideInInspector]
    public int IronCost;
    [HideInInspector]
    public int MineralsCost;
    [HideInInspector]
    public int SulfurCost;
    [HideInInspector]
    public int GemsCost;
    [HideInInspector]
    public int GoldCost;

    public int index;
    public GameObject[] Obrazky;
    public Button[] DisableImage;
    public Sprite[] sprites;
    public Image RightSelected, LeftSelected;

    private static bool Selected;
    private static bool Selected2;
    public bool Rightside= false;
    public bool ShowCase = false;

    private int lastResourceCount;

    public int resource;
    public int count;
    private void Awake()
    {
        if(!ShowCase)
        {
            Image sprite = this.gameObject.transform.GetComponent<Image>();
            sprite.sprite = sprites[index];
            
        }
    }
    private void Update()
    {
            LeftSelected.transform.Find("Amount").GetComponent<Text>().text = ReturnCount().ToString();
            lastResourceCount = ReturnCount();
        Debug.Log(lastResourceCount);
            RightSelected.transform.Find("Amount").GetComponent<Text>().text = count.ToString();
    }
    public void GetProperty()
    {
        switch (index)
        {
            //Wood Selected
            case 0:
                WoodCost = 0;
                StoneCost = 10;
                IronCost = 20;
                MineralsCost = 20;
                SulfurCost = 20;
                GemsCost = 20;
                GoldCost = 25;
                break;
            //Iron Selected
            case 1:
                WoodCost = 5;
                StoneCost = 5;
                IronCost = 0;
                MineralsCost = 10;
                SulfurCost = 10;
                GemsCost = 10;
                GoldCost = 50;
                break;
            //Stone Selected
            case 2:
                WoodCost = 10;
                StoneCost = 0;
                IronCost = 20;
                MineralsCost = 20;
                SulfurCost = 20;
                GemsCost = 20;
                GoldCost = 25;
                break;
            //Sulfur Selected
            case 3:
                WoodCost = 5;
                StoneCost = 5;
                IronCost = 10;
                MineralsCost = 10;
                SulfurCost = 0;
                GemsCost = 10;
                GoldCost = 50;
                break;
            //Minerals Selected
            case 4:
                WoodCost = 5;
                StoneCost = 5;
                IronCost = 10;
                MineralsCost = 0;
                SulfurCost = 10;
                GemsCost = 10;
                GoldCost = 50;
                break;
            //Gems Selected
            case 5:
                WoodCost = 5;
                StoneCost = 5;
                IronCost = 10;
                MineralsCost = 10;
                SulfurCost = 10;
                GemsCost = 0;
                GoldCost = 50;
                break;
            //Gold Selected
            case 6:
                WoodCost = 2500;
                StoneCost = 2500;
                IronCost = 5000;
                MineralsCost = 5000;
                SulfurCost = 5000;
                GemsCost = 5000;
                GoldCost = 0;
                break;
            default:
                WoodCost = 0;
                StoneCost = 0;
                IronCost = 0;
                MineralsCost = 0;
                SulfurCost = 0;
                GemsCost = 0;
                GoldCost = 0;
                break;
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(Rightside)
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                imageBack();
                if (!Selected2)
                {
                    Obrazky[index].SetActive(true);
                    LeftSelected.sprite = sprites[index];
                    Selected2 = true;
                    FindObjectOfType<MarketControler>().GetIndex2(index);
                    FindObjectOfType<SliderUpdate>().SetIndex2(index);
                }
                else if (Selected2)
                {
                    Obrazky[index].SetActive(false);
                    Selected2 = false;
                }
            }
        }
        else
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {

                imageBack();
                if (!Selected)
                {
                    Obrazky[index].SetActive(true);
                    RightSelected.sprite = sprites[index];
                    GetProperty();
                    Debuger();
                    FindObjectOfType<MarketControler>().GetIndex(index);
                    Selected = true;
                    DisableImage[index].interactable = false;
                    FindObjectOfType<SliderUpdate>().SetIndex1(index);
                }
                else if (Selected)
                {
                    Obrazky[index].SetActive(false);
                    GetProperty();
                    Selected = false;
                }
            }
        }
    }
    public void imageBack()
    {
        if (!Rightside)
        {
            for (int i = 0; i < Obrazky.Length; i++)
            {
                Obrazky[i].SetActive(false);
                RightSelected.sprite = null;
                DisableImage[i].interactable = true;
            }
            Selected = false;
        }
        else if(Rightside)
        {
            for (int i = 0; i < Obrazky.Length; i++)
            {
                LeftSelected.sprite = null;
                Obrazky[i].SetActive(false);
            }
            Selected2 = false;
        }
    }


    public void Debuger()
    {
        FindObjectOfType<UpdateTexts>().Debugger(WoodCost,StoneCost,IronCost,MineralsCost,SulfurCost,GemsCost,(int)GoldCost);
        FindObjectOfType<SliderUpdate>().Importer(WoodCost, StoneCost, IronCost, MineralsCost, SulfurCost, GemsCost, (int)GoldCost);
    }

    public void GetAmount(int count)
    {
        this.count = count;
        FindObjectOfType<MarketControler>().GetCount(count);
    }
    public void ReturnResource(int Resource)
    {
        resource = Resource;
        FindObjectOfType<MarketControler>().GetResource(Resource);
    }
    public int ReturnCount()
    {
        return count * resource;
    }
}
