using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControler : MonoBehaviour
{
    //private float getDirection;

    public float speed = 3f;

    public float jumpSpeed= 5f;

    Rigidbody2D rb2D;

    public Animator animator;

    //---BetterJump---
    public bool betterJump = false;
    public float fallMultiplier = 0.5f;
    public float lowJump = 1f;

    //-Flip-
    public SpriteRenderer spriteRenderer;
    
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }


    private void Update()
    {
        //CheckDirection();
    }
    void FixedUpdate()
    {
        //---Movement---
        if (Input.GetKey("d") || Input.GetKey("right"))
        {
            rb2D.velocity = new Vector2(speed, rb2D.velocity.y);
            
            spriteRenderer.flipX = false;

            animator.SetBool("Run", true);
        }
        else if (Input.GetKey("a") || Input.GetKey("left"))
        {
            rb2D.velocity = new Vector2(-speed, rb2D.velocity.y);
            
            spriteRenderer.flipX = true;

            animator.SetBool("Run", true);
        }
        else
        {
            rb2D.velocity = new Vector2(0, rb2D.velocity.y);

            animator.SetBool("Run", false);
        }
        //---Jump---
        if (Input.GetKey("space") && CheckGround.isGrounded)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpSpeed);            
        }

        if (CheckGround.isGrounded == false)
        {
            animator.SetBool("Jump", true);
            animator.SetBool("Run", false);
        }

        if (CheckGround.isGrounded == true)
        {
            animator.SetBool("Jump", false);
            
        }

        //---BetterJump---
        if (betterJump)
        {
            if (rb2D.velocity.y < 0)
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier) * Time.deltaTime;
            }
            if (rb2D.velocity.y > 0 && !Input.GetKey("space"))
            {
                rb2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJump) * Time.deltaTime;
            }
        }
        
    }


    //private void CheckDirection()
    //{
    //    getDirection = Input.GetAxisRaw("Horizontal");
    //}

    //private void Movement()
    //{
    //    rb2D.velocity = new Vector2(speed * getDirection, rb2D.velocity.y);
    //}


}
