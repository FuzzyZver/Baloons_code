using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class SaveData
{
    // ���������� ��� ���������� ������
    public int coin;
    public bool[] buyCheck;
    public bool[] levelCheck;
    public bool soundCheck;
    public bool muzikCheck;
    public bool GuidCheck;
    public int languageIndex;
}

public class SaveManager : MonoBehaviour
{

    [SerializeField] private DataBase dataBase;
    private string filePath;

    void Awake()
    {
        filePath =  Application.persistentDataPath + "/MySaveData.dat";
    }

    // ����� ��� ���������� ������� ������
    public void SaveGame()
    {
        // ������� ������ BinaryFormatter ��� ������������ ������
        BinaryFormatter bf = new BinaryFormatter();

        // ������� ���� ��� ������ ������
        FileStream file = new FileStream(filePath, FileMode.Create);

        SaveData data = new SaveData();
        data.coin = dataBase.coin;
        data.buyCheck = dataBase.buyChek;
        data.levelCheck = dataBase.levelChek;
        data.soundCheck = dataBase.soundCheck;
        data.muzikCheck = dataBase.muzikCheck;
        data.GuidCheck = dataBase.GuidCheck;
        data.languageIndex = dataBase.languageIndex;

        // ����������� ������ SaveData � ���������� ��� � ����
        bf.Serialize(file, data);

        // ��������� ���� � ������� ��������� � ���������� ������
        file.Close();
        Debug.Log("Game data saved!");
    }

    // ����� ��� �������� ������� ������
    public void LoadGame()
    {
        // ���������, ���������� �� ���� � �������
        if (File.Exists(filePath))
        {
            // ������� ������ BinaryFormatter ��� �������������� ������
            BinaryFormatter bf = new BinaryFormatter();

            // ��������� ���� � ������� ��� ������
            FileStream file = new FileStream(filePath, FileMode.Open);

            // ������������� ������ �� ����� � ����������� �� � ������ SaveData
            SaveData data = (SaveData)bf.Deserialize(file);
            dataBase.coin = data.coin;
            dataBase.buyChek = data.buyCheck;
            dataBase.levelChek = data.levelCheck;
            dataBase.soundCheck = data.soundCheck;
            dataBase.muzikCheck = data.muzikCheck;
            dataBase.GuidCheck = data.GuidCheck;
            dataBase.languageIndex = data.languageIndex;

            // ��������� ���� � �������� ����������� ������ ������� � ����������
            file.Close();

            // ������� ��������� � �������� ������
            Debug.Log("Game data loaded!");
        }
        else
        {
            // ���� ���� � ������� �� ����������, ������� ��������� �� ������
            Debug.LogError("There is no save data!");
        }
    }
}
