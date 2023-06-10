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
            // �������� ������� ���������� ����
            Vector3 mousePosition = Input.mousePosition;
            // ����������� ���������� ���� � ������� ����������
            targetPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            targetPosition.z = transform.position.z; // ������������� z-���������� ������

            isMoving = true;
        }

        if (isMoving)
        {
            // ��������� ������ ����������� � ������� �������
            Vector3 moveDirection = targetPosition - transform.position;
            // ���������, �������� �� �� ������� �������
            if (moveDirection.magnitude <= 0.1f)
            {
                isMoving = false;
            }
            else
            {
                // ����������� ������ �����������
                moveDirection.Normalize();
                // ����������� ������
                transform.position += moveDirection * moveSpeed * Time.deltaTime;
            }
        }
    }
}
