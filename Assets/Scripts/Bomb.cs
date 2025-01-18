using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    [SerializeField] GameObject GameObject = null;
    [SerializeField] Transform transform_bomb = null;
    public int attackDamage = 25;
    public Vector2 knockback = Vector2.zero;
    ToucingDirection touchingDirection;
    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        TryBomb();
    }

    void BombDirection()
    {
        Vector2 BombDirection = new Vector2(transform.localScale.x * 3, 5);
        transform_bomb.right = BombDirection;
    }
    
    void TryBomb()
    {
        rb.GetComponent<Rigidbody2D>().velocity = (gameObject.transform.up * 10f) + (gameObject.transform.forward * 5f);
    }

    void Update()
    {
        //transform.right = GetComponent<Rigidbody2D>().velocity;
        BombDirection();
        if(touchingDirection.IsGrounded || touchingDirection.IsOnWall || touchingDirection.IsOnCeiling)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (collision.gameObject.TryGetComponent<Damageable>(out var damageable))
            {
                bool gotHit = damageable.Hit(attackDamage, knockback);
                Debug.Log("Hit25");
                Destroy(gameObject, 0.1f);
            }
        }
    }
}
