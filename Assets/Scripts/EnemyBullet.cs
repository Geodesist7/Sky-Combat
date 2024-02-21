using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int damage = 20; // Урон, наносимый пулей
    public float projectileSpeed = 10f; // Скорость снаряда
    public float projectileLifetime = 3f; // Время жизни снаряда
    private Transform player; // Ссылка на игрока

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Находим игрока по тегу
        StartCoroutine(DestroyProjectile());
    }

    private void Update()
    {
        // Вычисляем направление к игроку
        Vector3 direction = (player.position - transform.position).normalized;

        // Двигаем пулю в направлении игрока
        transform.Translate(direction * projectileSpeed * Time.deltaTime);
    }

    private IEnumerator DestroyProjectile()
    {
        // Ждем указанное время перед уничтожением пули
        yield return new WaitForSeconds(projectileLifetime);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Если пуля столкнулась с игроком, наносим ему урон
        if (other.CompareTag("Player"))
        {
            PlayerHP playerHP = other.GetComponent<PlayerHP>();
            if (playerHP != null)
            {
                playerHP.TakeDamage(damage);
            }
            Destroy(gameObject); // Уничтожаем пулю после попадания в игрока
        }
    }
}
