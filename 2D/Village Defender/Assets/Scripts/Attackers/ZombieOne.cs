using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieOne : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {        
        GameObject otherObject = collision.gameObject;
        Debug.Log(name + " collided with " + otherObject.name);
        if (otherObject.tag == "Friendly") //Is what we are attacking a defender?
        {
            Health collisionHealth = otherObject.GetComponent<Health>(); //Has it got a health component we can actually apply damage to?
            if (collisionHealth != null)
            {                
                GetComponent<Attacker>().Attack(otherObject);
            }
            else
            {
                Debug.Log("No health component on " + otherObject.name);
            }
        }
    }
}
