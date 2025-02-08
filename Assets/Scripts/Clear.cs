using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clear : MonoBehaviour
{
    Image _UnactiveStar;
    Image UnactiveStar => _UnactiveStar ??= GetComponent<Image>();
    [SerializeField] private Sprite ActiveStar;

    public void Star2()
    {
        if(GameManager.Instance.FinalHealth == 100)
        {
            UnactiveStar.sprite = ActiveStar;
        }
    }

    public void Star3()
    {
        if(GameManager.Instance.ClearTime <= 100)
        {
            UnactiveStar.sprite= ActiveStar;
        }
    }

    private void FixedUpdate()
    {
        if (gameObject != null && gameObject.CompareTag("Star2"))
        {
            Star2();
        }
        if (gameObject != null && gameObject.CompareTag("Star3"))
        {
            Star3();
        }
    }
}
