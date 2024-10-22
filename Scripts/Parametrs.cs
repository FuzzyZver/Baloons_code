using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Parametrs : MonoBehaviour
{
    [SerializeField] private DataBase data;
    [SerializeField] private SaveManager saveManager;
    public TextMeshProUGUI money;

    void Awake()
    {
        saveManager.LoadGame();
    }
    private void Update()
    {
        if (money != null)
        {
            if (data.languageIndex == 1)
            {
                money.text = $"�����:{data.coin}";
            }
            else if(data.languageIndex == 0)
            {
                money.text = $"Coins:{data.coin}";
            }
            else if(data.languageIndex == 2)
            {
                money.text = $"Monedas:{data.coin}";
            }
        }
    }
    void OnDisable()
    {
        saveManager.SaveGame();
    }
    void OnApplicationQuit()
    {
        saveManager.SaveGame(); // ����� ������ ���������� ������ ����� ������� �� ����������
    }
    public void OnTranning()
    {
        if (data.GuidCheck == false)
        {
            data.GuidCheck = true;
        }
        else
        {
            data.GuidCheck = false;
        }
    }
}
