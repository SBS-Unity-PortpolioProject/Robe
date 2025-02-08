using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StompableComponent : MonoBehaviour
{

    // 플레이어가 뛰어오를 vector값
    [SerializeField] Vector2 jump = Vector2.zero;

    // 몬스터가 죽었을 떄 사용할 넉백
    [SerializeField] Vector2 knockback = Vector2.zero;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Damageable damageable = GetComponentInParent<Damageable>();

        if (collision.gameObject.CompareTag("Player") && damageable != null)
        {
            damageable.Hit(damageable.MaxHealth, knockback);

            PlayerController playercontroller = collision.gameObject.GetComponent<PlayerController>();

            playercontroller.rb.velocity = new Vector2(jump.x, playercontroller.rb.velocity.y + jump.y);
        }
    }
}
