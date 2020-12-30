using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]
public class ObstacleWave : ScriptableObject
{

    [SerializeField] GameObject ObstaclesPrefab;

    [SerializeField] GameObject pathPrefab;

    [SerializeField] float timeBetweenSpawning = 0.5f;

    [SerializeField] float spawnRandomFactor = 0.3f;

    [SerializeField] int numberOfObstacles = 3;

    [SerializeField] float ObstacleSpeed = 2f;

    public GameObject GetObstaclesPrefab()
    {
        return ObstaclesPrefab;
    }

    public List<Transform> GetWayPoints()
    {
        var waveWayPoints = new List<Transform>();

        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;

    }

    public GameObject GetPathPrefab()
    {
        return pathPrefab;
    }

    public float GetTimeBetweenSpawning()
    {
        return timeBetweenSpawning;
    }

    public float GetspawnRandomFactor()
    {
        return spawnRandomFactor;
    }

    public int GetnumberOfObstacles()
    {
        return numberOfObstacles;
    }

    public float GetObstacleSpeed()
    {
        return ObstacleSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
