using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public float fireRate = 1f; // Частота стрельбы (выстрелов в секунду)
    public float offsetDistance = 5f; // Расстояние, на которое снаряд должен вылететь впереди противника

    private Transform player; // Ссылка на игрока
    private float nextFireTime; // Время следующего выстрела

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока по тегу
        nextFireTime = Time.time; // Устанавливаем начальное время для первого выстрела
    }

    private void Update()
    {
        if (Time.time >= nextFireTime)
        {
            Shoot(); // Выстрел
            nextFireTime = Time.time + 1f / fireRate; // Обновляем время следующего выстрела
        }
    }

    private void Shoot()
    {
        // Вычисляем направление к игроку
        Vector3 direction = (player.position - transform.position).normalized;

        // Вычисляем позицию, куда надо стрелять с учетом смещения впереди противника
        Vector3 leadPosition = transform.position + direction * offsetDistance;

        // Создаем снаряд в этой позиции
        GameObject projectile = Instantiate(projectilePrefab, leadPosition, Quaternion.identity);
    }
}
