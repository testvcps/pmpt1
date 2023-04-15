using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedChecker : MonoBehaviour
{
    // Start is called before the first frame update
   public BoxCollider2D coll;
    [SerializeField] public LayerMask jumpableAfterTouchingGround;
    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableAfterTouchingGround);
        //se tao 1 cai box check xem duoi chan co phai la ground hay ko
    }
}
