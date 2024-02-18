using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab; // ������ �������
    public Transform firePoint; // �����, ������ ����� ������� ������
    public float fireRate = 1f; // ������� �������� (��������� � �������)

    private bool canFire = true; // ����, ������������, ����� �� ����� �������� � ������ ������

    void Update()
    {
        // ���������, ������ �� ������ ���� � ����� �� ����� �������� � ������ ������
        if (Input.GetMouseButton(0) && canFire)
        {
            // ��������
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        // ��������� ����������� ��������, ����� �������� ������������� ��������� �� ���� �������
        canFire = false;

        // ������� ������
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // ���� �����, ������ ������� ��������, ����� ��� ��� ����� ��������� ��������
        yield return new WaitForSeconds(1f / fireRate);

        // �������� ����������� ��������
        canFire = true;
    }
}
