using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurRunJumpScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;
    public GameManager gameManager;

    public float speed;
    public Transform feetPos;
    private bool isGrounded;
    public float checkRadius;
    [SerializeField] private LayerMask whatIsGround;
    private float moveInput;
    public float jumpForce;
    private bool isJumping;

    private float jumpTimeCounter;
    public float jumpTime;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();        
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(moveInput * speed, rigidBody2D.velocity.y);
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (isGrounded == true && Input.GetKeyDown(KeyCode.Space))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;

            rigidBody2D.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                rigidBody2D.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            } else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name != "ground"){
            //gameManager.GameOver();
            //SceneManager.LoadScene(0);
        }
    }
}
