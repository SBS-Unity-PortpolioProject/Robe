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
    [SerializeField] int index = 0;
    bool TimeCheck = false;
    bool HealthCheck = false;
    private void Start()
    {
        index = Stars.Count - 1;
        GameManager.Instance.HealthChangeEvent.AddListener(OnHealthChanged);
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
        if(elapsedTime > unActiveTime && index >= 0 && !TimeCheck)
        {
            Stars[index].sprite = UnactiveStar;
            index--;
            TimeCheck = true;
        }
    }

    // 체력이 이미 최대 체력이 아닐 경우 그냥 종료하기 위한 조건 변수
    private bool isDeactiveHealthFlag = false;
    private void OnHealthChanged(float currentHealth, float maxHealth)
    {
        // 이미 최대 체력이 아니라서 Star가 비활성화 됨
        if(isDeactiveHealthFlag)
        {
            if(currentHealth >= maxHealth)
            {
                isDeactiveHealthFlag = false;
                index++;
                Stars[index].sprite = activestar;
            }
        }
        //Star가 활성화 되어 있음
        else
        {
            if(currentHealth < maxHealth)
            {
                Stars[index].sprite = UnactiveStar;
                index--;
                isDeactiveHealthFlag = true;
            }
        }
    }

    private void OnEnable()
    {

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
