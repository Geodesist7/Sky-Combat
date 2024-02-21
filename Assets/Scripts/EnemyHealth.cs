using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // ������������ ���������� �������� �����
    private int currentHealth; // ������� ���������� �������� �����
    [SerializeField] private Image healthBarImage; // ������ �� ��������� Image ����� ��������

    void Start()
    {
        currentHealth = maxHealth; // ������������� ��������� ���������� ��������
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ��������� ������� ���������� �������� �� �������� �����

        // ���� �������� ����� ������ ��� ����� ����, ���������� ���
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
        else // ��������� ����� �������� ������ ���� ���� ��� ���
        {
            UpdateHealthBar();
        }
    }

    // ����� ��� ���������� ���������� ����� �������� �� ������ �������� �������� �����
    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            // ���������, ����� �������� �� ����� �������������
            currentHealth = Mathf.Max(currentHealth, 0);

            // ��������� fillAmount � Image � ������������ � ������� ���������
            healthBarImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
 