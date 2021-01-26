using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    private Health health = null;

    private void Awake()
    {
        health = GetComponent<Health>();
        if (health == null)
        {
            Debug.LogError(name + " has no health component.");
        }
    }

    public int GetHealth()
    {
        return health.GetHealth();
    }

    public void SetHealth(int value)
    {
        health.SetHealth(value);
    }
}
