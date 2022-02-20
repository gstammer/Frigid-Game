using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //name of player object
    private Rigidbody2D body; 
    private Animator anim;
    private bool grounded;
    private BoxCollider2D boxCollider;
    private float wallClimbCooldown;
    private float horizontalInput;
    

    [SerializeField] private float speed;
    [SerializeField] private float jumpBoost;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private LayerMask wallLayer;

    //starts up when game is loaded
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //updates position state for for every frame of game
    private void Update() {

        float horizontalInput = Input.GetAxis("Horizontal");

        //flip player to face left and right
        if (horizontalInput < 0.01f) 
            transform.localScale = Vector3.one;
        else if (horizontalInput > -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);    

        //checks if character is running to play run animation
        anim.SetBool("run", horizontalInput != 0); 
        anim.SetBool("grounded", grounded);

        if(wallClimbCooldown > 0.2f)
        {
            //first coordinate is left and right movement
            //second designates no upward(y) movement
            body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

            if (isTouchingWall() && !isGrounded())
            {
                body.gravityScale = 0;
                body.velocity = Vector2.zero;
            }
            else
                body.gravityScale = 3;

            //makes character jump if "w" key pressed
           if(Input.GetKey(KeyCode.W))
                Jump();
        }
        else
            wallClimbCooldown += Time.deltaTime;
    }

    //puts jump in own method with grounded state and animation trigger to make more fluid transition
    //between jumping and idle states
    private void Jump() 
    {
        if(isGrounded())
        {
        body.velocity = new Vector2(body.velocity.x, jumpBoost);
        anim.SetTrigger("jump");
        } 
        else if (isTouchingWall() && !isGrounded()) 
        {
            if(horizontalInput == 0)
            {
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 10, 3);
                transform.localScale = new Vector3(-Mathf.Sign(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            else
                //returns force opposite the direction player is facing, and then upwards
                body.velocity = new Vector2(-Mathf.Sign(transform.localScale.x) * 3, 12);

            wallClimbCooldown = 0;
        }
    }

    //sets grounded state based on whether Player object is touching surface floor based on tag
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "SurfaceIce")
        grounded = true;
    }

    // uses a boxCollider object to determine if any part of the bottom of player is touching ground
    //works like a ray, however has better coverage than a singular line out from the center of the
    //object and prevents being unable to jump when on the edge of a block
    private bool isGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, Vector2.down, 0.01f, groundLayer);
        return raycastHit.collider != null;
    }

    //same as jump but evaluates "UnderIce" objects since they count as exposed wall; extends box in direction
    //of player
    private bool isTouchingWall()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0, new Vector2(transform.localScale.x, 0), 0.01f, wallLayer);
        return raycastHit.collider != null;
    }
}