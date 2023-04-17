using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private float arrowSpeed = 5;
    private Rigidbody2D rbArrow;
    private float directionX;

    // Start is called before the first frame update
    void Start()
    {
        directionX = Input.GetAxisRaw("Horizontal");
        rbArrow = GetComponent<Rigidbody2D>();
        rbArrow.velocity = transform.right * arrowSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 6 )
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.layer == 7)
        {
            Destroy(gameObject);
        }
    }
}
