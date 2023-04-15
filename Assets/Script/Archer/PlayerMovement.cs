using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // All the require Components
    private Rigidbody2D rb2D;
    private Animator  anim;
    private SpriteRenderer characterSprite;
    private float moveHorizontal;

    [Header("Ground Checker")]
    [SerializeField] private BoxCollider2D checkCollision;
    [SerializeField] [Range(0.1f, 0.3f)] private float rayBuffer = 0.2f;

    [Header("Moving")]
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float runSpeed = 10f;
    [SerializeField] private float jumpForce = 15f;
   
    [Header("Layer Mask")]
    public LayerMask jumpableGround;

    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        characterSprite = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal");
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            rb2D.velocity = new Vector2(moveHorizontal * walkSpeed, rb2D.velocity.y);
        }
        else
        {
            rb2D.velocity = new Vector2(moveHorizontal * runSpeed, rb2D.velocity.y);
        }
        
        if (Input.GetButtonDown("Jump") && isGround() ) 
        {
            rb2D.velocity = new Vector2(0, jumpForce);
        }

        UpdateAnimationMove();
    }

    // Check the ground to jump
    private bool isGround()
    {
        return Physics2D.BoxCast(checkCollision.bounds.center, checkCollision.bounds.size, 0f, Vector2.down, rayBuffer, jumpableGround);
    }

    #region Move Animation

    private enum MovementState { player_idel, player_running, player_jumping, player_falling, player_walking }
    private void UpdateAnimationMove()
    {
        MovementState state;
        if (moveHorizontal > 0f && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            state = MovementState.player_walking;
            characterSprite.flipX = false;
        }
        else if (moveHorizontal < 0f && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            state = MovementState.player_walking;
            characterSprite.flipX = true;
        }
        else if (moveHorizontal > 0f)
        {
            state = MovementState.player_running;
            characterSprite.flipX = false;
        }
        else if (moveHorizontal < 0f)
        {
            state = MovementState.player_running;
            characterSprite.flipX = true;
        }
        else
        {
            state = MovementState.player_idel;
        }

        if (rb2D.velocity.y > .1f)
        {
            state = MovementState.player_jumping;
        }
        else if (rb2D.velocity.y < -.1f)
        {
            state = MovementState.player_falling;
        }

        anim.SetInteger("state", (int)state);
    }

    #endregion
}
