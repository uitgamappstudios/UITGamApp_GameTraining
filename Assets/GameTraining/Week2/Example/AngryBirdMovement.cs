using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryBirdMovement : MonoBehaviour
{

    [Header("Movement Settings")]
    [Tooltip("Tốc độ di chuyển của nhân vật")]
    [Range(1f, 10f)]
    [SerializeField] private float moveSpeed = 5f;
    [Tooltip("Tốc độ lăn của nhân vật")]
    [Range(40f, 400f)]
    [SerializeField] private float rotationSpeed = 200f;

    // Hàm update sẽ được gọi liên tục khi game chạy
    private void Update()
    {
        Move();
    }

    void Move()
    {
        // Nhận input từ bàn phím (A/D hoặc phím mũi tên)
        float moveInput = Input.GetAxis("Horizontal");

        if (moveInput != 0)
        {
            // Di chuyển trái/phải (thay đổi vị trí theo trục X)
            transform.position += Vector3.right * moveInput * moveSpeed * Time.deltaTime;

            // Lăn Angry Bird theo hướng di chuyển
            transform.Rotate(Vector3.forward, -moveInput * rotationSpeed * Time.deltaTime);
        }
    }
}
