using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void ApplyDamage(Health health, int damage)
    {
        if (health)
        {
            Debug.Log("Apply damage: " + damage.ToString());
            health.DecreaseHealth(damage);
        }
        else
        {
            Debug.LogError("Health component is null, can't apply damage");
        }
        
    }
}
