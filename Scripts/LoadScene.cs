using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string LdSn;

    public void LoadScenePlease()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(LdSn);
    }
}
