using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JustWork : MonoBehaviour
{
    public Slider sliderMaster;
    public Slider sliderEffect;
    public Slider sliderMusic;

    float sliderValueMaster;
    float sliderValueEffect;
    float sliderValueMusic;


    private void Start()
    {
        sliderMaster.onValueChanged.AddListener(sliderMasterVolumecall);
        sliderMaster.value = 1f;
        sliderEffect.onValueChanged.AddListener(sliderMusicVolumeCall);
        sliderEffect.value = 1f;
        sliderMusic.onValueChanged.AddListener(sliderEffectVolumeCall);
        sliderMusic.value = 1f;
    }

    public void sliderMasterVolumecall(float value)
    {
        sliderValueMaster = value;
        FindObjectOfType<AudioManager>().MasterVolume(sliderValueMaster);
    }
    public void sliderEffectVolumeCall(float volume)
    {
        sliderValueEffect = volume;
        FindObjectOfType<AudioManager>().EffectVolume(sliderValueEffect);
    }
    public void sliderMusicVolumeCall(float volume)
    {
        sliderValueMusic = volume;
        FindObjectOfType<AudioManager>().MusicVolume(sliderValueMusic);
    }
}
