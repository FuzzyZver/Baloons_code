using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CheckSkin : MonoBehaviour
{
    [SerializeField] private Basdepapji basde;
    [SerializeField] private DataBase dataBase;
    public TextMeshProUGUI coins;
    public GameObject[] skins;
    [SerializeField] private string LdSn;

    public GameObject buttonPause;
    public GameObject pauseScreen;

    void Start()
    {
        skins[basde.skinIndex].SetActive(true);
    }

    public void LoadScene()
    {
        Time.timeScale = 1f;
        dataBase.coin += basde.coins;
        basde.coins = 0;
        basde.plusCount = 1;
        basde.chunkCount = 0;
        SceneManager.LoadScene(LdSn);
    }

    public void Pause()
    {
        if (pauseScreen.activeSelf == false)
        {
            Time.timeScale = 0f;
            pauseScreen.SetActive(true);
            buttonPause.SetActive(false);
        }
        else if(pauseScreen.activeSelf == true)
        {
            Time.timeScale = 1f;
            pauseScreen.SetActive(false);
            buttonPause.SetActive(true);
        }
    }
}
