using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHP : MonoBehaviour
{
    public int maxHealth = 100; // Максимальное количество здоровья
    private int currentHealth; // Текущее количество здоровья
    public Image healthBar; // Ссылка на объект Image для шкалы здоровья
    public UIManager uiManager; // Ссылка на ваш UIManager

    void Start()
    {
        currentHealth = maxHealth; // Устанавливаем текущее здоровье в максимальное значение при старте
        UpdateHealthBar(); // Обновляем шкалу здоровья при инициализации
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // Уменьшаем текущее здоровье на величину полученного урона
        if (currentHealth <= 0)
        {
            Die(); // Если здоровье опускается до нуля или ниже, вызываем метод смерти
        }
        UpdateHealthBar(); // Обновляем шкалу здоровья после получения урона
    }

    private void Die()
    {
        uiManager.DisplayDeadMessage(); // Показываем сообщение о проигрыше
        // Здесь можно добавить дополнительные действия при смерти игрока
        Debug.Log("Player died!");
        // Например, загрузить сцену Game Over или перезапустить текущий уровень
    }

    private void UpdateHealthBar()
    {
        // Рассчитываем прогресс шкалы здоровья в долях от 0 до 1
        float healthProgress = (float)currentHealth / maxHealth;
        // Обновляем значение шкалы здоровья
        healthBar.fillAmount = healthProgress;
    }
}
