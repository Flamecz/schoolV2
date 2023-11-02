using System.Collections;
using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

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
        Play("mainTheme");
    }
    private void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Play("clickSound");
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
    }
    public void MasterVolume(float volume)
    {
        foreach(Sound s in sounds)
        {
            s.source.volume = volume;
        }
    }
    public void EffectVolume(float volume)
    {
        foreach(Sound s in sounds)
        {
            if(s.Effect == true)
            {
                s.source.volume = volume;
            }
        }
    }
    public void MusicVolume(float volume)
    {
        foreach(Sound s in sounds)
        {
            if(s.Music == true)
            {
                s.source.volume = volume;
            }
        }
    }
}
