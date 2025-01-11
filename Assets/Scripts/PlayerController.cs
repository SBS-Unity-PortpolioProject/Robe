using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _Speed = 8f;
    [SerializeField] float jumpImpulse = 10f;

    public float Speed
    {
        get
        {
            if (!CanMove)
            {
                return 0;
            }
            if(!IsMoving || touchingDirection.IsOnWall)
            {
                return 0;
            }
            return _Speed;
        }
    }

    Vector2 moveInput;
    ToucingDirection touchingDirection;

    private bool _isMoving = false;

    public bool IsMoving {
        get {  return _isMoving; }
        private set 
        {
            _isMoving = value;
            animator.SetBool("isMoving", value);
        } 
    }

    private bool _isFacingRight = true;
    public bool IsFacingRight
    {
        get { return _isFacingRight; }
        set
        {
            if (_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }
            _isFacingRight = value;
        }
    }

    public bool CanMove { get
        {
            return animator.GetBool("CanMove");
        } }

    public bool lockvelocity
    {
        get
        {
            return animator.GetBool("lockvelocity");
        }
        set
        {
            animator.SetBool("lockvelocity", value);
        }
    }


    public Rigidbody2D rb;
    Animator animator;
    Damageable _damageable;
    Damageable damageable => _damageable ??= GetComponent<Damageable>();

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirection = rb.GetComponent<ToucingDirection>();
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate()
    {
        if (!lockvelocity)
        {
            rb.velocity = new Vector2(moveInput.x * Speed, rb.velocity.y);
        }
        rb.velocity = new Vector2(moveInput.x * Speed, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;

        SetFacingDirection(moveInput);
    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if (!damageable.IsAlive) { return; }
        if (moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirection.IsGrounded && CanMove)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }

    public void OnHit(int damage, Vector2 knockback)
    {
        lockvelocity = true;
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
