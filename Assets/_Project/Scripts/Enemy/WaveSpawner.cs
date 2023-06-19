using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefabs;

    public Transform spawnPoint;

    [SerializeField] private int baseEnemies = 8;
    [SerializeField] private float enemiesPerSecond = 0.5f;
    [SerializeField] private float timeBetweenWaves = 5f;
    [SerializeField] private float difficultyScalingFactor = 0.75f;

    public static float countdown;
    
    private int waveIndex = 1;
    private float timeSinceLastSpawn;
    private int enemiesAlive;
    private int enemiesLeftToSpawn;
    private bool isSpawning = false;

    private void Start()
    {
        countdown = timeBetweenWaves;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameOver)
        {
            return;
        }

        if (!GameManager.Instance.isGameStarted)
        {
            return;
        }

        if (!isSpawning)
        {
            if (countdown > 0f)
            {
                countdown -= Time.deltaTime;
                countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
            }

            return;
        }

        timeSinceLastSpawn += Time.deltaTime;

        if (timeSinceLastSpawn >= (1f / enemiesPerSecond) && enemiesLeftToSpawn > 0)
        {
            SpawnEnemy();
            enemiesLeftToSpawn--;
            enemiesAlive++;
            timeSinceLastSpawn = 0f;
        }

        if (enemiesAlive == 0 && enemiesLeftToSpawn == 0)
        {
            EndWave();
        }
    }

    private void OnEnable()
    {
        BusSystem.OnEnemyDestroyed += OnEnemyDestroyed;
        BusSystem.OnStartGame += OnStartGame;
    }

    private void OnDisable()
    {
        BusSystem.OnEnemyDestroyed -= OnEnemyDestroyed;
        BusSystem.OnStartGame -= OnStartGame;
    }
    private void OnEnemyDestroyed()
    {
        enemiesAlive--;
    }

    private void OnStartGame()
    {
        DOVirtual.DelayedCall(timeBetweenWaves, () => StartWave());
    }

    private void StartWave()
    {
        isSpawning = true;
        enemiesLeftToSpawn = EnemiesPerWave();

        countdown = timeBetweenWaves;
    }

    private void EndWave()
    {
        isSpawning = false;
        timeSinceLastSpawn = 0f;
        waveIndex++;

        PlayerStats.Rounds++;

        DOVirtual.DelayedCall(timeBetweenWaves, () => StartWave());
    }

    private void SpawnEnemy()
    {
        GameObject enemyToSpawn = enemyPrefabs[0];
        Instantiate(enemyToSpawn, spawnPoint.position, Quaternion.identity);
    }

    private int EnemiesPerWave()
    {
        return Mathf.RoundToInt(baseEnemies * Mathf.Pow(waveIndex, difficultyScalingFactor));
    }
}
