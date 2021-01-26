using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMummy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;
        Debug.Log(name + " collided with " + otherObject.name);
        if (otherObject.tag == "Friendly") //Is what we are attacking a defender?
        {
            if (otherObject.GetComponent<Gravestone>())
            {
                SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
                Color color = spriteRenderer.color;
                color.a = 0.5f;
                spriteRenderer.color = color; //collided with a gravestone so don't attack it, walk through it and set our transparency to 50% to make it obvious
            }
            else
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

    private void OnCollisionExit2D(Collision2D collision)
    {
        GameObject otherObject = collision.gameObject;

        if (otherObject.GetComponent<Gravestone>())
        {
            SpriteRenderer spriteRenderer = GetComponentInChildren<SpriteRenderer>();
            Color color = spriteRenderer.color;
            color.a = 1.0f;
            spriteRenderer.color = color; //stopped colliding with a gravestone so set our transparency to 50% to make it obvious
        }
    }
}
