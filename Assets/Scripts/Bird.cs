using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    //[SerializeField] private float Duration = 2;
    //[SerializeField] private float ActiveDuration = 1;
    //Animator animator;

    //private void Awake()
    //{
    //    animator = GetComponent<Animator>();
    //}

    //private bool _Stomp = false;
    //public bool Stomp
    //{
    //    get
    //    {
    //        return _Stomp;
    //    }
    //    set
    //    {
    //        _Stomp = value;
    //        animator.SetBool("Stomp", value);
    //    }
    //}

    //IEnumerator Active()
    //{
    //    yield return new WaitForSeconds(Duration);
    //    Stomp = true;
    //    yield return new WaitForSeconds(ActiveDuration);
    //    gameObject.SetActive(true);
    //}

    private BirdManager _manager;
    public BirdManager manager => _manager ??= GetComponentInParent<BirdManager>();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            manager.bird();
        }
    }
}
