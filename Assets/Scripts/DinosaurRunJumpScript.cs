using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DinosaurRunJumpScript : MonoBehaviour
{
    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;
    public GameManager gameManager;

    public AudioSource deathSound;
    public AudioSource coinSound;

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

    public Animator animator;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void FixedUpdate()
    {
        rigidBody2D.velocity = new Vector2(moveInput * speed, rigidBody2D.velocity.y);
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        animator.SetBool("IsJumping", !isGrounded);

        if (isGrounded == true && (Input.GetKeyDown(KeyCode.UpArrow)))
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;

            rigidBody2D.velocity = Vector2.up * jumpForce;
        }

        if ((Input.GetKey(KeyCode.UpArrow)) && isJumping == true)
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
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            isJumping = false;
        }

        if (isGrounded == true && Input.GetButtonDown("Jumping"))
        {
            rigidBody2D.velocity = Vector2.up * 26;
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name != "ground"){
            deathSound.Play();
            gameManager.GameOver();
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "coffee(Clone)")
        {
            coinSound.Play();
            UpdateScore.score++;
            Destroy(other.gameObject);
        }
    }
}
