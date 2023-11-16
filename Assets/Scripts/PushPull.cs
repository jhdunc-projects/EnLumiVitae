using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour

{
    private Rigidbody rb;
    private bool canPush;
    public Animator animator;
    public GameObject player;
    
    bool isMoving;
    private Transform objTransform;
    private Vector3 lastPosition;

    private bool isTouching;
    public float objOffset;
    private float distanceDiff;
    private float objX;



    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        objTransform = transform;
        lastPosition = objTransform.position;
        isMoving = false;

    }

    private void OnCollisionEnter(Collision collision)
    {
        isTouching = true;
        objX = transform.position.x;
        distanceDiff = player.transform.position.x - objX;

        if ((player.transform.position.x - objX) > 0)
        {
            objOffset = -.75f;
        }
        else
        {
            objOffset = .75f;
        }


    }

    private void OnCollisionExit(Collision collision)
    {
        isTouching = false;
    }
    void SetTransformX(float offset)
    {
        transform.position = new Vector3(player.transform.position.x + offset, transform.position.y, transform.position.z);
    }

    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {
            if (isTouching == true && canPush == false)
            {
                rb.isKinematic = false;
                canPush = true;
                animator.SetBool("CanPush", true);
            }
            else
            {
                rb.isKinematic = true;
                canPush = false;
                animator.SetBool("CanPush", false);
            }
            
        }
        if (animator.GetBool("inLight") == false)
        {
            rb.isKinematic = true;
            canPush = false;
            animator.SetBool("CanPush", false);
        }
        Debug.Log("canPush" + canPush);
        if (canPush == true)
        {
            Debug.Log("Call SetTransformX" + "step 1: canPush = true");
            if (player.transform.position.x - objX != distanceDiff)
            {
                Debug.Log("Call SetTransformX");
                SetTransformX(objOffset);
            }
        }

        if (objTransform.position != lastPosition)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        
    }
    private void LateUpdate()
    {
        lastPosition = objTransform.position;
        if (isMoving)
        {
            animator.SetBool("IsPushing", true);
        }
        else
        {
            animator.SetBool("IsPushing", false);
        }

    }
}
