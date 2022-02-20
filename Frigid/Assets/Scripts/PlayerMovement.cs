using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //name of player object
    private Rigidbody2D body; 
    [SerializeField] private float speed;

    //starts up when game is loaded
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    //updates position state for for every frame of game
    private void Update() {

        float horizontalInput = Input.GetAxis("Horizontal");

        //first coordinate is left and right movement
        //second designates no upward(y) movement
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //makes character jump if "w" key pressed
        if(Input.GetKey(KeyCode.W)) 
            body.velocity = new Vector2(body.velocity.x, speed);

        //flip player to face left and right
        if (horizontalInput > 0.01f) 
            transform.localScale = Vector3.one;
        else if (horizontalInput < -0.01f)
            transform.localScale = new Vector3(-1, 1, 1);
            
    }



    

}
