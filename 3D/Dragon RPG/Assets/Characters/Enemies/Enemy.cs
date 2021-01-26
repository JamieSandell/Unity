using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class Enemy : MonoBehaviour, IDamageable
{
    [SerializeField] float maxHealthPoints = 100f;
    private float currentHealthPoints;

    [SerializeField] float chaseRadius = 5f;
    [SerializeField] float attackRadius = 10f;
    [SerializeField] Vector3 aimOffset = new Vector3(0f, 1f, 0f);
    [SerializeField] float fireRateInSeconds = 0.5f;
    [SerializeField] float damagePerShot = 9f;
    [SerializeField] GameObject projectileToUse = null;
    [SerializeField] GameObject projectileSocket = null;

    private bool isAttacking = false;

    ThirdPersonCharacter thirdPersonCharacter = null;
    AICharacterControl aICharacterControl = null;
    GameObject player = null;

    private void Start()
    {
        currentHealthPoints = maxHealthPoints;
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        player = GameObject.FindGameObjectWithTag("Player");
        aICharacterControl = GetComponent<AICharacterControl>();
    }

    private void Update()
    {
        float distanceToPlayer = Vector3.Distance(player.transform.position, transform.position);
        ProcessChase(distanceToPlayer);
        ProcessAttack(distanceToPlayer);
    }

    

    private void ProcessAttack(float distanceToPlayer)
    {
        if (distanceToPlayer <= attackRadius && isAttacking == false)
        {
            isAttacking = true;
            InvokeRepeating("SpawnProjectile", fireRateInSeconds, fireRateInSeconds);
            SpawnProjectile();
        }

        if (distanceToPlayer > attackRadius)
        {
            isAttacking = false;
            CancelInvoke("SpawnProjectile");
        }
    }

    private void SpawnProjectile()
    {
        // Create a new instance of the projectile and set it's damage caused
        GameObject newProjectile = Instantiate(projectileToUse, projectileSocket.transform.position, Quaternion.identity);
        Projectile projectileCompoment = newProjectile.GetComponent<Projectile>();
        projectileCompoment.SetDamage(damagePerShot);

        // Gets a vector that points from the player's position to the target's.
        Vector3 heading = (player.transform.position + aimOffset) - newProjectile.transform.position;
        float distance = heading.magnitude;
        Vector3 direction = heading / distance; // This is now the normalized direction.

        // Set the velocity of the new projectile
        float projectileSpeed = projectileCompoment.projectileSpeed;
        newProjectile.GetComponent<Rigidbody>().velocity = direction * projectileSpeed;

        //Orientate the arrow so it is facing the player
        newProjectile.GetComponent<Rigidbody>().transform.transform.forward = direction;

    }

    private void ProcessChase(float distanceToPlayer)
    {
        if (distanceToPlayer <= chaseRadius)
        {
            aICharacterControl.SetTarget(player.transform);
        }
        else
        {
            aICharacterControl.SetTarget(transform);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRadius);
    }

    public void TakeDamage(float damage)
    {
        currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
        if (currentHealthPoints <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
    }
}
