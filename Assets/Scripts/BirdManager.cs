using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdManager : MonoBehaviour
{
    private float timeElapsed = 0f;
    private Bird _Bird;
    public Bird Bird => _Bird ??= GetComponentInChildren<Bird>(true);
    
    private Animator _animator;

    public Animator animator => _animator ??= GetComponentInChildren<Animator>(true);

    private bool _Stomp = false;
    public bool Stomp
    {
        get
        {
            return _Stomp;
        }
        set
        {
            _Stomp = value;
            animator.SetBool("Stomp", value);
        }
    }


    private void LateUpdate()
    {
        if (!Stomp) return;

        timeElapsed += Time.deltaTime;
        if (Stomp && timeElapsed > 2f)
        {
            Stomp = false;
            Bird.gameObject.SetActive(true);
            Bird.GetComponent<SpriteRenderer>().color = Color.white;
            timeElapsed = 0f;
        }
    }

    public void bird()
    {
        Stomp = true;
    }
}
