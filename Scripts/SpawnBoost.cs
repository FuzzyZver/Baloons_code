using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using TMPro;

public class SpawnBoost : MonoBehaviour
{
    public GameObject boostPrefab; // ������ �����, ������� ����� ����������
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








    //������ ��� ����������� �������


    //public float spawnInterval;
    //private int numbersOfSpawn = 0;
    //public Transform baloon;
    //public void Start()
    //{
    // �������� ����� SpawnObject ������ spawnInterval ������
    //StartCoroutine(SpawnRoutine());
    //}

    //IEnumerator SpawnRoutine()
    //{
    //while (numbersOfSpawn < 4)
    //{
    // ���� spawnInterval ������ ����� ��������� �������
    //yield return new WaitForSeconds(spawnInterval);
    //SpawnCrystal();
    //numbersOfSpawn += 1;
    //}

    //}

    //public void SpawnCrystal()
    //{
    //float lineSpawn = Random.Range(-10f, 10f);
    //spawnPoint.position = new Vector3(lineSpawn, baloon.position.y, -1f);
    // ������� ���� � ��������� �������
    //GameObject boost = Instantiate(crystalPrefab, spawnPoint.position, Quaternion.identity);
    //}

}
