using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour
{
    // Скорость вращения объекта
    public float rotationSpeed = 50f;

    private void OnMouseDown()
    {
        // Вращаем объект в обратную сторону при нажатии мыши
        RotateObject();
    }

    // Функция для вращения объекта в обратную сторону
    void RotateObject()
    {
        // Получаем текущий угол вращения объекта
        float currentRotation = transform.eulerAngles.z;

        // Вычисляем новый угол вращения (противоположный текущему)
        float newRotation = currentRotation + 180f;

        // Применяем плавное вращение к новому углу
        Quaternion targetRotation = Quaternion.Euler(newRotation, newRotation, newRotation);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
