using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable {    
    [SerializeField] private float maxHealthPoints = 100f;
    private float currentHealthPoints;

    [SerializeField] float maxAttackRange = 2f;
    [SerializeField] float damagePerHit = 10f;
    [SerializeField] float minTimeBetweenHits = 0.5f;
    private float timeSinceLastHit = 0f;

    //TODO solve fight between const and serialize
    [SerializeField] const int enemyLayerNumber = 10;
    private GameObject currentTarget = null;
    private CameraRaycaster cameraRaycaster;

    private void Start()
    {
        currentHealthPoints = maxHealthPoints;
        //ToDo should be find object of type?
        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        cameraRaycaster.notifyMouseClickObservers += ProcessMouseClick;
    }

    public float healthAsPercentage
    {
        get
        {
            return currentHealthPoints / maxHealthPoints;
        }
    }

    public void TakeDamage(float damage)
    {
        currentHealthPoints = Mathf.Clamp(currentHealthPoints - damage, 0f, maxHealthPoints);
    }

    public void ProcessMouseClick(RaycastHit raycastHit, int layerHit)
    {
        if (layerHit == enemyLayerNumber) //enemy clicked
        {
            GameObject enemy = raycastHit.collider.gameObject;
            //Check if enemy is in range, don't do anything else if the enemy is out of range
            if ((enemy.transform.position - transform.position).magnitude > maxAttackRange)
            {
                return;
            }

            if (Time.time - timeSinceLastHit > minTimeBetweenHits) //Ready to attack again
            {                
                Enemy enemyComponent = enemy.GetComponent<Enemy>();
                //Check if enemy is in range
                if ((enemy.transform.position - transform.position).magnitude <= maxAttackRange)
                {
                    enemyComponent.TakeDamage(damagePerHit);
                    timeSinceLastHit = Time.time;
                }                    
            }            
        }
    }
}
