using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab; // ������ �����
    public Transform[] spawnPoints; // ������ ����� ������ ������
    public float spawnInterval = 3f; // �������� ����� ������� ������
    public Transform target; // ����, � ������� ����� ������������ �����

    void Start()
    {
        // ��������� ������� ������ ������ � �������� ����������
        InvokeRepeating("EnemySpawner", 0f, spawnInterval);
    }

    void EnemySpawner()
    {
        // �������� ��������� ����� ������ �� �������
        Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // ������� ����� �� ��������� ����� ������
        GameObject enemy = Instantiate(enemyPrefab, randomSpawnPoint.position, randomSpawnPoint.rotation);

        // ������ ���������� ����� � ���� (�����) � �������������� DOTween
        enemy.transform.DOMove(target.position, 7f).SetEase(Ease.InOutQuad).OnComplete(() =>
        {
            // �� ���������� ���� ������� �����
            Destroy(enemy);
        });
    }
}
