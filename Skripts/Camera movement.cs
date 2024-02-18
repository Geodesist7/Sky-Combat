using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cameramovement : MonoBehaviour
{
    void Update()
    {
        // ѕровер€ем, удерживаетс€ ли кнопка мыши
        if (Input.GetMouseButton(0))
        {
            // ѕолучаем направление движени€ мыши по горизонтали и вертикали
            float horizontalMovement = Input.GetAxis("Mouse X");
            float verticalMovement = Input.GetAxis("Mouse Y");

            // ќпредел€ем величину поворота в зависимости от движени€ мыши
            Vector3 rotation = new Vector3(-verticalMovement, horizontalMovement, 0f);

            // ѕримен€ем поворот к пушке
            transform.Rotate(rotation);
        }
    }
}
