using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<WaveConfig> waveConfigs;
    [SerializeField] bool looping = false;

    private int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (looping)
        {
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping);
    }

    private IEnumerator SpawnAllWaves()
    {
        for (int waveIndex = startingWave; waveIndex < waveConfigs.Count; waveIndex++)
        {
            var currentWave = waveConfigs[waveIndex];
            yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
        }
    }

    private IEnumerator SpawnAllEnemiesInWave(WaveConfig currentWave)
    {
        for (int i = 0; i < currentWave.GetNumberOfEnemies(); i++)
        {
            
            var enemy = Instantiate(currentWave.GetEnemyPrefab(), currentWave.GetWaypoints()[0].transform.position,
                Quaternion.identity);
            enemy.GetComponent<EnemyWaypoint>().SetWaveConfig(currentWave);
            yield return new WaitForSeconds(currentWave.GetTimeBetweenSpawns());
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}