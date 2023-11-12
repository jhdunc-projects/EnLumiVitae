using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRB : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpForce;


    bool voidForm;
    bool jump = false;
    bool onGround = true;
    public SpriteRenderer sr;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        transform.GetChild(0).gameObject.SetActive(false);
        animator.SetBool("inLight", true);
        voidForm = false;
    }

    void OnCollisionEnter(Collision collision)
    {


        if (collision.gameObject.tag == "Floor")
        {
            jump = false;
            onGround = true;
            animator.SetBool("IsJumping", false);
            animator.SetBool("onGround", true);
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            animator.SetBool("inLight", true);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1f);
            voidForm = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Light")
        {
            animator.SetBool("inLight", false);
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, .2f);
            voidForm = true;


        }
    }
    void Update()
    {
        // Set variables to make look more tidy
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // Movement
        if (voidForm == false)
        {
            rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector3(x * moveSpeed, y * moveSpeed, rb.velocity.z);
        }

        animator.SetFloat("Speed", Mathf.Abs(x));
        if (Input.GetButtonDown("Jump") && !jump)
        {
            jump = true;
            animator.SetBool("IsJumping", true);
            animator.SetBool("onGround", false);

        }

        // Jump 
        if (Input.GetButtonDown("Jump") && voidForm == false)
        {
            if(jump && onGround)
            { 
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            onGround = false;
            }
        }

        // Fly

        // Flippin' the Sprite to match direction of movement
        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x != 0 && x > 0)
        {
            sr.flipX = false;
        }
    }
}
