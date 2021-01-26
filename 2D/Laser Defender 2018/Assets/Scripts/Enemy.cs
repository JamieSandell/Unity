using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    [Header("Stats")]
    [SerializeField] float health = 100f;
    [SerializeField] int scoreValue = 150;

    [Header("Laser")]
    float shotCounter;
    [SerializeField] float minTimeBetweenShots = 0.2f;
    [SerializeField] float maxTimeBetweenShots = 3f;
    [SerializeField] GameObject laserPrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileFiringPeriod = 0.05f;

    [Header("VFX")]
    [SerializeField] GameObject onDiePrefab;
    [SerializeField] float durationOfExplosion = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip laserFiredSFX;
    [SerializeField] AudioClip onDieSFX;
    [SerializeField] [Range(0f, 1f)] float deathSoundVolume = 0.7f;
    [SerializeField] [Range(0f, 1f)] float floatlaserFiredVolume = 0.25f;

    float spriteWidth; //used for padding
    float spriteHeight; //used for padding

    // Use this for initialization
    void Start ()
    {
        ResetShotCounter();

        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
    }

    private void ResetShotCounter()
    {
        shotCounter = UnityEngine.Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    // Update is called once per frame
    void Update () {
        CountDownAndShoot();
	}

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        if (shotCounter <= 0f)
        {
            Fire();
        }
    }

    private void Fire()
    {
        Vector3 position = transform.position;
        position.y = position.y - (spriteHeight / 2); //offset from the centre of the enemy ship's position

        GameObject laser = Instantiate(
            laserPrefab,
            position,
            Quaternion.identity) as GameObject;

        laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -projectileSpeed);

        ResetShotCounter();

        LaserFiredSFX();
    }

    private void LaserFiredSFX()
    {
        AudioSource.PlayClipAtPoint(laserFiredSFX, Camera.main.transform.position, floatlaserFiredVolume);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.gameObject.GetComponent<DamageDealer>();
        if (!damageDealer)
        {
            return;
        }
        else
        {
            ProcesHit(damageDealer);
        }
    }

    private void ProcesHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        FindObjectOfType<GameSession>().AddToScore(scoreValue);
        Explode();
        GetComponent<Loot>().DropLoot();
        Destroy(gameObject);
    }

    private void Explode()
    {
        ExplodeVFX();
        ExplodeSFX();
    }

    private void ExplodeSFX()
    {
        AudioSource.PlayClipAtPoint(onDieSFX, Camera.main.transform.position, deathSoundVolume);
    }

    private void ExplodeVFX()
    {
        GameObject explosion = Instantiate(
                    onDiePrefab,
                    transform.position,
                    Quaternion.identity) as GameObject;

        Destroy(explosion, durationOfExplosion);
    }
}
