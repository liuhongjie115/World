using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float rotateSpeed = 2;
    public float moveSpeed = 2;

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            Rotate();
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Move();
    }

    private void Rotate()
    {
        float y = Input.GetAxis("Mouse X");
        float x = Input.GetAxis("Mouse Y");
        Vector3 euler = Camera.main.transform.eulerAngles;
        euler.x -= x* rotateSpeed;
        euler.y += y* rotateSpeed;
        Camera.main.transform.eulerAngles = euler;
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        transform.position += x * transform.right*moveSpeed;
        transform.position += y * transform.forward*moveSpeed;

        if(Input.GetKey(KeyCode.Q))
        {
            transform.position += new Vector3(0,1,0) * moveSpeed;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.position += new Vector3(0, -1, 0) * moveSpeed;
        }
    }
}
