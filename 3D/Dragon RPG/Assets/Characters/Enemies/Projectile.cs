using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 10f; // Note other classes can set
    private float damageCaused;
    
    private void OnCollisionEnter(Collision collider)
    {        
        Component damageableComponent = collider.gameObject.GetComponent(typeof(IDamageable));
        if (damageableComponent)
        {
            (damageableComponent as IDamageable).TakeDamage(damageCaused);
            Destroy(this.gameObject);
        }

    }

    public void SetDamage(float damage)
    {
        damageCaused = damage;
    }
}
