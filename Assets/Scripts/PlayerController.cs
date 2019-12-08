using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb;
    private float moveInput;

    public float speed;
    public float jumpForce;
    
    //a gameObject is places at the feet. so player doesnt jump when touching sides
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private bool facingRight = true;

    public Animator anim;

    public AudioSource jumpAudio;
    public AudioSource pickupAudio;
    public AudioSource portalAudio;

    private GameController gameController;
 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<GameController>();
        }
        if (gameControllerObject == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }


    // Fixed used for physics 
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            anim.SetBool("isRunning", true);
        }
        else
        {
            anim.SetBool("isRunning", false);
        }

        if (Input.GetKey(KeyCode.W))
        {
            anim.SetTrigger("Jump");
        }
        
        //flip code
        if (facingRight == false && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }
      
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
    
        if (other.gameObject.CompareTag("Pickup"))
        {
            pickupAudio.Play();
        }


        // move player to next level

        if (other.gameObject.CompareTag("Portal"))
        {
            portalAudio.Play();
            transform.position = new Vector2(36.41f, -27.05f);
            gameController.ResetLives();
        }
  
    }


    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpAudio.Play();
            }
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0, 180, 0);
    }
}
   
