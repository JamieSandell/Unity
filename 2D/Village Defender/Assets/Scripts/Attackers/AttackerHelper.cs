using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackerHelper : MonoBehaviour
{
    private Attacker attacker = null;

    void Awake()
    {
        attacker = GetComponentInParent<Attacker>();
        if (attacker == null)
        {
            Debug.LogError("Attacker is null in parent of " + gameObject.name);
        }
    }

    public void SetMovementSpeed(float speed)
    {
        attacker.SetMovementSpeed(speed);
    }
}
