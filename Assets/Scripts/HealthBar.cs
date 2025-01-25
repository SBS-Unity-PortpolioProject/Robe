using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider hpbar;

    [SerializeField] GameObject Player;

    Damageable damageable;

    private void Awake()
    {
        Slider hpbar = GetComponent<Slider>();
        damageable = Player.GetComponent<Damageable>();
    }

    private void Start()
    {   if(damageable != null && hpbar != null)
        { hpbar.value = (float)damageable.Health / (float)damageable.MaxHealth; }
    }

    private void Update()
    {
        HandleHp();
    }

    private void HandleHp()
    {
        if(damageable != null && hpbar != null)
        { hpbar.value = Mathf.Lerp(hpbar.value, (float)damageable.Health / (float)damageable.MaxHealth, Time.deltaTime * 10); }
    }
}

