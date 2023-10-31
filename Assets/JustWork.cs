using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JustWork : MonoBehaviour
{
    public Slider slider;
    float sliderValue;

    private void Start()
    {
        slider.onValueChanged.AddListener(slidercall);
        slider.value = 1f;
    }

    public void slidercall(float value)
    {
        sliderValue = value;
        FindObjectOfType<AudioManager>().MasterVolume(sliderValue);
    }
}
