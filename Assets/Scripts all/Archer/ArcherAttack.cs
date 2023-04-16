using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherAttack : MonoBehaviour
{
    [SerializeField] private GameObject lightHitboxC1;
    [SerializeField] private GameObject lightHitboxC2;
    [SerializeField] private GameObject heavyHitboxC;
    // All the require Components
    [HideInInspector] public Animator anim; 
    private float moveHorizontal;

    [Header("Ground Checker")]
    [SerializeField] private BoxCollider2D checkCollision;

    [Header("Layer Mask")]
    public LayerMask jumpableGround;

    private void Start()
    {  
        anim = GetComponent<Animator>();
        deActivateAllatk();
    }

    // Update is called once per frame
    private void Update()
    {
        moveHorizontal = Input.GetAxisRaw("Horizontal"); 
        UpdateAnimationAttack();
        //deActivateAllatk();
    }

    #region Requirement

    public static ArcherAttack instance;
    // For combo attack
    private void Awake()
    {
        instance = this;
    }

    // Check the ground to attack
    private bool isGround()
    {
        return Physics2D.BoxCast(checkCollision.bounds.center, checkCollision.bounds.size, 0f, Vector2.down, jumpableGround);
    }
    
    
    // Show the hitbox on the screen
    // private void OnDrawGizmosSelected()
    // {
    //     Gizmos.DrawWireSphere(attack1Point.position, attack1Range);
    //     Gizmos.DrawWireCube(attack2Point.position, new Vector2(attack2Range, 1.7f));
    // }

    #endregion

    #region Attack 

    [Header("Light Attack stats")]
    [SerializeField] private float attack1Rate = 0.5f;
    // [SerializeField] private float attack1Range = 2.4f;
    // [SerializeField] private Transform attack1Point;
    public bool isAttacking1 = false;

    [Header("Heavy Attack stats")]
    [SerializeField] private float attack2Rate = 0.8f;
    // [SerializeField] private float attack2Range = 4f;
    // [SerializeField] private Transform attack2Point;
    public bool isAttacking2 = true;

    [Header("Range Attack stats")]
    [SerializeField] private float rangeAttackRate = 1f;
    [SerializeField] private Transform bowShoot;
    [SerializeField] private GameObject arrow;

    private float nextTimeAttack1 = 0f;
    private float nextTimeAttack2 = 0f;
    private float nextTimeRange = 0f;

    // Check if attack hit to call debug
    // private void AttackResult(Collider2D[] trigger)
    // {
    //     foreach (Collider2D enemy in trigger )
    //     {
    //         if (enemy.gameObject.layer == 6)
    //         {
    //             Debug.Log("Hit Sucesss");
    //         } 
    //     }
    // }

    // Trigger the light attack hurtbox in animation event
    private void LightAttack()
    {
        //AttackResult(Physics2D.OverlapCircleAll(attack1Point.position, attack1Range));
        nextTimeAttack1 = Time.time + attack1Rate;
    }

    // Trigger the heavy attack hurtbox in animation event
    private void HeavyAttack()
    {
        //AttackResult(Physics2D.OverlapBoxAll(attack2Point.position, new Vector2(attack2Range, 1.7f), 0f));
        nextTimeAttack2 = Time.time + attack2Rate;
    }

    // Shoot out arrow when call in animation event
    private void SpawnArrow()
    {
        Instantiate(arrow, bowShoot.position, transform.rotation);
        nextTimeRange = Time.time + rangeAttackRate;
    }

    private void UpdateAnimationAttack()
    {
        // If the player in on the ground and trigger then attack
        if (Input.GetButtonDown("LightAttack") && isGround() && !isAttacking1)
        {
            // Deylay time between attack so player don't spam
            if (Time.time >= nextTimeAttack1) 
            {
                isAttacking1 = true;  
            } 
        }
        
        if (Input.GetButtonDown("HeavyAttack") && isGround())
        {
            if (Time.time >= nextTimeAttack2)
            {
                isAttacking2 = true;
            }
        }

        if (Input.GetButtonDown("Range") && isGround())
        {
            if (Time.time >= nextTimeRange)
            {
                anim.SetTrigger("Range");
            }
        }

    }
    public void ActivateLatk1(){
        lightHitboxC1.SetActive(true);
    }
     public void ActivateLatk2(){
        lightHitboxC2.SetActive(true);
    }
     public void ActivateLatk3(){
        heavyHitboxC.SetActive(true);
    }
    public void deActivateLatk1(){
        lightHitboxC1.SetActive(false);
    }
    public void deActivateLatk2(){
        lightHitboxC2.SetActive(false);
    }
    public void deActivateLatk3(){
        heavyHitboxC.SetActive(false);
    }
    public void deActivateAllatk(){
        lightHitboxC1.SetActive(false);
        lightHitboxC2.SetActive(false);
        heavyHitboxC.SetActive(false);
    }


   

    #endregion
}

