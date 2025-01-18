using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float bounce = 5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            // 이렇게 바로 GetComponent해서 AddForce하기 보단 아래처럼 중간에 캐시를 하는 게 좋습니다.
            // Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            // if(rigid) rigid.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            // 이렇게 하는 이유는 간혹 Unity에서 기기 자체에 대한 메모리 접근으로 리소스(자원 => 여기서는 우리가 게임에서 사용할 이미지, Prefab, 사운드 파일과 관련된 데이터)를
            // 접근을 하는데 중간에 메모리 접근이 실패할 경우에 크래쉬(게임이 튕기거나 비정상적인 종료)가 나는 경우가 있습니다.
            // 그래서 중간에 캐시를 해서 없을 경우에 예외처리를 하는 게 훨씬 안정적으로 플레이를 할 수 있습니다. 
            // 만약 에러가 나면 팝업을 띄운다거나 LogError를 통해서 에러메세지를 남기는 방식으로 구현하면 됩니다.
            Rigidbody2D rigid = collision.gameObject.GetComponent<Rigidbody2D>();
            if (rigid != null)
            {
                rigid.AddForce(Vector2.up * bounce, ForceMode2D.Impulse);
            }
            else { Debug.Log("error"); }
        }
    }
}
