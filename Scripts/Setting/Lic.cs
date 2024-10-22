using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lic : MonoBehaviour
{
    public GameObject[] windowLic;
    private int indexWindow = 0;
    public GameObject lilicense;

    public void OpenClose()
    {
        if (lilicense.activeSelf == false)
        {
            lilicense.SetActive(true);
        }
        else
        {
            lilicense.SetActive(false);
        }
    }

    public void Next()
    {
        windowLic[indexWindow].SetActive(false);
        indexWindow += 1;
        if (indexWindow > 2)
        {
            indexWindow = 0;
            windowLic[indexWindow].SetActive(true);
        }
        else
        {
            windowLic[indexWindow].SetActive(true);
        }
    }
    public void Last()
    {
        windowLic[indexWindow].SetActive(false);
        indexWindow -= 1;
        if (indexWindow < 0)
        {
            indexWindow = 2;
            windowLic[indexWindow].SetActive(true);
        }
        else
        {
            windowLic[indexWindow].SetActive(true);
        }
    }
}
