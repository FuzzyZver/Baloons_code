using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    [SerializeField] private DataBase dataBase;
    [SerializeField] private Basdepapji basde;

    [SerializeField] private GameObject unlock;

    public int indexLevel = 0;
    public ScinBlueprint[] levels;//тут хранятся данные об индексе объекта, его стоимости и названии

    public void OnEnable()
    {
        levels[0].Object.SetActive(true);
        if (dataBase.levelChek[indexLevel] == true)
        {
            unlock.SetActive(false);
        }
        else if (dataBase.levelChek[indexLevel] == false)
        {
            unlock.SetActive(true);

        }
    }

    public void OnDisable()
    {
        levels[indexLevel].Object.SetActive(false);
    }

    public void LastLevel()
    {
        levels[indexLevel].Object.SetActive(false);
        indexLevel--;
        if (indexLevel < 0)
        {
            indexLevel = levels.Length - 1;
        }
        levels[indexLevel].Object.SetActive(true);

        if (dataBase.levelChek[indexLevel] == true)
        {
            unlock.SetActive(false);
        }
        else if (dataBase.levelChek[indexLevel] == false)
        {
            unlock.SetActive(true);

        }
    }
    public void NextLevel()
    {
        levels[indexLevel].Object.SetActive(false);
        indexLevel++;
        if (indexLevel >= levels.Length)
        {
            indexLevel = 0;
        }
        levels[indexLevel].Object.SetActive(true);

        if (dataBase.levelChek[indexLevel] == true)
        {
            unlock.SetActive(false);
        }
        else if (dataBase.levelChek[indexLevel] == false)
        {
            unlock.SetActive(true);

        }
    }

    public void CheckBuy()
    {
        if (dataBase.coin >= levels[indexLevel].price)
        {
            dataBase.coin -= levels[indexLevel].price;
            unlock.SetActive(false);
            dataBase.levelChek[indexLevel] = true;
        }
    }
}
