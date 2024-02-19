using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnEnemy : MonoBehaviour
{
    //public GameObject enemyPrefab; // ������ �����
    //public Transform[] spawnPoints; // ������ ����� ������ ������
    //public float spawnInterval = 3f; // �������� ����� ������� ������
    //public Transform target; // ����, � ������� ����� ������������ �����

    //void Start()
    //{
    //    // ��������� ������� ������ ������ � �������� ����������
    //    InvokeRepeating("EnemySpawner", 0f, spawnInterval);
    //}

    //void EnemySpawner()
    //{
    //    // �������� ��������� ����� ������ �� �������
    //    Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

    //    // ������� ����� �� ��������� ����� ������
    //    GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

    //    // ������ ���������� ����� � ���� (�����) � �������������� DOTween
    //    enemy.transform.DOMove(target.position, 7f).SetEase(Ease.InOutQuad).OnComplete(() =>
    //    {
    //        // �� ���������� ���� ������� �����
    //        Destroy(enemy);
    //    });
    //}
    //public GameObject enemyPrefab; // ������ �����

    public Transform[] spawnPoints; // ������ ����� ������ ������
    public Transform target; // ����, � ������� ����� ������������ �����

    public int wavesCount = 3; // ���������� ����
    public int enemiesPerWave = 5; // ���������� ������ � ����� �����
    public float timeBetweenWaves = 10f; // ����� ����� �������
    public float spawnInterval = 3f; // �������� ����� ������� ������

    private int currentWave = 0; // ������� �����
    private int enemiesSpawned = 0; // ���������� ��� ������������ ������ � ������� �����

    public GameObject[] wave1Enemies; // ������� ������ ��� ������ �����
    public GameObject[] wave2Enemies; // ������� ������ ��� ������ �����
    public GameObject[] wave3Enemies; // ������� ������ ��� ������ �����

    public UIManager uiManager; // ������ �� ������ ��� ���������� UI

    void Start()
    {
        // ��������� ����� ������ �����
        SpawnWave();
    }
    private void Update()
    {
        // ���������, ����������� �� ������� ����� � ���������� �� ��� �����
        if (currentWave == wavesCount && enemiesSpawned == enemiesPerWave && GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
        {
            uiManager.DisplayVictoryMessage();
        }
    }

    void SpawnWave()
    {
        // ����������� ����� ������� �����
        currentWave++;

        // ��������� ����� UI, ����� ���������� ������� �����
        uiManager.UpdateWaveNumber(currentWave, wavesCount);

        // ���������� ���������� ������������ ������ � ������� �����
        enemiesSpawned = 0;

        // ������� ������ ���������� � �������� ����������
        StartCoroutine(SpawnEnemiesWithInterval());
    }

    IEnumerator SpawnEnemiesWithInterval()
    {
        // �������� ������ �������� ��� ������� �����
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
                // �������� �������������� ������ ��� ��������� ����, ���� �����
        }

        // ������� ������, ���� �� ��������� ������� ���������� ����
        while (enemiesSpawned < enemiesPerWave)
        {
            // �������� ��������� ����� ������ �� �������
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            // ������� ����� �� ��������� ����� ������ � �������������� ���������� �������
            GameObject enemyPrefab = waveEnemies[enemiesSpawned % waveEnemies.Length];
            GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

            // ������ ���������� ����� � ���� (�����) � �������������� DOTween
            enemy.transform.DOMove(target.position, 7f).SetEase(Ease.InOutQuad).OnComplete(() =>
            {
                // �� ���������� ���� ������� �����
                Destroy(enemy);
            });

            // ����������� ���������� ������������ ������
            enemiesSpawned++;

            // ���� �������� �������� ����� ������� ���������� �����
            yield return new WaitForSeconds(spawnInterval);
        }
        
        // ���� ��� �� ��������� �����, ���� �������� ����� � ������� ��������� �����
        if (currentWave < wavesCount)
        {
            yield return new WaitForSeconds(timeBetweenWaves);
            SpawnWave();
        }
        
    }
   
}
