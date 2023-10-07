using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpSpeed;
    public float groundDist;

    [SerializeField] private float rayLength;
    [SerializeField] private float rayPositionOffset;
    private bool canJump = true;

    public LayerMask terrainLayer;
    public Rigidbody rb;
    public SpriteRenderer sr;

    Vector3 RayPositionCenter;
    Vector3 RayPositionLeft;
    Vector3 RayPositionRight;

    RaycastHit[] GroundHitsCenter;
    RaycastHit[] GroundHitsLeft;
    RaycastHit[] GroundHitsRight;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    private void Jump()
    {

    }
    void Update()
    {
        // Touch Grass? (raycast ground check)
        RaycastHit hit;
        Vector3 castPos = transform.position;
        castPos.y += 1;

        if (Physics.Raycast(castPos, -transform.up, out hit, Mathf.Infinity, terrainLayer))
        {
            if(hit.collider != null)
            {
                Vector3 movePos = transform.position;
                movePos.y = hit.point.y + groundDist;
                transform.position = movePos;
            }
            else
            {
                Debug.Log("Where The Ground AT?!");
            }
        }

        // Jump Time

        // Make Player Move!
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        Vector3 moveDir = new Vector3(x, 0, y);
        rb.velocity = moveDir * speed;

        // Flippin' the Sprite to match direction of movement
        if (x != 0 && x < 0)
        {
            sr.flipX = true;
        }
        else if (x != 0 && x> 0)
        {
            sr.flipX = false;
        }
    }
}
