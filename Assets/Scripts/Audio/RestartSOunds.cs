using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartSOunds : MonoBehaviour
{
    public void seter()
    {
        PlayerPrefs.SetFloat("MasterValue", 1f);
        PlayerPrefs.SetFloat("SoundValue", 1f);
        PlayerPrefs.SetFloat("EffectValue", 1f);


        FindObjectOfType<JustWork>().sliderMasterVolumecall(PlayerPrefs.GetFloat("MasterValue"));
        FindObjectOfType<JustWork>().sliderEffectVolumeCall(PlayerPrefs.GetFloat("EffectValue"));
        FindObjectOfType<JustWork>().sliderMusicVolumeCall(PlayerPrefs.GetFloat("SoundValue"));
        FindObjectOfType<JustWork>().sliderMaster.value = 1f;
        FindObjectOfType<JustWork>().sliderEffect.value = 1f;
        FindObjectOfType<JustWork>().sliderMusic.value = 1f;
    }
}
