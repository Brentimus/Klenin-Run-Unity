using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinosaurRunJumpScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float velocity = 1000;
    private Rigidbody2D rigidBody2D;
    private BoxCollider2D boxCollider2D;
    [SerializeField] private LayerMask platformLayerMask;
    public GameManager gameManager;

    void Start()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        boxCollider2D = GetComponent<BoxCollider2D>();        
    }

    // Update is called once per frame
    void Update()
    {
        if (isGrounded() && Input.GetMouseButtonDown(0))
        {   
            rigidBody2D.velocity = Vector2.up * velocity;
        }
    }

    private bool isGrounded(){
        return Physics2D.Raycast(boxCollider2D.bounds.center, Vector2.down, boxCollider2D.bounds.extents.y + .01f, platformLayerMask).collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name != "ground"){
            gameManager.GameOver();
            //SceneManager.LoadScene(0);
        }
    }
}
