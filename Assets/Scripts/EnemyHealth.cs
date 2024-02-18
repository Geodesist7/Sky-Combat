using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // ћаксимальное количество здоровь€ врага
    private int currentHealth; // “екущее количество здоровь€ врага

    void Start()
    {
        currentHealth = maxHealth; // ”станавливаем начальное количество здоровь€
    }

    public void TakeDamage(int damage)
    {
        
        currentHealth -= damage; // ”меньшаем текущее количество здоровь€ на значение урона

        // ≈сли здоровье врага меньше или равно нулю, уничтожаем его
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
