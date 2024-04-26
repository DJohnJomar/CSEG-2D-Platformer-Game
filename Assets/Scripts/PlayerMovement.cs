using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEditor;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float horizontal;
    [SerializeField] private float speed = 8f;
    [SerializeField] private float jumpingPower = 16f;
    private bool isFacingRight = true;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    //For animation
    public Animator animator;
    public bool isJumping = false;

    AudioSource jumpSound;

    // Start is called before the first frame update
    void Start()
    {
        jumpSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //Gets horizontal movement, returns -1 if left, 1 if right
        horizontal = Input.GetAxisRaw("Horizontal");

        // For animation
        animator.SetFloat("Speed", Mathf.Abs(horizontal));

        //For Jumping
        if(Input.GetButtonDown("Jump") && isGrounded())
        {
            jumpSound.Play();
            rb.velocity = new Vector2(rb.velocity.y, jumpingPower);
            animator.SetBool("IsJumping", true);
            
        } 

        if(Input.GetButtonDown("Jump") && rb.velocity.y >0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);   
        } 
       //Flips the character sprite left or right
        Flip();
    }


    //Updates the player rb's velocity ~ makes it move
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }
    private bool isGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    //Detects if facing left or right based on horizontal movement
    //Changes the scale of the player
    private void Flip()
    {
        if(isFacingRight && horizontal <0f || !isFacingRight && horizontal >0f)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
}
