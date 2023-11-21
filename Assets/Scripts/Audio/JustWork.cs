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

    private float sound1;
    private float sound2;
    private float sound3;

    private void Start()
    {
        LoadData();

        sliderMaster.onValueChanged.AddListener(sliderMasterVolumecall);
        sliderMaster.value = sound1;
        sliderEffect.onValueChanged.AddListener(sliderMusicVolumeCall);
        sliderEffect.value = sound2;
        sliderMusic.onValueChanged.AddListener(sliderEffectVolumeCall);
        sliderMusic.value = sound3;
    }

    public void sliderMasterVolumecall(float value)
    {
        sliderValueMaster = value;
        FindObjectOfType<AudioManager>().MasterVolume(sliderValueMaster);
        FindObjectOfType<AudioManager>().EffectVolume(sliderValueEffect);
        FindObjectOfType<AudioManager>().MusicVolume(sliderValueMusic);
        SaveData();
    }
    public void sliderEffectVolumeCall(float volume)
    {
        sliderValueEffect = volume;
        FindObjectOfType<AudioManager>().EffectVolume(sliderValueEffect);
        SaveData();
    }
    public void sliderMusicVolumeCall(float volume)
    {
        sliderValueMusic = volume;
        FindObjectOfType<AudioManager>().MusicVolume(sliderValueMusic);
        SaveData();
    }
    public void SaveData()
    {

        Debug.Log("saving");
        PlayerPrefs.SetFloat("MasterValue", sliderMaster.value);
        PlayerPrefs.SetFloat("SoundValue", sliderMusic.value);
        PlayerPrefs.SetFloat("EffectValue", sliderEffect.value);

        PlayerPrefs.SetFloat("MasterVolume", sliderValueMaster);
        PlayerPrefs.SetFloat("EffectVolume", sliderValueEffect);
        PlayerPrefs.SetFloat("MusicVolume", sliderValueMusic);

        PlayerPrefs.Save();


    }
    public void LoadData()
    {
        Debug.Log("loading");
        sound1 = PlayerPrefs.GetFloat("MasterValue");
        sound2 = PlayerPrefs.GetFloat("EffectValue");
        sound3 = PlayerPrefs.GetFloat("SoundValue");
    }
}
