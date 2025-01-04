using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float walkSpeed = 5f;
    [SerializeField] float jumpImpulse = 10f;

    Vector2 moveInput;
    ToucingDirection touchingDirection;

    public bool IsMoving { get; private set; }

    Rigidbody2D rb;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirection = rb.GetComponent<ToucingDirection>();
    }


    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput.x * walkSpeed * Time.fixedDeltaTime, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        IsMoving = moveInput != Vector2.zero;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.started && touchingDirection.IsGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
    }
}
