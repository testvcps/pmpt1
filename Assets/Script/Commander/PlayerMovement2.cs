using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2 : MonoBehaviour
{
    // Start is called before the first frame update
    private GroundedChecker groundcheck;
    private Rigidbody2D rb2D;
    private Animator  anim;
    private SpriteRenderer sprite; //quay sprite
    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;
    public int combo =0;
    // Start is called before the first frame update
    private enum MovementState { SamuraiC_idle, SamuraiC_running, SamuraiC_jumping, SamuraiC_falling }//enum tu khoi tao 1 func chi chay 4 gia tri kia
    //private MovementState state = MovementState.idle;
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();// gọi ở đây để ko phải khởi tạo 1 component mới mỗi khi chạy hàm update khiến phần mềm nhẹ đi
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        groundcheck = GetComponent<GroundedChecker>();
    }

    // Update is called once per frame
    private void Update()//upadte every frame of the computer
    {   
        dirX = Input.GetAxisRaw("Horizontal");
        rb2D.velocity = new Vector2(dirX * moveSpeed, rb2D.velocity.y);

        if(Input.GetButtonDown("Jump") && groundcheck.isGrounded())//jump is the name of the input manager
        {
            rb2D.velocity = new Vector2(0, jumpForce);//vector 3 is data holder for 3 values x y z // trong th 2 D thi chi x y thoi
        }

        UpdateAnimationUpdate();
    }

    private void UpdateAnimationUpdate()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.SamuraiC_running;
            // anim.SetBool("running", true);
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.SamuraiC_running;
            // anim.SetBool("running", true);
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.SamuraiC_idle;
            // anim.SetBool("running", false);
        }

        if (rb2D.velocity.y > .1f)
        {
            state = MovementState.SamuraiC_jumping;
        }
        else if (rb2D.velocity.y < -.1f)
        {
            state = MovementState.SamuraiC_falling;
        }
        anim.SetInteger("state", (int)state);
    }
}
