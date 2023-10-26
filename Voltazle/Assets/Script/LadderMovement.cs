using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Movement;

public class LadderMovement : MonoBehaviour
{
    private float vertical;
    [SerializeField] private float speed = 8f;
    private bool isLadder;
    private bool isClimbing;
    private bool canClimb;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        Debug.Log(vertical);
        if (isLadder && Mathf.Abs(vertical) == 1)
        {
            isClimbing = true;
        }


        if (move.IsGrounded())
        {
            if (!canClimb)
            {
                canClimb = true;
                isClimbing = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x / 3, vertical * speed);
        }
        else
        {
            rb.gravityScale = move.normGravity;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && canClimb)
        {
            isLadder = true;
            move.canJump = false;
            canClimb = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder") && canClimb)
        {
            isLadder = true;
            move.canJump = false;
            canClimb = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            if (!move.IsGrounded() && isClimbing)
                rb.velocity = new Vector2(rb.velocity.x, speed * 2);
            isLadder = false;
            isClimbing = false;
            move.canJump = true;
        }
    }
}
