using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // Префаб врага
    public Transform[] spawnPoints; // Массив точек спавна врагов
    public float spawnInterval = 3f; // Интервал между спавном врагов
    public Transform target; // Цель, к которой будут приближаться враги

    void Start()
    {
        // Запускаем процесс спавна врагов с заданным интервалом
        InvokeRepeating("EnemySpawner", 0f, spawnInterval);
    }

    void EnemySpawner()
    {
        // Выбираем случайную точку спавна из массива
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // Создаем врага на выбранной точке спавна
        GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

        // Плавно приближаем врага к цели (пушке) с использованием DOTween
        enemy.transform.DOMove(target.position, 7f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            // По достижении цели удаляем врага
            Destroy(enemy);
        });
    }
}
