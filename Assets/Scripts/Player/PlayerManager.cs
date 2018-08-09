using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour {
    Rigidbody2D rigid;
    BoxCollider2D col;
    Vector2 movement;
    SpriteRenderer sprite;
    Animator animator;

    RaycastHit2D groundcheck;

    
    public float maxSpeed;
    public float jumpVelocity;

    private bool grounded;
    private const int rayAmount = 3;

    private float collisionSize;

    private bool moving;
    private bool falling;
    private bool fallingTop;
    private bool pushing;
    private float previousY;

    private CheckpointManager checkpointManager;

    void Start () {
        rigid = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        col = GetComponent<BoxCollider2D>();
        checkpointManager = FindObjectOfType<CheckpointManager>();

        previousY = rigid.position.y;
        collisionSize = (col.size.y / 2) + 0.1f;
	}

	void Update () {
        movement.x = Input.GetAxisRaw("Horizontal") * maxSpeed;
        if (movement.x == 0)// Idle
        {
            moving = false;
        }
        else// Moving
        {
            moving = true;
            sprite.flipX = movement.x > 0 ? false : true;
        }

        falling = !GroundCheck(rigid.position, col, rayAmount, collisionSize, false);// Falling

        if (!falling && Input.GetButtonDown("Jump"))
        {
            rigid.AddForce(Vector2.up * jumpVelocity);
        }

        animator.SetBool("moving", moving);
        animator.SetBool("fallingTop", fallingTop);
        animator.SetBool("falling", falling);
        animator.SetBool("pushing", pushing);
    }

    private void FixedUpdate()
    {
        rigid.velocity = new Vector2(movement.x, rigid.velocity.y);

        fallingTop = false;

        if (falling && System.Math.Round(previousY, 3) > System.Math.Round(rigid.position.y, 3))// Falling Top
        {
            fallingTop = true;
        }

        previousY = rigid.position.y;
    }

    private bool GroundCheck(Vector2 startPos, BoxCollider2D boxCollider, int rayAmount, float rayLength, bool debug = false)
    {
        Vector2[] raycastStart = new Vector2[rayAmount];
        RaycastHit2D[] hits = new RaycastHit2D[rayAmount];

        for (int i = 0; i < rayAmount; i++)
        {
            raycastStart[i].x = startPos.x - boxCollider.size.x / 2 + i * boxCollider.size.x / 2;
            raycastStart[i].y = startPos.y;
            if (debug)
            {
                Debug.DrawRay(raycastStart[i], -Vector2.up * rayLength, Color.magenta);
            }
        }

        for (int i = 0; i < rayAmount; i++)
        {
            hits[i] = Physics2D.Raycast(raycastStart[i], -Vector2.up, rayLength);

            if (hits[i].collider != null && (hits[i].collider.CompareTag("Terrain") || hits[i].collider.CompareTag("Stone")))
            {
                if (debug)
                {
                    print("hit");
                }

                return true;
            }
        }
        if(debug)
            Debug.Log("!hit");
        return false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Stone"))
        {
            pushing = true;
        }
        else if (collision.transform.CompareTag("Kill"))
        {

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Stone"))
        {
            pushing = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Checkpoint"))
        {
            checkpointManager.SetCheckpoint(collision.gameObject);
        }
    }
}
