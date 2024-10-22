using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip[] sound;
    public GameObject gameObject;
    private AudioSource audioSrc => GetComponent<AudioSource>();

    public GameObject bgMuzik;

    public DataBase dataBase;
    // Получаем компонент из игрового объекта
    //ComponentType component = gameObject.GetComponent<ComponentType>();

    // Активируем компонент
    //component.enabled = true;

    private void Start()
    {
        if (dataBase.soundCheck==true)
        {
            audioSrc.enabled = true;
        }
        else if (dataBase.soundCheck == false)
        {
            audioSrc.enabled = false;
        }

        if (dataBase.muzikCheck == false)
        {
            bgMuzik.SetActive(false);
        }
        else if (dataBase.muzikCheck == true)
        {
            bgMuzik.SetActive(true);
        }
    }

    public void PlaySound(AudioClip clip, float volume = 1f)
    {
        audioSrc.PlayOneShot(clip, volume);
    }

    public void ButtonClick()
    {
        PlaySound(sound[0],0.5f);
    }

    public void SoundOff()
    {
        if(dataBase.soundCheck == true)
        {
            dataBase.soundCheck = false;
            audioSrc.enabled = false;
        }
        else if (dataBase.soundCheck == false)
        {
            dataBase.soundCheck = true;
            audioSrc.enabled = true;
        }
    }
    public void GameplayMuzikOff()
    {
        if (dataBase.muzikCheck == false)
        {
            dataBase.muzikCheck = true;
            bgMuzik.SetActive(true);
        }
        else if (dataBase.muzikCheck == true)
        {
            dataBase.muzikCheck = false;
            bgMuzik.SetActive(false);
        }
    }
    
}
