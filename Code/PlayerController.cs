using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpforce;
    private float moveInput;

    private bool facingRight = true;

    private Rigidbody2D rb;


    private bool isGrounded = false;
    public Transform groundcheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpforce;
        }
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundcheck.position, checkRadius, whatIsGround);
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        if ((facingRight == false) && (moveInput > 0))
        {
            Flip();
        }
        else if ((facingRight == true) && (moveInput < 0))
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }
}