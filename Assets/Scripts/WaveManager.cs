using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class WaveManager : MonoBehaviour
{
    [SerializeField] Transform enemyPoolHolder;
    [SerializeField] Enemy enemyPrefab;

    [SerializeField] Wave[] waves;
    [SerializeField] float delayBetweenSpawn;

    [SerializeField] List<Enemy> enemiesSpawned = new List<Enemy>();

    int startSpawnAmount;

    int totalWaves;
    int currentWave = 0;

    bool spawnWave;

    private void Start()
    {
        totalWaves = waves.Length;
        for (int i = 0; i < waves.Length; i++)
        {
            startSpawnAmount += waves[i].amountToSpawn;
            
        }
        Mathf.Clamp(startSpawnAmount, 1, 200);
        for (int i = 0; i < startSpawnAmount; i++)
        {
            Enemy enemySpawned = Instantiate(enemyPrefab, Vector3.zero, Quaternion.identity, enemyPoolHolder);
            enemySpawned.gameObject.SetActive(false);
            enemiesSpawned.Add(enemySpawned);
        }
        spawnWave = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            spawnWave = !spawnWave;
        }
        if (spawnWave)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        if (spawnWave)
        {
            spawnWave = false;
            while (currentWave < totalWaves)
            {
                int i = 0;
                yield return new WaitForSeconds(waves[currentWave].delayBeforeSpawn);

                foreach (Enemy enemy in enemiesSpawned)
                {
                    if (i < waves[currentWave].amountToSpawn && !enemy.gameObject.activeSelf)
                    {
                        enemy.GetComponentInChildren<SpriteRenderer>().color = waves[currentWave].color;
                        waves[currentWave].enemiesRef.Add(enemy);
                        enemy.gameObject.SetActive(true);
                        i += 1;
                        yield return new WaitForSeconds(waves[currentWave].delayBetweenEachSpawn);
                    }
                }
                
                waves[currentWave].finishSpawning = true;
                currentWave += 1;
                yield return new WaitForSeconds(delayBetweenSpawn);
                StartCoroutine(SpawnEnemy());
            }
        }
        
    }
}
