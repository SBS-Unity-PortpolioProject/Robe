using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    Rigidbody2D rb;
    public float bombSpeed;

    public void Fire()
    {
        gameObject.SetActive(true);
        rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(transform.position * bombSpeed);
        }
    }

}
