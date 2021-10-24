using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public CharacterController2D controller;

    public int maxO2;
    float currentO2;

    public float runSpeed;
    public float jumpForce;
    public Transform isGroundedChecker;
    public float checkGroundRadius;
    public LayerMask groundLayer;

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    public float rememberGroundedFor;
    float lastTimeGrounded;
    bool isGrounded = false;

    private float move;

    private Rigidbody2D rb;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentO2 = maxO2;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Get directional input
        move = Input.GetAxis("Horizontal") * runSpeed * Time.fixedDeltaTime;
        animator.SetFloat("Speed", Mathf.Abs(move));

        Move(move);
        Jump();
        CheckIfGrounded();
        BetterJump();
        ChangeO2();

        
    }

    void FixedUpdate()
    {
        if (currentO2 > 0)
        {
            currentO2 -= 0.5f * Time.deltaTime;
        }
        UIO2Bar.instance.SetValue(currentO2 / maxO2);

    }

    void Move(float move)
    {
        //Move Player
        controller.Move(move, false, false);
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || Time.time - lastTimeGrounded <= rememberGroundedFor))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
        if (rb.velocity.y < 0)
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (fallMultiplier - 1) * Time.deltaTime;
            
        }
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb.velocity += Vector2.up * Physics2D.gravity * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    void ChangeO2()
    {
        Debug.Log((int)currentO2 + "/" + maxO2);
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
