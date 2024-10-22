using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    // �������� �������� �������
    public float rotationSpeed = 50f;

    private void OnMouseDown()
    {
        // ������� ������ � �������� ������� ��� ������� ����
        RotateObject();
    }

    // ������� ��� �������� ������� � �������� �������
    void RotateObject()
    {
        // �������� ������� ���� �������� �������
        float currentRotation = transform.eulerAngles.z;

        // ��������� ����� ���� �������� (��������������� ��������)
        float newRotation = currentRotation + 180f;

        // ��������� ������� �������� � ������ ����
        Quaternion targetRotation = Quaternion.Euler(newRotation, newRotation, newRotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
