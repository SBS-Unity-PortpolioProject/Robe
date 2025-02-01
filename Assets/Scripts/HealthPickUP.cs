using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUP : MonoBehaviour
{
    [SerializeField] public int healthRestore = 25;
    public Vector3 spinRotatinoSpeed = new Vector3(0, 180, 0);

    private void FixedUpdate()
    {
        transform.eulerAngles += spinRotatinoSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable)
        {
            bool wasHeal = damageable.Heal(healthRestore);
            if (wasHeal)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
