using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 100; // ћаксимальное количество здоровь€ врага
    private int currentHealth; // “екущее количество здоровь€ врага
    [SerializeField] private Image healthBarImage; // —сылка на компонент Image шкалы здоровь€

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
        else // ќбновл€ем шкалу здоровь€ только если враг еще жив
        {
            UpdateHealthBar();
        }
    }

    // ћетод дл€ обновлени€ заполнени€ шкалы здоровь€ на основе текущего здоровь€ врага
    private void UpdateHealthBar()
    {
        if (healthBarImage != null)
        {
            // ѕровер€ем, чтобы здоровье не стало отрицательным
            currentHealth = Mathf.Max(currentHealth, 0);

            // ќбновл€ем fillAmount у Image в соответствии с текущим здоровьем
            healthBarImage.fillAmount = (float)currentHealth / maxHealth;
        }
    }
}
 