using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] List<ObstacleWave> waveConfigList;

    [SerializeField] bool looping = false;

    int FirstWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        do
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllObstaclesInWave(ObstacleWave waveConfig)
    {
        for (int obstacleCount = 1; obstacleCount <= waveConfig.GetnumberOfObstacles(); obstacleCount++)
        {
           var newObstacle = Instantiate(
                                waveConfig.GetObstaclesPrefab(),
                                waveConfig.GetWayPoints()[0].transform.position,
                                Quaternion.identity);

            newObstacle.GetComponent<ObstaclesPathing>().SetWaveConfig(waveConfig);



            yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawning());
        } 
        
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (ObstacleWave currentWave in waveConfigList)
        {
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }

}
