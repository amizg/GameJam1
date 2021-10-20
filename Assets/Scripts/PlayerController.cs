using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int maxO2;
    float currentO2;

    public float speed;
    public float jumpForce;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    bool isGrounded = false;

    private float moveInput;

    private Rigidbody2D rigidBody2d;

    // Start is called before the first frame update
    void Start()
    {
        currentO2 = maxO2;
        rigidBody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        CheckIfGrounded();
        BetterJump();
        ChangeO2();
        Debug.Log(currentO2 + "/" + maxO2);
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        rigidBody2d.velocity = new Vector2(moveInput * speed, rigidBody2d.velocity.y);
        if (currentO2 > 0)
        {
            currentO2 -= 0.5f * Time.deltaTime;
        }
     
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rigidBody2d.velocity = new Vector2(rigidBody2d.velocity.x, jumpForce);
        }
    }

    void CheckIfGrounded()
    {
        Collider2D colliders = Physics2D.OverlapCircle(isGroundedChecker.position, checkGroundRadius, groundLayer);
        if (colliders != null)
        {
            isGrounded = true;
        }
        else
        {
            if (isGrounded)
            {
                lastTimeGrounded = Time.time;
            }
            isGrounded = false;
        }
    }

    void BetterJump()
    {
        if (rigidBody2d.velocity.y < 0)
        {
            rigidBody2d.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            
        }
        else if (rigidBody2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rigidBody2d.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void ChangeO2()
    {

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) )
        {
            if (currentO2 > 0)
            {
                currentO2 -= 1f * Time.deltaTime;
            }
            
        }
        if (Input.GetKey(KeyCode.Space) && !isGrounded && currentO2 > 0)
        {
            currentO2 -= 5.0f * Time.deltaTime;
        }
    }
}
