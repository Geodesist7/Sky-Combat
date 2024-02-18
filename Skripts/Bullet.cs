using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // Скорость полета снаряда

    void Update()
    {
        // Двигаем снаряд вперед по направлению оси X
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
