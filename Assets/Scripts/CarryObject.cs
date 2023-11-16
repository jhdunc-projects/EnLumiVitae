using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarryObject : MonoBehaviour
{
    // Much of this code is the same as the PushPull script
    // repurposed in a new script instead of adding if/else statements

    private Rigidbody rb;
    public bool grabbed;
    public Animator animator;
    public GameObject player;

    private Transform objTransform;
    private Vector3 lastPosition;

    private bool isTouching;
    private float objOffset;
    private float distanceDiff;
    private float objX;

    public GameObject heldObject;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        objTransform = heldObject.transform;
        lastPosition = objTransform.position;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        isTouching = true;
        heldObject = gameObject;
        objX = heldObject.transform.position.x;
        distanceDiff = player.transform.position.x - objX;

        // match offset variable to player's facing direction
        if ((player.transform.position.x - objX) > 0)
        {
            objOffset = -.25f;
        }
        else
        {
            objOffset = .25f;
        }

    }
    private void OnCollisionExit(Collision collision)
    {
        isTouching = false;
    }
    void SetTransformX(float offset)
    {
        // change target object's position by fixed offset amt on x and y
        // this is the "held" position
        heldObject.transform.position = new Vector3(player.transform.position.x + offset, player.transform.position.y + .50f, transform.position.z);
    }
    void ResetTransformX()
    {
        // change target object's position by fixed offset amt on x and y
        // this is the "held" position
        heldObject.transform.position = new Vector3(transform.position.x, player.transform.position.y + .35f, transform.position.z);
        rb.isKinematic = true;
        grabbed = false;
    }

    void Update()
    {
        float x = Input.GetAxis("Horizontal");

        // Grab Object
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTouching == true && grabbed == false)
            {

                rb.isKinematic = false;
                grabbed = true;
                SetTransformX(objOffset);
            }
            else
            {
                ResetTransformX(); 
                rb.isKinematic = true;
                grabbed = false;
            }
        }


        // if player turns, object held stays in front of player sprite        
        if (x != 0 && x < 0)
        {
            objOffset = -.25f;
        }
        else if (x != 0 && x > 0)
        {

            objOffset = .25f;

        }

        // if player has grabbed the object, and object position does not match offset difference, set the offset.
        if (grabbed == true)
        {
            if (player.transform.position.x - objX != distanceDiff)
            {
                SetTransformX(objOffset);
            }
            // Cannot grab if Void
            if (animator.GetBool("inLight") == false)
            {
                ResetTransformX();
            }
        }

    }
    private void LateUpdate()
    {
        // ensure variable lastPosition is equal to object's transform position.
        lastPosition = objTransform.position;
    }
}
