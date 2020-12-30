using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclesSpawner : MonoBehaviour
{
    [SerializeField] List<ObstacleWave> waveConfigList;


    int FirstWave = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waveConfigList[FirstWave];

        StartCoroutine(SpawnAllObstaclesInWave(currentWave));   

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllObstaclesInWave(ObstacleWave waveConfig)
    {
        Instantiate(
            waveConfig.GetObstaclesPrefab(),
            waveConfig.GetWayPoints()[0].transform.position,
            Quaternion.identity);

        yield return new WaitForSeconds(waveConfig.GetTimeBetweenSpawning());
    }
}
