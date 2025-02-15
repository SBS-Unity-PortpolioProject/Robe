using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{

    public float Speed = 5f;
    public float walkStopRate = 0.06f;
    Animator _animator;
    Animator Animator => _animator ??= GetComponent<Animator>();

    public bool CanMove
    {
        get
        {
            return Animator.GetBool("CanMove");
        }
    }

    Rigidbody2D rb;

    ToucingDirection touchingDirection;
    public enum EWalkDirection { Right, Left};

    private EWalkDirection _walkDirection;
    private Vector2 walkdirectionVector = Vector2.right;
    public EWalkDirection WalkDirection
    {
        get { return _walkDirection; }
        set
        {
            if(_walkDirection != value)
            {
                gameObject.transform.localScale = new Vector2(gameObject.transform.localScale.x * -1, gameObject.transform.localScale.y);

                if(value == EWalkDirection.Right)
                {
                    walkdirectionVector = Vector2.right;
                }
                else
                {
                     if(value == EWalkDirection.Left)
                    {
                        walkdirectionVector = Vector2.left;
                    }
                }
            }
            _walkDirection = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirection = GetComponent<ToucingDirection>();
    }

    private void FixedUpdate()
    {
        
        if (touchingDirection.IsOnWall && touchingDirection.IsGrounded && CanMove)
        {
            FlipDirection();
        }
        if (CanMove && touchingDirection.IsGrounded)
        {
            rb.velocity = new Vector2(Speed * walkdirectionVector.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(Mathf.Lerp(rb.velocity.x, 0, walkStopRate), rb.velocity.y);
        }
    }

    private void FlipDirection()
    {
        if(WalkDirection == EWalkDirection.Right)
        {
            WalkDirection = EWalkDirection.Left;
        }
        else if (WalkDirection == EWalkDirection.Left)
        {
            WalkDirection = EWalkDirection.Right;
        }
        else
        {
            Debug.LogError("Current EWalkDireciton is not legel value");
        }
    }
}
