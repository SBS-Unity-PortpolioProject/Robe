using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public int attackDamage = 25;
    public Vector2 knockback = Vector2.zero;
    GameObject gameobject;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<Damageable>(out var damageable))
        {
            bool gotHit = damageable.Hit(attackDamage, knockback);
            Debug.Log(collision.gameObject.name + " hit for " + attackDamage);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.gameObject.GetComponent<Damageable>();
        if(damageable != null)
        {
            bool gotHit = damageable.Hit(attackDamage, knockback);
            Debug.Log(collision.gameObject.name + " hit for " + attackDamage);

        }
    }
}
