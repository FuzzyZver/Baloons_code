using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Localization : MonoBehaviour
{
    //������� ������
    //���������� = 0
    //������� = 1
    //��������� = 2

    [SerializeField] private DataBase dataBase;
    public string[] locals;
    private TextMeshProUGUI textOnScreen;

    void Update()
    {
        textOnScreen = GetComponent<TextMeshProUGUI>();
        textOnScreen.text = $"{locals[dataBase.languageIndex]}";
    }

}
