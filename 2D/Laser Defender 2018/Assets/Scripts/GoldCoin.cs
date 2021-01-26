using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldCoin : MonoBehaviour {

    [Header("Stats")]
    [SerializeField] int value = 100;

    [Header("VFX")]
    [SerializeField] GameObject onCollectedPrefab;
    [SerializeField] float durationOfEffect = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip onCollectedSFX;
    [SerializeField] [Range(0f, 1f)] float collectedSoundVolume = 0.7f;

    public void Hit()
    {
        FindObjectOfType<GameSession>().AddToScore(value);
        Collected();
        Destroy(gameObject);
    }

    public int GetValue()
    {
        return value;
    }

    public void SetValue(int value)
    {
        this.value = value;
    }

    private void Collected()
    {
        CollectedVFX();
        CollectedSFX();
    }

    private void CollectedSFX()
    {
        AudioSource.PlayClipAtPoint(onCollectedSFX, Camera.main.transform.position, collectedSoundVolume);
    }

    private void CollectedVFX()
    {
        GameObject effect = Instantiate(
                    onCollectedPrefab,
                    transform.position,
                    Quaternion.identity) as GameObject;

        Destroy(effect, durationOfEffect);
    }
}
