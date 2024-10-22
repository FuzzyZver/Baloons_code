using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Language : MonoBehaviour
{
    public Image canvasRenderer;
    public Sprite[] image;
    [SerializeField] private DataBase dataBase;

    void Update()
    {
        canvasRenderer.sprite = image[dataBase.languageIndex];
    }

    public void ChangeLanguage()
    {
        dataBase.languageIndex ++;
        if (dataBase.languageIndex > 2)
        {
            dataBase.languageIndex = 0;
        }
    }
}
