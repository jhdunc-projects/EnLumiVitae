using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPC : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public CharacterController controller;

    private Vector3 moveDirection;
    public float gravityScale;

    private bool bloodForm = true;
    private bool boneForm = false;
    private bool voidForm = false;

    public SpriteRenderer sr;

    public Animator animator;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    
    private void OnCollisionEnter(Collision any)
    {
        Debug.Log("Collision Occured");
        Debug.Log(any.transform.name);
    }
    void Update()
    {
        // Set variables to make look more tidy
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Debug.Log(moveDirection.y);
        moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, 0f, Input.GetAxis("Vertical") * moveSpeed);
        if (Input.GetButtonDown("Jump"))
        {
            moveDirection.y = jumpForce;
        }

        moveDirection.y = moveDirection.y + (Physics.gravity.y * gravityScale);
        controller.Move(moveDirection * Time.deltaTime);

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
