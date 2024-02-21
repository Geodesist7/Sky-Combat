using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectilePrefab; // ������ �������
    public float fireRate = 1f; // ������� �������� (��������� � �������)
    public float offsetDistance = 5f; // ����������, �� ������� ������ ������ �������� ������� ����������

    private Transform player; // ������ �� ������
    private float nextFireTime; // ����� ���������� ��������

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������ �� ����
        nextFireTime = Time.time; // ������������� ��������� ����� ��� ������� ��������
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot(); // �������
            nextFireTime = Time.time + 1f / fireRate; // ��������� ����� ���������� ��������
        }
    }

    private void Shoot()
    {
        // ��������� ����������� � ������
        Vector3 direction = (player.position - transform.position).normalized;

        // ��������� �������, ���� ���� �������� � ������ �������� ������� ����������
        Vector3 leadPosition = transform.position + direction * offsetDistance;

        // ������� ������ � ���� �������
        GameObject projectile = Instantiate(projectilePrefab, leadPosition, Quaternion.identity);
    }
}
