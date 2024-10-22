using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] private ParticleSystem[] lightings;
    [SerializeField] private BoxCollider[] danger;
    [SerializeField] private DataBase dataBase;

    public AudioSource audioSource;

    private float activeInterval = 4f;

    private void OnEnable()
    {
        if (!dataBase.soundCheck)
        {
            audioSource.enabled = false;
        }
        if(lightings != null && danger != null)
        {
            StartCoroutine(OnDangerSanya());
        }
    }

    IEnumerator OnDangerSanya()
    {
        audioSource.volume = 0.3f;
        while (true)
        {
            SetActiveColliders(true);
            audioSource.Play();

            yield return new WaitForSeconds(activeInterval);
            audioSource.Stop();
            SetActiveColliders(false);

            yield return new WaitForSeconds(activeInterval);
        }
    }

    private void SetActiveColliders(bool isActive)
    {
        foreach (var collider in danger)
        {
            collider.enabled = isActive;
        }

        foreach (var particleSystem in lightings)
        {
            if (isActive)
            {
                particleSystem.Play();
            }
            else
            {
                particleSystem.Stop();
            }
        }
    }
}
