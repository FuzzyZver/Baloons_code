using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class Store : MonoBehaviour
{
    [SerializeField] private DataBase data; //Подключение скриптаблобжекта "базы данных"
    [SerializeField] private Basdepapji basde; // Подключение скриптаблобжекта "игровых данных"
    public GameObject select;
    public GameObject unlock;

    public TextMeshProUGUI priceText;
    public GameObject priceBaloon;
    //Цены на каждый скин
    //public int balloonPinkSkin = 500;
    //public int balloonBlueSkin = 2000;
    //public int sovietBallSkin = 8000;
    //public int footBallSkin = 20000;
    //public int tennisBallSkin = 160000;

    //выведение цены
    public int indexSkin = 0;
    public ScinBlueprint[] scins;//тут хранятся данные об индексе объекта, его стоимости и названии

    public void OnEnable()
    {
        StartCoroutine("On");
        if (data.buyChek[indexSkin] == true)
        {
            unlock.SetActive(false);
            select.SetActive(true);
        }
        else if (data.buyChek[indexSkin] == false)
        {
            unlock.SetActive(true);
            select.SetActive(false);
            priceBaloon.SetActive(false);

        }
    }
    IEnumerator On()
    {
        yield return new WaitForSeconds(0.5f);
        scins[0].Object.SetActive(true);
    }

    public void OnDisable()
    {
        scins[indexSkin].Object.SetActive(false);
        indexSkin = 0;
        priceBaloon.SetActive(false);
    }

    public void LastSkin()
    {
        scins[indexSkin].Object.SetActive(false);
        indexSkin--;
        if (indexSkin < 0)
        {
            indexSkin = scins.Length - 1;
        }
        scins[indexSkin].Object.SetActive(true);

        if (data.buyChek[indexSkin] == true)
        {
            unlock.SetActive(false);
            select.SetActive(true);
            priceBaloon.SetActive(false);
        }
        else if(data.buyChek[indexSkin] == false)
        {
            unlock.SetActive(true);
            select.SetActive(false);
            priceBaloon.SetActive(true);
            if (data.languageIndex == 1)
            {
                priceText.text = $"Стоит монет:{scins[indexSkin].price}";
            }
            else if(data.languageIndex == 0)
            {
                priceText.text = $"Cost:{scins[indexSkin].price}";
            }
            else if(data.languageIndex == 2)
            {
                priceText.text = $"Coste:{scins[indexSkin].price}";
            }

        }
    }
    public void NextSkin()
    {
        scins[indexSkin].Object.SetActive(false);
        indexSkin++;
        if (indexSkin >= scins.Length)
        {
            indexSkin = 0;
        }
        scins[indexSkin].Object.SetActive(true);

        if (data.buyChek[indexSkin] == true)
        {
            unlock.SetActive(false);
            select.SetActive(true);
            priceBaloon.SetActive(false);
        }
        else if (data.buyChek[indexSkin] == false)
        {
            priceBaloon.SetActive(true);
            if (data.languageIndex == 1)
            {
                priceText.text = $"Стоит монет:{scins[indexSkin].price}";
            }
            else if (data.languageIndex == 0)
            {
                priceText.text = $"Cost:{scins[indexSkin].price}";
            }
            else if (data.languageIndex == 2)
            {
                priceText.text = $"Coste:{scins[indexSkin].price}";
            }
            unlock.SetActive(true);
            select.SetActive(false);

        }
    }

    public void CheckBuy()
    {
        if (data.coin >= scins[indexSkin].price)
        {
            data.coin -= scins[indexSkin].price;
            unlock.SetActive(false);
            select.SetActive(true);
            data.buyChek[indexSkin] = true;
            priceBaloon.SetActive(false);
        }
    }
    public void Select()
    {
        basde.skinIndex = indexSkin;
    }

}
