using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour {
    //Config parameters
    WaveConfig waveConfig;
    List<Transform> wayPoints;

    int wayPointIndex = 0; //first waypoint

	// Use this for initialization
	void Start () {
        wayPoints = waveConfig.GetWaypoints();
        transform.position = wayPoints[wayPointIndex].transform.position; //set the object's position we are attached to, to the position of a waypoint.
	}
	
	// Update is called once per frame
	void Update ()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        this.waveConfig = waveConfig;
    }

    private void Move()
    {
        if (wayPointIndex <= wayPoints.Count - 1)
        {
            var targetPosition = wayPoints[wayPointIndex].transform.position;
            var movementThisFrame = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, movementThisFrame);

            if (transform.position == targetPosition) //Have we reached our waypoint? If so move on to the next waypoint
            {
                wayPointIndex++;
            }
        }
        else //No more waypoints left
        {
            Object.Destroy(gameObject);
        }
    }
}
