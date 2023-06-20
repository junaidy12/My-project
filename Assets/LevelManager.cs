using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] Enemy enemyPrefab;
    [SerializeField] Transform enemyPoolHolder;

    [SerializeField] int levelNumber;
    [SerializeField] WaveSO[] levelWaves;

    List<Enemy> enemiesSpawned = new List<Enemy>();

    bool spawnWave;
    int currentWaveNumber = 0;
    WaveSO currentLevel;

    private void Start()
    {
        int startSpawnAmount = 0;
        currentLevel = levelWaves[levelNumber];
        for (int i = 0; i < currentLevel.GetWaveLength(); i++)
        {
            startSpawnAmount += currentLevel.GetWave(i).amountToSpawn;
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
            while (currentWaveNumber < currentLevel.GetWaveLength())
            {
                Wave currentWave = currentLevel.GetWave(currentWaveNumber);
                int i = 0;
                yield return new WaitForSeconds(currentLevel.GetDelayBetweenWave());

                foreach (Enemy enemy in enemiesSpawned)
                {
                    if (i < currentWave.amountToSpawn && !enemy.gameObject.activeSelf)
                    {
                        enemy.GetComponentInChildren<SpriteRenderer>().color = currentWave.color;
                        enemy.gameObject.SetActive(true);
                        i += 1;
                        yield return new WaitForSeconds(currentWave.delayBetweenEnemy);
                    }
                }

                currentWaveNumber += 1;
                yield return new WaitForSeconds(currentLevel.GetDelayBetweenWave());
                StartCoroutine(SpawnEnemy());
            }
        }
    }
}
