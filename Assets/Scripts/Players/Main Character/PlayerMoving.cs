using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;

    [SerializeField] int Speed;
    private bool isFasingRight;

    private static bool isJump;
    [SerializeField] int JumpPower;

    bool isPlatform;

    [SerializeField] Transform GroundCheck;
    private float groundRadius;
    [SerializeField] LayerMask WhatIsGround;
   
    void Start()
    {
        isFasingRight = true;
        isJump = false;
        groundRadius = 0.2f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        MovingProcess();
        JumpProcess();

    }

    void MovingProcess()
    {
        float move = Input.GetAxis("Horizontal");

        animator.SetFloat("speed", Mathf.Abs(move));

        rb.velocity = new Vector2(move * Speed, rb.velocity.y);

        if (move > 0 && !isFasingRight)
        {
            Flip();
        }
        else if (move < 0 && isFasingRight)
        {
            Flip();
        }
    }

    void JumpProcess()
    {
        isJump = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, WhatIsGround);

        animator.SetBool("isJump", isJump);
        animator.SetFloat("JumpSpeed", rb.velocity.y);

        if (!isJump)
        {
            return;
        }
    }

   

    void Jump()
    {
        if (isJump && Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("isJump", false);
            rb.AddForce(new Vector2(0, JumpPower));
        }
    }

    

    void Flip()
    {
           
        isFasingRight = !isFasingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
