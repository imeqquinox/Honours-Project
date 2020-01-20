using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    private float speed_hor = 2.0f;
    private float speed_vert = 2.0f;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked; 
    }

    private void Update()
    {
        yaw += speed_hor * Input.GetAxis("Mouse X");
        pitch -= speed_vert * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f); 
    }
}
