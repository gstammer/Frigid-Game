using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //name of player object
    private Rigidbody2D body; 

    //starts up when game is loaded
    private void Awake() {
        body = GetComponent<Rigidbody2D>();
    }

    //updates position state for for every frame of game
    private void Update() {
        //first coordinate is left and right movement
        //second designates no upward movement
        body.velocity = new Vector2(Input.GetAxis("Horizontal"), body.velocity.y);
    }
}
