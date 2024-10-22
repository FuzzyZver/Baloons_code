using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MenuWindows : MonoBehaviour
{
    [SerializeField] private Animator windows;
    public event Action isSkins;


    //Открытие/закрытие настроек
    public void OpenSetting()
    {
        windows.SetBool("openSetting", true);
    }
    public void CloseSetting()
    {
        windows.SetBool("openSetting", false);
    }

    //Открытие/закрытие скинов
    public void OpenSkins()
    {
        isSkins?.Invoke();
        windows.SetBool("openSkins", true);
    }
    public void CloseSkins()
    {
        isSkins?.Invoke();
        windows.SetBool("openSkins", false);
    }
    //Открытие/закрытие уровней
    public void OpenLevels()
    {
        windows.SetBool("openLevels", true);
    }
    public void CloseLevels()
    {
        windows.SetBool("openLevels", false);
    }
}
