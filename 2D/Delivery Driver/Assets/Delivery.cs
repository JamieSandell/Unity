using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] float destroyPackageInSeconds = 1.0f;
    [SerializeField] Color32 hasPackageColour = new Color32(1, 1, 1, 1);
    [SerializeField] Color32 doesNotHavePackageColour = new Color32(0,0,0,1);
    bool hasPackage = false;
    SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Collided with " + other.gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage)
        {
            hasPackage = true;
            spriteRenderer.color = hasPackageColour;
            Debug.Log("Package collected");
            Destroy(other.gameObject, destroyPackageInSeconds);
        }
        else if (other.tag == "Customer" && hasPackage)
        {
            spriteRenderer.color = doesNotHavePackageColour;
            Debug.Log("Package delivered to customer");
            hasPackage = false;
        }
    }
}
