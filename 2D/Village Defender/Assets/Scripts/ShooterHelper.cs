using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterHelper : MonoBehaviour
{
    private Shooter shooter = null;

    public void Awake()
    {
        shooter = GetComponentInChildren<Shooter>();
        if (shooter == null)
        {
            Debug.LogError("Shooter is null on " + gameObject.name);
        }
    }

    public void Fire()
    {
        shooter.Fire();
    }
}
