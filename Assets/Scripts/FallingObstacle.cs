using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObstacle : MonoBehaviour
{

    Animator animator;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Collide", true);
    }
    
}
