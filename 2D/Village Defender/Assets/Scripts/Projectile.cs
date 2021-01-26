using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;
    [SerializeField] int attackPower = 50;
    [SerializeField] AudioClip impactSFX = null;
    [SerializeField] AudioClip throwSFX = null;

    private DamageDealer damageDealer = null;

    void Start()
    {
        damageDealer = GetComponent<DamageDealer>();
        if (damageDealer == null)
        {
            Debug.LogError(gameObject.name + " damageDealer == null");
        }
        if (impactSFX == null)
        {
            Debug.LogError("No impactSFX on " + name);
        }
        if (throwSFX == null)
        {
            Debug.LogError("No throwSFX on " + name);
        }
        else
        {
            AudioSource.PlayClipAtPoint(throwSFX, Camera.main.transform.position);
        }
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //string rootGameObjectTag = transform.root.gameObject.tag;
        string collisionGameObjectTag = collision.gameObject.tag;

        //Are we colliding with something that is tagged different to us - e.g. Friendly hitting an attacker?
        //If so does it have a health component that we can apply damage to?
        if (gameObject.tag != collisionGameObjectTag)
        {
            Debug.Log(gameObject.name + ": I've collided with " + collision.gameObject.name);
            Debug.Log("My game object tag is " + gameObject.tag);
            Debug.Log("Their game object tag is " + collisionGameObjectTag);
            Health collisionHealth = collision.gameObject.GetComponentInParent<Health>();
            if (collisionHealth != null)
            {
                damageDealer.ApplyDamage(collisionHealth, attackPower);
                AudioSource.PlayClipAtPoint(impactSFX, Camera.main.transform.position);
                Destroy(this.gameObject);
            }
            else
            {
                Debug.Log("Health component does not exist on " + collision.transform.parent.gameObject.name);
            }
        }
    }

    public int GetAttackPower()
    {
        return attackPower;
    }
}
