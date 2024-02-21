using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 20; // ����, ��������� �����
    public float projectileSpeed = 10f; // �������� �������
    public float projectileLifetime = 3f; // ����� ����� �������
    private Transform player; // ������ �� ������

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // ������� ������ �� ����
        StartCoroutine(DestroyProjectile());
    }

    private void Update()
    {
        // ��������� ����������� � ������
        Vector3 direction = (player.position - transform.position).normalized;

        // ������� ���� � ����������� ������
        transform.Translate(direction * projectileSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyProjectile()
    {
        // ���� ��������� ����� ����� ������������ ����
        yield return new WaitForSeconds(projectileLifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // ���� ���� ����������� � �������, ������� ��� ����
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHP = other.GetComponent<PlayerHP>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(damage);
            }
            Destroy(gameObject); // ���������� ���� ����� ��������� � ������
        }
    }
}
