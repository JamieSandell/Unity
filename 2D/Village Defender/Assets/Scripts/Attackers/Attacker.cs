using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{
    [Header("VFX")]
    [SerializeField] GameObject onDiePrefab = null;
    [SerializeField] float durationOfOnDieVFX = 1f;

    [Header("SFX")]
    [SerializeField] AudioClip onDieSFX = null;
    [SerializeField] AudioClip onSpawnSFX = null;

    [Header("Stats")]
    [SerializeField] int attackPower = 100;
    [SerializeField] [Range(0f, 5f)] float currentSpeed = 1f;

    private DamageDealer damageDealer = null;
    private GameObject currentTarget = null;
    private Health healthComponent = null;

    private void Awake()
    {
        //Get our required components
        damageDealer = GetComponent<DamageDealer>();
        healthComponent = GetComponent<Health>();
    }

    void Start()
    {     
        //Build our items list to check for Null
        var itemsToCheckForNull = new List<Tuple<GameObject, UnityEngine.Object, string>>
        {
            Tuple.Create(this.gameObject, (UnityEngine.Object)onDiePrefab, nameof(onDiePrefab)),
            Tuple.Create(this.gameObject, (UnityEngine.Object)onDieSFX, nameof(onDieSFX)),
            Tuple.Create(this.gameObject, (UnityEngine.Object)onSpawnSFX, nameof(onSpawnSFX)),
            Tuple.Create(this.gameObject, (UnityEngine.Object)damageDealer, nameof(damageDealer)),
            Tuple.Create(this.gameObject, (UnityEngine.Object)healthComponent, nameof(healthComponent))
        };
        //Check for null and display an error on the item list we just built
        foreach (var item in itemsToCheckForNull)
        {
            Utility.ErrorIfNull(item.Item1, item.Item2, item.Item3);
        }

        //Play the spawn SFX
        AudioSource.PlayClipAtPoint(onSpawnSFX, Camera.main.transform.position);        
    }

    void Update()
    {
        if (healthComponent.GetHealth() <= 0)
        {
            Die();
        }
        else
        {
            transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);
        }

        UpdateAnimationState();
    }

    private void UpdateAnimationState()
    {
        if (!currentTarget)
        {
            GetComponent<Animator>().SetBool("isAttacking", false);
        }
       
    }

    public void Attack(GameObject target)
    {
        currentTarget = target;
        GetComponent<Animator>().SetBool("isAttacking", true);
        Debug.Log("Attack");
    }

    public void SetMovementSpeed(float speed)
    {
        currentSpeed = speed;
    }

    public void StrikeCurrentTarget(int damage)
    {
        //TODO Is this in the animator? If so remove int damage and use the serialised field attackPower
        if (!currentTarget)
        {           
            return;
        }
        else
        {
            Health health = currentTarget.GetComponent<Health>();
            damageDealer.ApplyDamage(health, damage);
        }
    }

    public int GetHealth()
    {
        return healthComponent.GetHealth();
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
        AudioSource.PlayClipAtPoint(onDieSFX, Camera.main.transform.position);
    }

    private void DieVFX()
    {
        GameObject dieVFX = Instantiate(
                onDiePrefab,
                transform.position,
                Quaternion.identity) as GameObject;

        Destroy(dieVFX, durationOfOnDieVFX);
    }
}
