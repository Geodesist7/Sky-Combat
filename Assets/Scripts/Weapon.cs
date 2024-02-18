using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab; // Префаб снаряда
    public Transform firePoint; // Точка, откуда будет выпущен снаряд
    public float fireRate = 1f; // Частота стрельбы (выстрелов в секунду)

    private bool canFire = true; // Флаг, определяющий, может ли пушка стрелять в данный момент

    void Update()
    {
        // Проверяем, нажата ли кнопка мыши и может ли пушка стрелять в данный момент
        if (Input.GetMouseButton(0) && canFire)
        {
            // Стреляем
            StartCoroutine(Fire());
        }
    }

    IEnumerator Fire()
    {
        // Отключаем возможность стрельбы, чтобы избежать множественных выстрелов за одно нажатие
        canFire = false;

        // Создаем снаряд
        Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);

        // Ждем время, равное частоте стрельбы, перед тем как снова разрешить стрельбу
        yield return new WaitForSeconds(1f / fireRate);

        // Включаем возможность стрельбы
        canFire = true;
    }
}
