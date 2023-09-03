using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    private Rigidbody2D rb;
    private Animator amin;
    public SpriteRenderer sprite;
    public BoxCollider2D coll;
    public bool canMove;
    public bool canTalk;

    [SerializeField] private  LayerMask jumpableGround;
    private float dirX =0f;
    [SerializeField] private float movespeed = 7f;
    [SerializeField] private float jumpforce = 14f;

    private enum MovementState {idle, running, jumping, falling, holding}
    [SerializeField] private AudioSource jumpef;

    public bool isHolding;

    private void Start()
    {   
        rb=GetComponent<Rigidbody2D>();
        sprite=GetComponent<SpriteRenderer>();
        amin=GetComponent<Animator>();
        coll=GetComponent<BoxCollider2D>();

    }
    
    // Update is called once per frame
    private void Update()
    {
        if (canMove)
        {

            if (isDashing)
            {
                return;
            }
            dirX = Input.GetAxisRaw("Horizontal");
            rb.velocity = new Vector2(dirX * movespeed, rb.velocity.y);

            if (Input.GetButtonDown("Jump") && IsGrounded())
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpforce);
                jumpef.Play();
            }
            if (Input.GetKeyDown(KeyCode.LeftShift) && canDash)
            {
                StartCoroutine(Dash());
            }
        }
        
        AminationUpdate();
    }
 
    private void AminationUpdate()
    {
        MovementState state;
        if (!canMove)
        {
            state = MovementState.idle;
        }
        else
        {
            if (dirX > 0f)
            {
                state = MovementState.running;
                sprite.flipX = false;
            }
            else if (dirX < 0f)
            {
                state = MovementState.running;
                sprite.flipX = true;
            }
            else
            {
                if (isHolding)
                {
                    state = MovementState.holding;
                }
                else
                {
                    state = MovementState.idle;
                }
            }

            if (rb.velocity.y > .1f)
            {
                state = MovementState.jumping;
            }
            else if (rb.velocity.y < -.1f)
            {
                state = MovementState.falling;
            }
            if (state==MovementState.running || state== MovementState.idle)
            {
                canTalk = true;
            }
            else
            {
                canTalk = false;
            }
        }
        
        amin.SetInteger("state", (int)state);
    }
    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private bool canDash = true;
    private bool isDashing;
    private float dashingPower = 24f;
    private float dashingTime = 0.2f;
    private float dashingCooldown = 1f;
 


    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        float originalGravity = rb.gravityScale;
        rb.gravityScale = 0f;
        if (sprite.flipX == true)
        {
            rb.velocity = new Vector2(-1 * dashingPower, jumpforce / 5);
        }
        else
        {
            rb.velocity = new Vector2(dashingPower, jumpforce / 5);
        }
        yield return new WaitForSeconds(dashingTime);
        rb.gravityScale = originalGravity;
        isDashing = false;
        yield return new WaitForSeconds(dashingCooldown);
        canDash = true;

    }

}
