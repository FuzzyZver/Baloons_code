using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class SpawnBoost : MonoBehaviour
{
    public GameObject boostPrefab; // Префаб буста, который будет спавниться
    public GameObject coinPrefab;
    public Transform[] spawnPoints;

    private BoosterManager parametrsPrefab;

    private void OnEnable()
    {
        SpawnObjects();
    }

    private void SpawnObjects()
    {
        foreach(var transform in spawnPoints)
        {
            parametrsPrefab = null;
            float chance = Random.Range(0f, 1f);
            if (chance <= 0.8f)
            {
                GameObject newCoin = Instantiate(coinPrefab,transform);
                parametrsPrefab = newCoin.GetComponent<BoosterManager>();
                parametrsPrefab.isCoin = true;
                parametrsPrefab.countCoins = 50;
            }
            else
            {
                GameObject newBoost = Instantiate(boostPrefab, transform);
                parametrsPrefab = newBoost.GetComponent<BoosterManager>();
                parametrsPrefab.isCoin = false;
                parametrsPrefab.multi = 2;

            }
        }
    }








    //Старый код изначальной задумки


    //public float spawnInterval;
    //private int numbersOfSpawn = 0;
    //public Transform baloon;
    //public void Start()
    //{
    // Вызываем метод SpawnObject каждый spawnInterval секунд
    //StartCoroutine(SpawnRoutine());
    //}

    //IEnumerator SpawnRoutine()
    //{
    //while (numbersOfSpawn < 4)
    //{
    // Ждем spawnInterval секунд перед следующим спавном
    //yield return new WaitForSeconds(spawnInterval);
    //SpawnCrystal();
    //numbersOfSpawn += 1;
    //}

    //}

    //public void SpawnCrystal()
    //{
    //float lineSpawn = Random.Range(-10f, 10f);
    //spawnPoint.position = new Vector3(lineSpawn, baloon.position.y, -1f);
    // Создаем буст в случайной позиции
    //GameObject boost = Instantiate(crystalPrefab, spawnPoint.position, Quaternion.identity);
    //}

}
