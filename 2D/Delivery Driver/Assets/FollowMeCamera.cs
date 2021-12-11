using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMeCamera : MonoBehaviour
{
    [SerializeField] GameObject objectToFollow;
    private void LateUpdate()
    {
        transform.position = objectToFollow.transform.position + new Vector3(0.0f, 0.0f, -10.0f);
    }
}
