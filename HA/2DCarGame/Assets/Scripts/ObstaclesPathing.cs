using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesPathing : MonoBehaviour
{

    [SerializeField] List<Transform> obstaclesWaypoints;
    [SerializeField] float ObstacleSpeed = 2f;

    [SerializeField] ObstacleWave waveConfig;

    int waypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {

        obstaclesWaypoints = waveConfig.GetWayPoints();


        transform.position = obstaclesWaypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    private void ObstacleMove()
    {
        if (waypointIndex <= obstaclesWaypoints.Count - 1)
        {
            var targetPosition = obstaclesWaypoints[waypointIndex].transform.position;

            targetPosition.z = 0f;

            var obstacleMovement = waveConfig.GetObstacleSpeed() * Time.deltaTime; 

            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetWaveConfig(ObstacleWave waveConfigToBeSet)
    {
        waveConfig = waveConfigToBeSet;
    }
}
