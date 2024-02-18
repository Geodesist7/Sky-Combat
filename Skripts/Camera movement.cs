using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    void Update()
    {
        // ���������, ������������ �� ������ ����
        if (Input.GetMouseButton(0))
        {
            // �������� ����������� �������� ���� �� ����������� � ���������
            float horizontalMovement = Input.GetAxis("Mouse X");
            float verticalMovement = Input.GetAxis("Mouse Y");

            // ���������� �������� �������� � ����������� �� �������� ����
            Vector3 rotation = new Vector3(-verticalMovement, horizontalMovement, 0f);

            // ��������� ������� � �����
            transform.Rotate(rotation);
        }
    }
}
