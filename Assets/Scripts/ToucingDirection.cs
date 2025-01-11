using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToucingDirection : MonoBehaviour
{
    public ContactFilter2D castFileter;

    public float groundDistance = 0.05f;
    public float wallDIstance = 0.2f;
    public float ceilingDistance = 0.05f;
    Animator _animator;
    Animator Animator => _animator ??= GetComponent<Animator>();

    CapsuleCollider2D touchingCol;

    RaycastHit2D[] groundHits = new RaycastHit2D[5];
    RaycastHit2D[] wallHits = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHits = new RaycastHit2D[5];

    [SerializeField] private bool _isGrounded = true;

    public bool IsGrounded { get 
        {
            return _isGrounded; 
        } private set {
            _isGrounded = value;
            Animator.SetBool("IsGrounded", value);
        } }

    private Vector2 wallCheckDirection => gameObject.transform.localScale.x > 0 ? Vector2.right : Vector2.left;

    [SerializeField] private bool _isOnWall = false;
    public bool IsOnWall
    {
        get { return _isOnWall; }
        private set
        {
            _isOnWall = value;
        }
    }

    [SerializeField] private bool _isOnCeiling = false;
    public bool IsOnCeiling
    {
        get { return _isOnCeiling; }
        private set
        {
            _isOnCeiling= value;
        }
    }

    private void Awake()
    {
        touchingCol = GetComponent<CapsuleCollider2D>();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        IsGrounded = touchingCol.Cast(Vector2.down, castFileter, groundHits, groundDistance) > 0;
        IsOnWall = touchingCol.Cast(wallCheckDirection, castFileter, wallHits, wallDIstance) > 0;
        IsOnCeiling = touchingCol.Cast(Vector2.up, castFileter, ceilingHits, ceilingDistance) > 0;
    }
}
