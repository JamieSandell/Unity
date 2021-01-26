using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] GameObject onDiePrefab = null;
    [SerializeField] float durationOfOnDieVFX = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip onDieSFX = null;
    [SerializeField] [Range(0f, 1f)] float deathSoundVolume = 0.7f;

    [Header("Resource")]
    [SerializeField] int starCost = 100;

    [Header("Stats")]
    [SerializeField] string defenderName = "";
    [SerializeField] string specialAbility = "";

    private Health healthComponent = null;
    private Shooter shooter = null;

    private void Awake()
    {
        healthComponent = GetComponent<Health>();
        if (healthComponent == null)
        {
            Debug.LogError("Health component is null on " + gameObject.name);
        }


        shooter = GetComponentInChildren<Shooter>();
        if (shooter == null)
        {
            Debug.Log("Shooter component is null on " + gameObject.name);
        }
    }

    void Update()
    {
        if (healthComponent.GetHealth() <= 0)
        {
            Die();
        }
    }

    public void AddStars(int amount)
    {
        FindObjectOfType<StarDisplay>().AddStars(amount);
    }

    private void Die()
    {
        DeathFX();
        Destroy(gameObject);
    }

    private void DeathFX()
    {
        DieVFX();
        DieSFX();
    }

    private void DieSFX()
    {
        if (onDieSFX != null)
        {
            AudioSource.PlayClipAtPoint(onDieSFX, Camera.main.transform.position, deathSoundVolume);
        }        
    }

    private void DieVFX()
    {
        if (onDiePrefab != null)
        {
            GameObject dieVFX = Instantiate(
                    onDiePrefab,
                    transform.position,
                    Quaternion.identity) as GameObject;

            Destroy(dieVFX, durationOfOnDieVFX);

        }
        
    }

    private void Fire()
    {
        shooter.Fire();
    }

    public int GetAttackPower()
    {
        if (shooter)
        {
            return shooter.GetAttackPower();
        }        
        else
        {
            return 0;
        }
    }

    public Sprite GetCharacterSprite()
    {
        return GetComponentInChildren<SpriteRenderer>().sprite;
    }

    public int GetHealth()
    {
        return healthComponent.GetHealth();
    }

    public string GetName()
    {
        return defenderName;
    }

    public string GetSpecialAbility()
    {
        return specialAbility;
    }

    public int GetStarCost()
    {
        return starCost;
    }    

}
