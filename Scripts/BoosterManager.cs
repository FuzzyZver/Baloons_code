using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BoosterManager : MonoBehaviour
{
    [SerializeField] private Basdepapji hitCounter;
    public int multi;
    public int countCoins;
    public bool isCoin;
    public AudioSource audioSource;
    public ParticleSystem particleSystem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Baloon"))
        {

            if (isCoin == true)
            {
                hitCounter.coins += countCoins* hitCounter.plusCount;
            }
            else
            {
                // При столкновении с мячом увеличиваем счетчик количества получаемых монет
                hitCounter.plusCount *= multi;
            }
            StartCoroutine(Coroutine());
        }
    }

    IEnumerator Coroutine()
    {
        particleSystem.Play();
        audioSource.Play();
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
    }
}
