using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    [SerializeField] private Sprite ActiveStar;
    [SerializeField] List<Image> Stars = new List<Image>();
    int index = 0;
    bool TimerCheck = false;
    bool HealthCheck = false;
    public void Star()
    {
        if(GameManager.Instance.FinalHealth == 100 && index < 2 && !HealthCheck)
        {
            Stars[index].sprite = ActiveStar;
            index++;
            HealthCheck = true;
        }
        if (GameManager.Instance.ClearTime <= 100 && index < 2 && !TimerCheck)
        {
            Stars[index].sprite = ActiveStar;
            index++;
            TimerCheck = true;
        }
    }

    private void FixedUpdate()
    {
        Star();
    }
}
