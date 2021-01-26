using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    private const string MUSIC_VOLUME_KEY = "music volume";
    private const string SFX_VOLUME_KEY = "sfx volume";
    private const string DIFFICULTY_KEY = "difficulty";

    public const float DEFAULT_MUSIC_VOLUME = 1f;
    public const float MIN_MUSIC_VOLUME = 0f;
    public const float MAX_MUSIC_VOLUME = 1f;

    public const float DEFAULT_SFX_VOLUME = 1f;
    public const float MIN_SFX_VOLUME = 0f;
    public const float MAX_SFX_VOLUME = 1f;

    public const int DEFAULT_DIFFICULTY = 0;
    public const int MIN_DIFFICULTY = 0;
    public const int MAX_DIFFICULTY = 1;

    public static void SetDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt(DIFFICULTY_KEY, difficulty);
    }

    public static int GetDifficulty()
    {
        return PlayerPrefs.GetInt(DIFFICULTY_KEY, DEFAULT_DIFFICULTY);
    }

    public static float GetSFXVolume()
    {
        return PlayerPrefs.GetFloat(SFX_VOLUME_KEY, DEFAULT_SFX_VOLUME);
    }

    public static void SetSFXVolume(float volume)
    {
        if ((volume >= MIN_SFX_VOLUME) && (volume <= MAX_SFX_VOLUME))
        {
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, volume);
            Debug.Log(nameof(SFX_VOLUME_KEY) + " set to " + volume.ToString());
        }
        else
        {
            Debug.LogError("Cannot set " + nameof(SFX_VOLUME_KEY) + " to " + volume.ToString() + ". Out of range.");
        }
        
    }

    public static void SetMusicVolume(float volume)
    {
        if ((volume >= MIN_MUSIC_VOLUME) && (volume <= MAX_MUSIC_VOLUME))
        {
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
            Debug.Log(nameof(MUSIC_VOLUME_KEY) + "set to " + volume.ToString());
        }
        else
        {
            Debug.LogError("Cannot set " + nameof(MUSIC_VOLUME_KEY) + " to " + volume.ToString() + ". Out of range.");
        }
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, DEFAULT_MUSIC_VOLUME);
    }

}
