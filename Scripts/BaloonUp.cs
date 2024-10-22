using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BaloonUp : MonoBehaviour
{
    private Vector3 pointScreen;
    private Vector3 offset;

    private Rigidbody rb;
    private float decAmount = 0.01f;

    //private bool isDragging = true;

    [SerializeField] private TextMeshProUGUI score; //���������� � ������� ��������� ������� �� ������� ����
    [SerializeField] private DataBase dataBase;
    [SerializeField] private Basdepapji hitCounter;//��� � ���� ���������� ���-�� ������ �� �������� ������� � �������� �����������

    // ��������, � ������� ����� ����� ������
    private float flyingSpeed = 12f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitCounter.coins = 0;
        hitCounter.plusCount = 1;
    }
    void OnMouseDown()
    {
        //������ ������� ����
        //isDragging = true;
        //pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z));

        // ������� ��� �� ������ �� ������� �������
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // ���������� ��������� Z=0
        Plane plane = new Plane(Vector3.forward, Vector3.zero);

        float enter;
        if (plane.Raycast(ray, out enter))
        {
            // �������� ����� ����������� ���� � ���������� Z=0
            Vector3 hitPoint = ray.GetPoint(enter);

            // ���������� ����������� �� ������� � ������
            Vector3 direction = transform.position - hitPoint;

            // �������� ���������� z ������� �����������, ����� �� �� ����� �� �������� �� ���� ���
            direction.z = 0;

            // ��������� ���� � ������� � ���������� �����������
            GetComponent<Rigidbody>().AddForce(direction.normalized * flyingSpeed, ForceMode.Impulse);
        }

            // ���������, ����� �������� �� ����� ������ 0
        if (rb.drag > 0.1f) 
        {
            // ��������� �������� Drag �� ��������� ����������
            rb.drag -= decAmount;
        }

        //������ ������
        //hitCounter.hitBall += hitCounter.plusCount;


    }
    //������ ���

    //void OnMouseDrag()
    //{
    //if (isDragging == true)
    //{
    //StartCoroutine("ControlCoroutine");
    //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
    //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //curPosition.z = transform.position.z; // ������������� Z-���������� ������ ��������� Z-���������� �������
    //transform.position = curPosition;
    //}
    //else
    //{
    //return;
    //}

    //}

    void Update()
    {
        if (dataBase.languageIndex==1)
        {
            // ��������� ����� � ���������� TextMeshPro � ������� �������� ���������� �� ����������������
            score.text = $"��������: {hitCounter.coins.ToString()}";
        }
        else if(dataBase.languageIndex == 0)
        {
            score.text = $"Received: {hitCounter.coins.ToString()}";
        }
        else if(dataBase.languageIndex == 2)
        {
            score.text = $"Recibido: {hitCounter.coins.ToString()}";
        }
    }
    //������ ���

    //void OnMouseDrag()
    //{
    //if (isDragging == true)
    //{
    //StartCoroutine("ControlCoroutine");
    //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
    //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //curPosition.z = transform.position.z; // ������������� Z-���������� ������ ��������� Z-���������� �������
    //transform.position = curPosition;
    //}
    //else
    //{
    //return;
    //}

    //}

    //IEnumerator ControlCoroutine()
    //{
    //yield return new WaitForSeconds(1f);
    //isDragging = false;

    //}
}
