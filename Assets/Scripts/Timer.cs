using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]List<Image> Stars = new List<Image>();

    [SerializeField] private Sprite UnactiveStar;
    [SerializeField] private Sprite activestar;

    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    [SerializeField] private float unActiveTime = 100;
    int index = 0;
    private void Start()
    {
        index = Stars.Count - 1;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(elapsedTime / 60);
            int seconds = Mathf.FloorToInt(elapsedTime % 60);
            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
        if(elapsedTime > unActiveTime)
        {
            Stars[index].sprite = UnactiveStar;
            index--;
        }
        if(GameManager.Instance.CurrentHealth < 100)
        {
            Stars[index].sprite = UnactiveStar;
            index--;
        }
        if(GameManager.Instance.CurrentHealth == 100 && Stars[index++] != null)
        {
            Stars[index++].sprite = activestar;
            index++;
        }
    }

 

    //private void OnStar()
    //{
    //    if(ActiveStar != null && gameObject.CompareTag("Star2"))
    //    {
    //        ActiveStar.sprite = activestar;
    //    }
    //}

    //public void UnActiveStar()
    //{
    //    if(elapsedTime > unActiveTime && ActiveStar != null && gameObject.CompareTag("Star3"))
    //    {
    //        ActiveStar.sprite = UnactiveStar;
    //    }

    //    if(GameManager.Instance.CurrentHealth < 100 && ActiveStar != null && gameObject.CompareTag("Star2"))
    //    {
    //        ActiveStar.sprite = UnactiveStar;
    //    }
    //} 
}
