using System.Collections;
using UnityEngine.Audio;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    private float maxvolume;
    private float savedVolume;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
    private void Start()
    {
        MasterVolume(PlayerPrefs.GetFloat("MasterVolume"));
        EffectVolume(PlayerPrefs.GetFloat("EffectVolume"));
        MusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
        Play("mainTheme");
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Play("clickSound");
        }
        if(Input.GetButtonDown("Fire2"))
        {
            SceneManager.LoadScene(3);
            Stop("mainTheme");
        }
    }
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found on object " + gameObject);
            return;
        }
        else
        {
            s.source.Play();
        }
    }
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }
    public void ChangeVolume(string name,float volume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = volume;
        savedVolume = volume;
    }
    public void MasterVolume(float volume)
    {
        foreach(Sound s in sounds)
        {
            maxvolume = volume;
        }

    }
    public void EffectVolume(float volume)
    {
        foreach(Sound s in sounds)
        {
            if(s.Effect == true)
            {
                s.source.volume = volume * maxvolume;
            }
        }

    }
    public void MusicVolume(float volume)
    {
        foreach(Sound s in sounds)
        {
            if(s.Music == true)
            {
                s.source.volume = volume * maxvolume;
            }
        }

    }
}
