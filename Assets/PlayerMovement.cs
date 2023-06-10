using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private bool isMoving = false;
    private Vector3 targetPosition;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // ѕолучаем текущие координаты мыши
            Vector3 mousePosition = Input.mousePosition;
            // ѕреобразуем координаты мыши в мировые координаты
            targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            targetPosition.z = transform.position.z; // ”станавливаем z-координату игрока

            isMoving = true;
        }

        if (isMoving)
        {
            // ¬ычисл€ем вектор направлени€ к целевой позиции
            Vector3 moveDirection = targetPosition - transform.position;
            // ѕровер€ем, достигли ли мы целевой позиции
            if (moveDirection.magnitude <= 0.1f)
            {
                isMoving = false;
            }
            else
            {
                // Ќормализуем вектор направлени€
                moveDirection.Normalize();
                // ѕередвигаем игрока
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
        }
    }
}
