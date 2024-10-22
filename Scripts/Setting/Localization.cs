using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Localization : MonoBehaviour
{
    //Индексы языков
    //Англайский = 0
    //Русский = 1
    //Испанский = 2

    [SerializeField] private DataBase dataBase;
    public string[] locals;
    private TextMeshProUGUI textOnScreen;

    void Update()
    {
        textOnScreen = GetComponent<TextMeshProUGUI>();
        textOnScreen.text = $"{locals[dataBase.languageIndex]}";
    }

}
