using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Скорость полета снаряда
    public int damage = 20; // Урон, наносимый пулей
    public float maxFlightTime = 3f; // Максимальное время полёта пули
    private float flightTimer = 0f; // Таймер полёта пули

    void Update()
    {
        // Обновляем таймер полёта пули
        flightTimer += Time.deltaTime;

        // Если время полёта превысило максимальное, уничтожаем пулю
        if (flightTimer >= maxFlightTime)
        {
            Destroy(gameObject);
        }

        // Двигаем снаряд вперед по направлению оси Z
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        // Получаем ссылку на компонент EnemyHealth в объекте, с которым столкнулась пуля
        EnemyHealth enemy = other.GetComponent<EnemyHealth>();

        // Проверяем, если объект, с которым столкнулась пуля, имеет компонент EnemyHealth,
        // что означает, что это враг
        if (enemy != null)
        {
            // Если это враг, наносим ему урон
            enemy.TakeDamage(damage);
            // И уничтожаем пулю
            Destroy(gameObject);
        }
    }
}
