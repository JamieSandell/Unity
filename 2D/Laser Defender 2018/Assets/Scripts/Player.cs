using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    // Configuration parameters
    [Header("Player Stats")]
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] int health = 300;

    [Header("Projectile")]
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
    [SerializeField] [Range(0f, 1f)] float laserFiredVolume = 0.25f;

    //Coroutines
    Coroutine firingCoroutine;

    // Player movement parameters
    float xMin;
    float xMax;
    float yMin;
    float yMax;
    float spriteWidth; //used for padding
    float spriteHeight; //used for padding

	// Use this for initialization
	void Start () {
        spriteWidth = GetComponent<SpriteRenderer>().bounds.size.x;
        spriteHeight = GetComponent<SpriteRenderer>().bounds.size.y;
        SetUpMoveBoundaries();
    }

    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y;

        //Take in to consideration that the rotation point is around the sprite's centre, otherwise half of the sprite would be able to go out of the boundaries.
        xMin = xMin + (spriteWidth / 2);
        xMax = xMax - (spriteWidth / 2);

        yMin = yMin + (spriteHeight / 2);
        yMax = yMax - (spriteHeight / 2);

    }

    // Update is called once per frame
    void Update () {
        Move();
        Fire();        
	}

    private void Fire()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firingCoroutine =  StartCoroutine(FireContinuously());
        }
        if (Input.GetButtonUp("Fire1"))
        {
            StopCoroutine(firingCoroutine);
        }
    }

    private IEnumerator FireContinuously()
    {
        while (true)
        {
            Vector3 position = transform.position;
            position.y = position.y + (spriteHeight / 2); //offset from the centre of the player ship's position

            GameObject laser = Instantiate(
                laserPrefab,
                position,
                Quaternion.identity) as GameObject;

            laser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, projectileSpeed);

            LaserFiredSFX();

            yield return new WaitForSeconds(projectileFiringPeriod);
        }
        
    }

    private void LaserFiredSFX()
    {
        AudioSource.PlayClipAtPoint(laserFiredSFX, Camera.main.transform.position, laserFiredVolume);
    }

    private void Move()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax);
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax);
        transform.position = new Vector2(newXPos, newYPos);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        ProcessDamagerDealerCollision(other);
        ProcessCoinCollision(other);
        ProcessHealthPackCollision(other);
    }

    private void ProcessHealthPackCollision(Collider2D other)
    {
        HealthPack healthPack = other.gameObject.GetComponent<HealthPack>();
        if (!healthPack)
        {
            return;
        }
        else
        {
            ProcesHit(healthPack);
        }
    }

    private void ProcesHit(HealthPack healthPack)
    {
        health += healthPack.Hit();
    }

    private void ProcessCoinCollision(Collider2D other)
    {
        GoldCoin goldCoin = other.gameObject.GetComponent<GoldCoin>();
        if (!goldCoin)
        {
            return;
        }
        else
        {
            ProcesHit(goldCoin);
        }
    }

    private void ProcessDamagerDealerCollision(Collider2D other)
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
        ClampHealth();
        
        damageDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void ProcesHit(GoldCoin goldCoin)
    {
        goldCoin.Hit(); //Let the gold coin know we hit it
    }

    private void ClampHealth()
    {
        if (health < 0)
        {
            health = 0; //don't want negative health displayed
        }
    }

    private void Die()
    {
        Explode();
        Destroy(gameObject);
        FindObjectOfType<Level>().LoadGameOver();
    }

    public int GetHealth()
    {
        return health;
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
