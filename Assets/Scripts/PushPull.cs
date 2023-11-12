using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushPull : MonoBehaviour

{
    public Rigidbody rb;
    private bool canPush;
    public Animator animator;
    bool isMoving;
    private Transform objTransform;
    private Vector3 lastPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        objTransform = transform;
        lastPosition = objTransform.position;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("pushed E");
            rb.constraints = RigidbodyConstraints.None;
            canPush = true;
            animator.SetBool("CanPush", true);
        }

        if (canPush)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
            rb.constraints = RigidbodyConstraints.FreezeRotation;
        }

        if (objTransform.position != lastPosition)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        lastPosition = objTransform.position;

    }
    private void LateUpdate()
    {
        if (isMoving)
        {
            animator.SetBool("IsPushing", true);
        }

    }
}
