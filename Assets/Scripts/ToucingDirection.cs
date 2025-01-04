using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToucingDirection : MonoBehaviour
{
    public ContactFilter2D castFileter;

    public float groundDistance = 0.05f;

    CapsuleCollider2D touchingCol;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];

    [SerializeField]
    private bool _isGrounded = true;

    public bool IsGrounded { get { return _isGrounded; } private set { _isGrounded = value; } }

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFileter, groundHits, groundDistance) > 0;
    }
}
