using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnEnemy : MonoBehaviour
{
    //public GameObject enemyPrefab; // Префаб врага
    //public Transform[] spawnPoints; // Массив точек спавна врагов
    //public float spawnInterval = 3f; // Интервал между спавном врагов
    //public Transform target; // Цель, к которой будут приближаться враги

    //void Start()
    //{
    //    // Запускаем процесс спавна врагов с заданным интервалом
    //    InvokeRepeating("EnemySpawner", 0f, spawnInterval);
    //}

    //void EnemySpawner()
    //{
    //    // Выбираем случайную точку спавна из массива
    //    Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

    //    // Создаем врага на выбранной точке спавна
    //    GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

    //    // Плавно приближаем врага к цели (пушке) с использованием DOTween
    //    enemy.transform.DOMove(target.position, 7f).SetEase(Ease.InOutQuad).OnComplete(() =>
    //    {
    //        // По достижении цели удаляем врага
    //        Destroy(enemy);
    //    });
    //}
    //public GameObject enemyPrefab; // Префаб врага

    public Transform[] spawnPoints; // Массив точек спавна врагов
    public Transform target; // Цель, к которой будут приближаться враги

    public int wavesCount = 3; // Количество волн
    public int enemiesPerWave = 5; // Количество врагов в одной волне
    public float timeBetweenWaves = 10f; // Время между волнами
    public float spawnInterval = 3f; // Интервал между спавном врагов

    private int currentWave = 0; // Текущая волна
    private int enemiesSpawned = 0; // Количество уже заспавненных врагов в текущей волне

    public GameObject[] wave1Enemies; // Префабы врагов для первой волны
    public GameObject[] wave2Enemies; // Префабы врагов для второй волны
    public GameObject[] wave3Enemies; // Префабы врагов для второй волны

    public UIManager uiManager; // Ссылка на скрипт для управления UI

    void Start()
    {
        // Запускаем спавн первой волны
        SpawnWave();
    }
    private void Update()
    {
        // Проверяем, закончилась ли текущая волна и уничтожены ли все враги
        if (currentWave == wavesCount && enemiesSpawned == enemiesPerWave && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            uiManager.DisplayVictoryMessage();
        }
    }

    void SpawnWave()
    {
        // Увеличиваем номер текущей волны
        currentWave++;

        // Обновляем текст UI, чтобы отобразить текущую волну
        uiManager.UpdateWaveNumber(currentWave, wavesCount);

        // Сбрасываем количество заспавненных врагов в текущей волне
        enemiesSpawned = 0;

        // Спавним врагов поочередно с заданным интервалом
        StartCoroutine(SpawnEnemiesWithInterval());
    }

    IEnumerator SpawnEnemiesWithInterval()
    {
        // Получаем массив префабов для текущей волны
        GameObject[] waveEnemies = null;
        switch (currentWave)
        {
            case 1:
                waveEnemies = wave1Enemies;
                break;
            case 2:
                waveEnemies = wave2Enemies;
                break;
            case 3:
                waveEnemies = wave3Enemies;
                break;
                // Добавьте дополнительные случаи для остальных волн, если нужно
        }

        // Спавним врагов, пока не достигнем нужного количества волн
        while (enemiesSpawned < enemiesPerWave)
        {
            // Выбираем случайную точку спавна из массива
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // Создаем врага на выбранной точке спавна с использованием выбранного префаба
            GameObject enemyPrefab = waveEnemies[enemiesSpawned % waveEnemies.Length];
            GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

            // Плавно приближаем врага к цели (пушке) с использованием DOTween
            enemy.transform.DOMove(target.position, 7f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                // По достижении цели удаляем врага
                Destroy(enemy);
            });

            // Увеличиваем количество заспавненных врагов
            enemiesSpawned++;

            // Ждем заданный интервал перед спавном следующего врага
            yield return new WaitForSeconds(spawnInterval);
        }
        
        // Если это не последняя волна, ждем заданное время и спавним следующую волну
        if (currentWave < wavesCount)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnWave();
        }
        
    }
   
}
