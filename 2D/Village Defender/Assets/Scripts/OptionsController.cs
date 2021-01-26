using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [SerializeField]
    Slider musicSlider = null;
    [SerializeField]
    [Range(PlayerPrefsController.MIN_MUSIC_VOLUME, PlayerPrefsController.MAX_MUSIC_VOLUME)]
    float defaultVolume = 1.0f;

    [SerializeField]
    Slider sfxSlider = null;
    [SerializeField]
    [Range(PlayerPrefsController.MIN_SFX_VOLUME, PlayerPrefsController.MAX_SFX_VOLUME)]
    float defaultSFXVolume = 1.0f;

    [SerializeField]
    Slider difficultySlider = null;
    [SerializeField]
    [Range(PlayerPrefsController.MIN_DIFFICULTY, PlayerPrefsController.MAX_DIFFICULTY)]
    float defaultDifficulty = 0.0f;

    void Start()
    {
        musicSlider.value = PlayerPrefsController.GetMusicVolume();
        sfxSlider.value = PlayerPrefsController.GetSFXVolume();
        difficultySlider.value = PlayerPrefsController.GetDifficulty();
    }

    void Update()
    {
        if (MusicPlayer.Instance)
        {
            MusicPlayer.Instance.SetMusicVolume(musicSlider.value);
            MusicPlayer.Instance.SetSFXVolume(sfxSlider.value);
        }
        else
        {
            Debug.LogWarning("MusicPlayer Instance is null");
        }
        
    }

    public void DefaultSettings()
    {
        difficultySlider.value = defaultDifficulty;
        musicSlider.value = defaultVolume;
    }

    public void SaveSettings()
    {
        PlayerPrefsController.SetDifficulty((int)difficultySlider.value);
        PlayerPrefsController.SetMusicVolume(musicSlider.value);
        PlayerPrefsController.SetSFXVolume(sfxSlider.value);
    }
}
