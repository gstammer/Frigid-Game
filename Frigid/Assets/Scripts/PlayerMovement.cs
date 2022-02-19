using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //name of player object
    private Rigidbody2D body; 

    //serialize feild makes variable editable from Unity 
    [SerializeField] private float speed; 

    //starts up when game is loaded
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    //updates position state for for every frame of game
    private void Update() {
        
        //gets left and right keystrokes
        float horizontalInput = Input.GetAxis("Horizontal");

        //makes character move left and right, no upwards(y) movement
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        //makes character "flip" to face left and right by transforming x scale b/t 1 and -1
        if(horizontalInput > 0.01f) 
            transform.localScale = Vector3.one * 6;
        else if(horizontalInput < -0.01f) 
            transform.localScale = new Vector3(-6, 6, 6);        

        //checks if spacebar was pressed to make character jump
        if(Input.GetKey(KeyCode.W))
            body.velocity = new Vector2(body.velocity.x, speed);
    }
}
