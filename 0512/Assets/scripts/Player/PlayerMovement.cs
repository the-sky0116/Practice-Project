using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private float movedirection;
    private Rigidbody2D rb;
    private Animator anim;

    public static float moveSpeed = 10.0f;

    public bool isfacingRight = true;

    public float Jumpforce = 1000.0f;

    private bool walking;
    private bool canjunp;

    public float groundCheckRadius;
    public LayerMask whatIsGround;
    public bool isGrounded;
    public Transform groundcheck;

    PlayerHeal playerHeal;
    private bool dead;
    bool moveable;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveable = true;
    }

    void Update()
    {
        input();
        CheckDirection();
        UpdateAnimation();
        CheckIfCanJump();
        
    }
    
    public void FixedUpdate()
    {
        ApplyMovement();
        CheckSurroundings();
    }

    public void input()
    {
        movedirection = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown(("Jump")))
        {
            Jump();
        }
    }
    public void ApplyMovement()
    {
        rb.velocity = new Vector2(moveSpeed * movedirection, rb.velocity.y);
    }
    private void CheckSurroundings()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
    }    
    private void CheckIfCanJump()
    {
        if(isGrounded&&rb.velocity.y<=0)
        {
            canjunp = true;
        }    
        else
        {
            canjunp = false;
        }
    }    
    public void CheckDirection()
    {
        if (isfacingRight && movedirection < 0)
        {
            Flip();
        }
        else if (!isfacingRight && movedirection > 0)
        {
            Flip();
        }
        if (rb.velocity.x != 0)
        {
            walking = true;
        }
        else
        {
            walking = false;
        }
    }
    private void UpdateAnimation()
    {
        anim.SetBool("walking", walking);
    }
    private void Flip()
    {
        isfacingRight = !isfacingRight;
        if(!isfacingRight)
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);// transform.localScale = new Vector2(-2.1f, 2.1f);
        }
        else
        {
            transform.Rotate(0.0f, 180.0f, 0.0f);//transform.localScale = new Vector2(2.1f, 2.1f);
        }
       // transform.Rotate(0.0f, 180.0f, 0.0f);
    }
    private void Jump()
    {
        if (canjunp)
        {
            rb.velocity = new Vector2(rb.velocity.x, Jumpforce); 
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundcheck.position, groundCheckRadius);
    }

}


