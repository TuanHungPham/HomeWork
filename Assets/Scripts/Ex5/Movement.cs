using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    #region public var
    #endregion

    #region private var
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float wallSlideSpeed;
    [SerializeField] private float wallForceX;
    [SerializeField] private float wallForceY;
    [SerializeField] private Rigidbody2D rb2d;
    [SerializeField] private bool isGrounded;
    [SerializeField] private bool isOnWall;
    [SerializeField] private string wallTag;
    [SerializeField] private string groundTag;
    #endregion

    private void Awake()
    {
        LoadComponents();
    }

    private void Reset()
    {
        LoadComponents();
    }

    private void LoadComponents()
    {
        rb2d = GetComponent<Rigidbody2D>();

        moveSpeed = 7;
        wallTag = "Wall";
        groundTag = "Ground";
    }

    private void FixedUpdate()
    {
        Move();
        Jump();
        WallSlide();
        WallJump();
    }

    private void Move()
    {
        if (!InputManager.Instance.IsMovingInput || !isGrounded) return;

        rb2d.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), rb2d.velocity.y);
        Debug.Log("Moving...");
    }

    private void Jump()
    {
        if (!isGrounded || !InputManager.Instance.IsJumpingInput) return;

        Vector2 force = new Vector2(rb2d.velocity.x, jumpForce);
        rb2d.AddForce(force);
        Debug.Log("Jumping...");
    }

    private void WallJump()
    {
        if (!isOnWall || isGrounded || !InputManager.Instance.IsJumpingInput) return;

        float jumpDirection = 0;
        if (Input.GetAxis("Horizontal") > 0)
        {
            jumpDirection = 1;
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            jumpDirection = -1;
        }
        else if (Input.GetAxis("Horizontal") == 0)
        {
            return;
        }

        Vector2 force = new Vector2(wallForceX * jumpDirection, wallForceY);
        rb2d.velocity = force;
        Debug.Log("Wall Jumping...");
    }

    private void WallSlide()
    {
        if (!isOnWall) return;
        rb2d.velocity = new Vector2(rb2d.velocity.x, -wallSlideSpeed);
    }

    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag(wallTag))
        {
            isOnWall = true;
        }
        else if (collider.gameObject.CompareTag(groundTag))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag(wallTag))
        {
            isOnWall = false;
        }
        else if (collider.gameObject.CompareTag(groundTag))
        {
            isGrounded = false;
        }
    }
}
