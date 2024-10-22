using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tranning : MonoBehaviour
{
    public GameObject[] windowsTran;
    public int indexWindow = 0;
    public GameObject tranning;
    public GameObject buttonLast;

    [SerializeField] private DataBase data;

    void OnEnable()
    {
        if(data.GuidCheck == true)
        {
            tranning.SetActive(true);
            Time.timeScale = 0f;
        }
    }
    
    public void Next()
    {
        windowsTran[indexWindow].SetActive(false);
        indexWindow += 1;
        if (indexWindow > 2)
        {
            tranning.SetActive(false);
            Time.timeScale = 1f;
        }
        else
        {
            windowsTran[indexWindow].SetActive(true);
            buttonLast.SetActive(true);
        }
        
    }

    public void Last()
    {
        windowsTran[indexWindow].SetActive(false);
        indexWindow -= 1;
        if (indexWindow < 0)
        {
            indexWindow = 0;
            buttonLast.SetActive(false);
            windowsTran[indexWindow].SetActive(true);
        }
        else
        {
            windowsTran[indexWindow].SetActive(true);
        }
    }


}
