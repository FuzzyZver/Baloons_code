using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private GameOVer gameOVer;


    public float smooth = 5.0f;
    
    void Update()
    {
        if (target != null)
        {
            Vector3 targetPosition = target.position; // ��������� ������� target �� ��������� ����������
            targetPosition.z -= 35f; // �������� 20 �� ���������� z
                                     //targetPosition.y += 10f;
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * smooth);
        }
    }

} 

