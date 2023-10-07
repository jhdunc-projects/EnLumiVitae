using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementRB : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpForce;

    private bool bloodForm = true;
    private bool boneForm = false;
    private bool voidForm = false;

    bool jump = false;

    public SpriteRenderer sr;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }
    void Update()
    {
        // Set variables to make look more tidy
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Movement
        rb.velocity = new Vector3(x * moveSpeed, rb.velocity.y, z * moveSpeed);
        
        animator.SetFloat("Speed", Mathf.Abs(x));
        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        // Jump 
        if (Input.GetButtonDown("Jump"))
        {
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
        }
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
