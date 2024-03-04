using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    public Animator animator;
    private Rigidbody2D rb;

    private bool facingRight = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    public ParticleSystem dust;

    void Start()
    {
        animator = GetComponent<Animator>();
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if (facingRight == false && moveInput > 0)
        {

            Flip();

        }
        else if (facingRight == true && moveInput < 0)
        {

            Flip();
        }

        if (Input.GetKey(KeyCode.Space))
        {

            Jump();
        }



        void FixedUpdate()
        {
            isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        }

        void Jump()
        {

            //rb.velocity = new Vector2(rb.velocity.x, speed);


            //float verticalMove = Input.GetAxis("Vertical");

            if (isGrounded == true)
            {
                extraJumps = extraJumpsValue;
            }

            if (extraJumps > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                extraJumps--;
            }
            else if (extraJumps == 0 && isGrounded == true)
            {
                rb.velocity = Vector2.up * jumpForce;
            }

        }

        void Flip()
        {
            CreateDust();
            facingRight = !facingRight;
            transform.Rotate(0f, 180f, 0f);

        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "Ground")
                isGrounded = true;
        }


        void CreateDust()
        {
            dust.Play();

        }
    }


}