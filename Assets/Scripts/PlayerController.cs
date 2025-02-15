using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _Speed = 8f;
    [SerializeField] float jumpImpulse = 10f;
    private int _doubleJump = 0;

    private bool canDash = true;
    private bool isDashing;
    [SerializeField] private Vector2 dashingPower = new Vector2(5,2);
    private float dashingtime = 0.2f;
    private float dashingCooldown = 1f;

    

    public int doubleJump
    {
        get
        {
            return _doubleJump;
        }
        private set
        {
            _doubleJump = value;
            animator.SetInteger("doubleJump", value);
        }
    }

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
        if (!CanMove) 
            return;
        if (isDashing)
            return;
        if (!lockvelocity)
        {
            rb.velocity = new Vector2(moveInput.x * Speed, rb.velocity.y);
        }

        if (touchingDirection.IsGrounded)
        {
            doubleJump = 0;
        }


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

        if(context.started && !touchingDirection.IsGrounded && CanMove && doubleJump < 1)
        {
            doubleJump++;
            rb.velocity = new Vector2(rb.velocity.x, jumpImpulse);
        }
      
    }

    public void OnDash(InputAction.CallbackContext context)
    {
        if (context.started && canDash && CanMove)
        {
            if(dashEffects.Count <= dashEffectCount)
            {
                for (int i = dashEffects.Count; i < dashEffectCount; i++)
                {
                    DashEffect obj = Instantiate(dashEffect);
                    dashEffects.Add(obj);
                    obj.gameObject.SetActive(false);
                }
            }
            StartCoroutine(Dash());
            StartCoroutine(OnShowEffect());
        }
    }


    public void OnHit(int damage, Vector2 knockback)
    {
        lockvelocity = true;
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }

    //private List<DashEffect> DF = null;
    //public List<DashEffect> DashEffects => dashEffects ??= GetComponentsInChildren<DashEffect>(true).ToList();


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        //float originalGravity = rb.gravityScale;
        //rb.gravityScale = 0f;
        Vector2 vel = dashingPower * rb.velocity.normalized;
        vel.y = Mathf.Abs(vel.y);
        rb.velocity = vel;
        yield return new WaitForSeconds(dashingtime);
        //rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;
    }

    [SerializeField] private DashEffect dashEffect;
    [SerializeField] private List<DashEffect> dashEffects = new List<DashEffect>();
    [SerializeField] private int dashEffectCount = 10;
    [SerializeField] private float elapsedTime = 0.1f;
    [SerializeField] private float duration = 0.05f;

    SpriteRenderer _spriteRenderer;
    public SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponent<SpriteRenderer>();

    private void Start()
    {
        for (int i = dashEffects.Count; i < dashEffectCount; i++)
        {
            DashEffect obj = Instantiate(dashEffect);
            dashEffects.Add(obj);
            obj.gameObject.SetActive(false);
        }
    }

    private IEnumerator OnShowEffect()
    {
        int index = 1;
        int count = dashEffects.Count;
        foreach (var effect in dashEffects)
        {
            effect.OnShowEffect(transform, SpriteRenderer.sprite, count - index, elapsedTime);
            index++;
            yield return new WaitForSeconds(duration);
        }
    }
}

