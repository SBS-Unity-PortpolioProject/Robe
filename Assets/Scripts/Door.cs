using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Damageable damageable = collision.gameObject.GetComponent<Damageable>();
            GameManager.Instance.FinalHealth = damageable.Health;
            GameManager.Instance.ClearTime = Time.time - GameManager.Instance.FailTime;
            SceneManager.LoadSceneAsync(3);
        }
    }
}
