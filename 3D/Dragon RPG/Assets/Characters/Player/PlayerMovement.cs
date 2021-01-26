using System;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;
using UnityEngine.AI;

[RequireComponent(typeof(AICharacterControl))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof (ThirdPersonCharacter))]
public class PlayerMovement : MonoBehaviour
{
    //TODO solve fight between const and serialize
    [SerializeField] const int enemyLayerNumber = 10;
    [SerializeField] const int walkableLayerNumber = 9;

    private bool isInDirectMode = false;

    ThirdPersonCharacter thirdPersonCharacter = null;   // A reference to the ThirdPersonCharacter on the object
    CameraRaycaster cameraRaycaster = null;

    Vector3 currentDestination;
    Vector3 clickPoint;

    AICharacterControl aICharacterControl = null;

    GameObject walkTarget = null;

    void Start()
    {        
        thirdPersonCharacter = GetComponent<ThirdPersonCharacter>();
        currentDestination = transform.position;

        cameraRaycaster = Camera.main.GetComponent<CameraRaycaster>();
        cameraRaycaster.notifyMouseClickObservers += ProcessMouseClick;

        aICharacterControl = GetComponent<AICharacterControl>();

        walkTarget = new GameObject("Walk Target");
    }

    private void ProcessMouseClick(RaycastHit raycastHit, int layerHit)
    {
        switch (layerHit)
        {
            case enemyLayerNumber:
                // Navigate to the enemy
                GameObject enemy = raycastHit.collider.gameObject;
                aICharacterControl.SetTarget(enemy.transform);
                Debug.Log("Enemy clicked");
                break;
            case walkableLayerNumber:
                // Navigate to point on the ground                
                walkTarget.transform.position = raycastHit.point;
                aICharacterControl.SetTarget(walkTarget.transform);
                Debug.Log("Walkable area clicked");
                break;
            default:
                Debug.LogWarning("Don't know how to handle mouse click in player movement");
                return;
        }
    }
}

