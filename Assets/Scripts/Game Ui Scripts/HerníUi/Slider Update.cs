using UnityEngine;
using UnityEngine.UI;

public class SliderUpdate : MonoBehaviour
{
    public GameObject Empty;
    private Slider slider;
    private Button Left, Right;

    void Start()
    {
        slider = gameObject.transform.Find("Slider").GetComponent<Slider>();
        Left = gameObject.transform.Find("LeftButton").GetComponent<Button>();
        Right = gameObject.transform.Find("RightButton").GetComponent<Button>();


        Left.onClick.AddListener(delegate { slider.value -= 1; });
        Right.onClick.AddListener(delegate { slider.value += 1; });
    }
}

