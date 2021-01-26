using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] Projectile projectile = null;
    [SerializeField] GameObject gun = null;

    AttackerSpawner myLaneSpawner = null;
    Animator animator = null;

    GameObject projectileParent = null;


    const string PROJECTILE_PARENT_NAME = "Projectiles";

    private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }    

    private void Update()
    {
        if (IsAttackerInLane())
        {
            animator.SetBool("IsAttacking", true);
            Debug.Log("Shoot");
        }
        else
        {
            animator.SetBool("IsAttacking", false);
            Debug.Log("sit and wait");
        }
    }

    private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTILE_PARENT_NAME);
        if (projectileParent == null)
        {
            projectileParent = new GameObject(PROJECTILE_PARENT_NAME);
        }
    }

    public void Fire()
    {
        Projectile newProjectile = Instantiate(projectile, gun.transform.position, gun.transform.rotation) as Projectile;
        string rootGameObjectTag = transform.root.gameObject.tag;
        newProjectile.tag = rootGameObjectTag;
        Debug.Log(projectile.name + " tag set to " + newProjectile.tag);

        newProjectile.transform.parent = projectileParent.transform;
        projectileParent.tag = newProjectile.tag; //Set the Parent tag to be the same as its child's tag, otherwise projectile will collide with "untagged" and kill it.
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner != null)
        {
            if (myLaneSpawner.transform.childCount <= 0)
            {
                return false; //No attackers in this lane
            }
            else
            {
                return true; //There is an attacker in the lane
            }
        }
        else
        {
            Debug.Log("No attacking lane spawn in lane " + transform.position.y);
            return false;
        }
        
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach(AttackerSpawner spawner in spawners)
        {
            bool isCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon);
            if (isCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public int GetAttackPower()
    {
        return projectile.GetAttackPower();
    }
}
