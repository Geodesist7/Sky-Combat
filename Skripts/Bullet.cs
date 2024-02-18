using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f; // �������� ������ �������

    void Update()
    {
        // ������� ������ ������ �� ����������� ��� X
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
