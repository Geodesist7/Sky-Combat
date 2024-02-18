using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // �������� ������ �������
    public int damage = 20; // ����, ��������� �����
    public float maxFlightTime = 3f; // ������������ ����� ����� ����
    private float flightTimer = 0f; // ������ ����� ����

    void Update()
    {
        // ��������� ������ ����� ����
        flightTimer += Time.deltaTime;

        // ���� ����� ����� ��������� ������������, ���������� ����
        if (flightTimer >= maxFlightTime)
        {
            Destroy(gameObject);
        }

        // ������� ������ ������ �� ����������� ��� Z
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // �������� ������ �� ��������� EnemyHealth � �������, � ������� ����������� ����
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        // ���������, ���� ������, � ������� ����������� ����, ����� ��������� EnemyHealth,
        // ��� ��������, ��� ��� ����
        if (enemy != null)
        {
            // ���� ��� ����, ������� ��� ����
            enemy.TakeDamage(damage);
            // � ���������� ����
            Destroy(gameObject);
        }
    }
}
