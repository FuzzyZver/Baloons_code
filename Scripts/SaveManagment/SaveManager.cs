using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
class SaveData
{
    // Переменные для сохранения данных
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

    // Метод для сохранения игровых данных
    public void SaveGame()
    {
        // Создаем объект BinaryFormatter для сериализации данных
        BinaryFormatter bf = new BinaryFormatter();

        // Создаем файл для записи данных
        FileStream file = new FileStream(filePath, FileMode.Create);

        SaveData data = new SaveData();
        data.coin = dataBase.coin;
        data.buyCheck = dataBase.buyChek;
        data.levelCheck = dataBase.levelChek;
        data.soundCheck = dataBase.soundCheck;
        data.muzikCheck = dataBase.muzikCheck;
        data.GuidCheck = dataBase.GuidCheck;
        data.languageIndex = dataBase.languageIndex;

        // Сериализуем объект SaveData и записываем его в файл
        bf.Serialize(file, data);

        // Закрываем файл и выводим сообщение о сохранении данных
        file.Close();
        Debug.Log("Game data saved!");
    }

    // Метод для загрузки игровых данных
    public void LoadGame()
    {
        // Проверяем, существует ли файл с данными
        if (File.Exists(filePath))
        {
            // Создаем объект BinaryFormatter для десериализации данных
            BinaryFormatter bf = new BinaryFormatter();

            // Открываем файл с данными для чтения
            FileStream file = new FileStream(filePath, FileMode.Open);

            // Десериализуем данные из файла и преобразуем их в объект SaveData
            SaveData data = (SaveData)bf.Deserialize(file);
            dataBase.coin = data.coin;
            dataBase.buyChek = data.buyCheck;
            dataBase.levelChek = data.levelCheck;
            dataBase.soundCheck = data.soundCheck;
            dataBase.muzikCheck = data.muzikCheck;
            dataBase.GuidCheck = data.GuidCheck;
            dataBase.languageIndex = data.languageIndex;

            // Закрываем файл и копируем загруженные данные обратно в переменные
            file.Close();

            // Выводим сообщение о загрузке данных
            Debug.Log("Game data loaded!");
        }
        else
        {
            // Если файл с данными не существует, выводим сообщение об ошибке
            Debug.LogError("There is no save data!");
        }
    }
}
