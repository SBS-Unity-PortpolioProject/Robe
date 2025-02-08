using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        GameManager.Instance.FailTime = Time.time;
        GameManager.Instance.CurrentHealth = 100;
    }

    public void GoHome()
    {
        SceneManager.LoadSceneAsync(0);
        GameManager.Instance.FailTime = Time.time;
        GameManager.Instance.CurrentHealth = 100;
    }
}
