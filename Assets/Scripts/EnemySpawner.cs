using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoSingleton<EnemySpawner>
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 0f;

    WaveConfigSO currentWave;
    public WaveConfigSO CurrentWave { get { return currentWave; } }

    [SerializeField] bool isLooping = true;

    private void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int index = 0; index < currentWave.GetEnemyCount(); index++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(index), currentWave.GetStartingWaypoint().position, Quaternion.Euler(180, 0, 0), transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }
}
