using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 100; // ������������ ���������� ��������
    private int currentHealth; // ������� ���������� ��������
    public Image healthBar; // ������ �� ������ Image ��� ����� ��������
    public UIManager uiManager; // ������ �� ��� UIManager

    void Start()
    {
        currentHealth = maxHealth; // ������������� ������� �������� � ������������ �������� ��� ������
        UpdateHealthBar(); // ��������� ����� �������� ��� �������������
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // ��������� ������� �������� �� �������� ����������� �����
        if (currentHealth <= 0)
        {
            Die(); // ���� �������� ���������� �� ���� ��� ����, �������� ����� ������
        }
        UpdateHealthBar(); // ��������� ����� �������� ����� ��������� �����
    }

    private void Die()
    {
        uiManager.DisplayDeadMessage(); // ���������� ��������� � ���������
        // ����� ����� �������� �������������� �������� ��� ������ ������
        Debug.Log("Player died!");
        // ��������, ��������� ����� Game Over ��� ������������� ������� �������
    }

    private void UpdateHealthBar()
    {
        // ������������ �������� ����� �������� � ����� �� 0 �� 1
        float healthProgress = (float)currentHealth / maxHealth;
        // ��������� �������� ����� ��������
        healthBar.fillAmount = healthProgress;
    }
}
