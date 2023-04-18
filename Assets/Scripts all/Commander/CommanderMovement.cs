using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommanderMovement : MonoBehaviour
{
    // All the require Components
    [SerializeField] public Collider2D collision;
    public HealthDecrease health;
    private Rigidbody2D rb2D;
    private Animator  anim;
    private SpriteRenderer characterSprite;
    private float moveHorizontal;
    private bool isFacingRight = true;

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
        controlMove();
        UpdateAnimationMove();
        // if(health.die == true){
        //     DeCollision();
        // }
    }

    #region Movement

    // Turn the character to the right direction
    private void controlMove()
    {
        // Turn the character to the right from the left
        if (moveHorizontal > 0 && !isFacingRight)
        {
            if(health.die == false){
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
            }
        }
        // and reverse
        else if (moveHorizontal < 0 && isFacingRight)
        {
            if(health.die == false){
                isFacingRight = !isFacingRight;
                transform.Rotate(0f, 180f, 0f);
            }
        }

        // Switch between walk and run speed
        if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
        {
            if(health.die == false){
                rb2D.velocity = new Vector2(moveHorizontal * walkSpeed, rb2D.velocity.y);
            }
        }
        else
        {   if(health.die == false){
                rb2D.velocity = new Vector2(moveHorizontal * runSpeed, rb2D.velocity.y);
            }
        }

        if (Input.GetButtonDown("Jump") && isGround())
        {   if(health.die == false){
                rb2D.velocity = new Vector2(0, jumpForce);
            }
        }
    }

    // Check the ground to jump in the right layer
    private bool isGround()
    {
        return Physics2D.BoxCast(checkCollision.bounds.center, checkCollision.bounds.size, 0f, Vector2.down, rayBuffer, jumpableGround);
    }

    #endregion

    #region Move Animation

    private enum MovementState { player_idel, player_running, player_jumping, player_falling, player_walking }
    private void UpdateAnimationMove()
    {
        MovementState state;
        if (moveHorizontal > 0f && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            state = MovementState.player_walking;
        }
        else if (moveHorizontal < 0f && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)))
        {
            state = MovementState.player_walking;
        }
        else if (moveHorizontal > 0f)
        {
            state = MovementState.player_running;
        }
        else if (moveHorizontal < 0f)
        {
            state = MovementState.player_running;
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

    public void DeCollision(){
        collision.enabled = false;
    }

    #endregion
}