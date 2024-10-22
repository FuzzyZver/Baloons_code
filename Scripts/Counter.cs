using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] private TextMeshPro score;

    public int hitCounter;

    private void OnMousDown()
    {
        hitCounter++;

        score.text = $"Ударов: {hitCounter.ToString()}";
    }
}
