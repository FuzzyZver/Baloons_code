using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOVer : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private Basdepapji basde;
    [SerializeField] private DataBase data;
    [SerializeField] private InterstitialAds ads;
    [SerializeField] private GameObject buttonPause;

    public bool GameOver = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ground"))
        {
            EndGame();
            GameOver = true;
            ads.ShowAd();

        }
    }

    private void EndGame()
    {
        data.coin += basde.coins;
        basde.coins = 0;
        basde.plusCount = 1;
        basde.chunkCount = 0;
        anim.SetBool("isEnd", true);
        Destroy(gameObject);
        buttonPause.SetActive(false);


    }
}
