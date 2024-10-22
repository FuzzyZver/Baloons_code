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

    [SerializeField] private TextMeshProUGUI score; //переменная в которую запихнули счётчик на игровом поле
    [SerializeField] private DataBase dataBase;
    [SerializeField] private Basdepapji hitCounter;//тут я беру переменную кол-ва ударов из скриптпл обэекта с базовыми параметрами

    // Скорость, с которой шарик будет лететь
    private float flyingSpeed = 12f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        hitCounter.coins = 0;
        hitCounter.plusCount = 1;
    }
    void OnMouseDown()
    {
        //Старый участок кода
        //isDragging = true;
        //pointScreen = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        //offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z));

        // Создаем луч от камеры до позиции курсора
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // Определяем плоскость Z=0
        Plane plane = new Plane(Vector3.forward, Vector3.zero);

        float enter;
        if (plane.Raycast(ray, out enter))
        {
            // Получаем точку пересечения луча с плоскостью Z=0
            Vector3 hitPoint = ray.GetPoint(enter);

            // Определяем направление от курсора к шарику
            Vector3 direction = transform.position - hitPoint;

            // Обнуляем компоненту z вектора направления, чтобы он не влиял на движение по этой оси
            direction.z = 0;

            // Применяем силу к объекту в полученном направлении
            GetComponent<Rigidbody>().AddForce(direction.normalized * flyingSpeed, ForceMode.Impulse);
        }

            // Проверяем, чтобы значение не стало меньше 0
        if (rb.drag > 0.1f) 
        {
            // Уменьшаем значение Drag на указанное количество
            rb.drag -= decAmount;
        }

        //Старая версия
        //hitCounter.hitBall += hitCounter.plusCount;


    }
    //Старый код

    //void OnMouseDrag()
    //{
    //if (isDragging == true)
    //{
    //StartCoroutine("ControlCoroutine");
    //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
    //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //curPosition.z = transform.position.z; // Устанавливаем Z-координату равной начальной Z-координате объекта
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
            // Обновляем текст в компоненте TextMeshPro с помощью значения переменной из скриптаблобжекта
            score.text = $"Получено: {hitCounter.coins.ToString()}";
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
    //Старый код

    //void OnMouseDrag()
    //{
    //if (isDragging == true)
    //{
    //StartCoroutine("ControlCoroutine");
    //Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, pointScreen.z);
    //Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint);
    //curPosition.z = transform.position.z; // Устанавливаем Z-координату равной начальной Z-координате объекта
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
