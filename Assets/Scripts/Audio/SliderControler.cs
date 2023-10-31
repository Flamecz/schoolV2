using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderControler : MonoBehaviour
{

    public Slider slider;
    float sliderValue;


    private void slidercall(float value)
    {
        sliderValue = value;
        FindObjectOfType<AudioManager>().MasterVolume(sliderValue);
    }
}
