using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<int, Vector2> damageableHit;

    [SerializeField] private int _maxHealth = 100;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public int MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField] private int _health = 100;

    public int Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }
    
   [SerializeField] private bool _isAlive = true;
   [SerializeField] private bool isInvincible = false;
    
    private float timeSInceHit = 0;
    [SerializeField] private float invincibilityTime = 0.25f;

    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool("IsAlive", _isAlive);
        }
    }

    private void Update()
    {
        if (isInvincible)
        {
            if (gameObject.CompareTag("Player"))
            {
                gameObject.tag = "Invincible";
            }
            if (timeSInceHit > invincibilityTime + 1)
            {
                isInvincible = false;
                timeSInceHit = 0;
                gameObject.tag = "Player";
            }

            timeSInceHit += Time.deltaTime;
        }
    }

    public bool Hit(int damage, Vector2 knockback)
    {
        if(IsAlive && !isInvincible)
        {
            Health -= damage;
            if (gameObject.CompareTag("Player"))
            {
                GameManager.Instance.CurrentHealth = Health;
                GameManager.Instance.HealthChangeEvent.Invoke(Health, MaxHealth);
            }
            isInvincible = true;
            animator.SetTrigger("hit");
            damageableHit?.Invoke(damage, knockback);

            return true;
        }
        return false;
    }

    public bool Heal(int healthRestore)
    {
        if(IsAlive && Health < MaxHealth)
        {
            int maxHeal = Mathf.Max(MaxHealth - Health, 0);
            int actualHeal = Mathf.Min(maxHeal, healthRestore);
            Health += actualHeal;
            if (gameObject.CompareTag("Player"))
            {
                GameManager.Instance.CurrentHealth = Health;
                GameManager.Instance.HealthChangeEvent.Invoke(Health, MaxHealth);
            }
            return true;
        }
        return false;
    }
}
