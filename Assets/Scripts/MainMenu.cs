using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadSceneAsync(1);
        GameManager.Instance.FailTime = Time.time;
        GameManager.Instance.CurrentHealth = 100;

    }
}
