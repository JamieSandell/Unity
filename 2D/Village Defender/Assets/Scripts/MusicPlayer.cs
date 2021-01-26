using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    private static bool shuttingDown = false;

    private static MusicPlayer instance = null;
    public static MusicPlayer Instance
    {
        get
        {
            if (shuttingDown)
            {
                Debug.LogWarning("Shutting down, MusicPlayer Singleton already destroyed, returning null");
                return null;
            }
            return instance;
        }
    }

    private AudioSource audioSource = null;

    private void Awake()
    {
        if ((instance != null) && (instance != this))
        {
            //We exist but instance equals another instance of this class so destroy it (singleton method)
            Destroy(this.gameObject);
        }
        else //otherwise instance is set to this particular (one and only) instance
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = PlayerPrefsController.GetMusicVolume();
        audioSource.ignoreListenerVolume = true; // This way can control SFX using global values, and it will be seperate from the background music
                                                 //https://answers.unity.com/questions/306684/how-to-change-volume-on-many-audio-objects-with-sp.html

        AudioListener.volume = PlayerPrefsController.GetSFXVolume();
    }

    private void OnApplicationQuit()
    {
        shuttingDown = true;
    }

    private void OnDestroy()
    {
        shuttingDown = true;
    }

    public void SetMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }

    public void SetSFXVolume(float volume)
    {
        AudioListener.volume = volume;
    }
}