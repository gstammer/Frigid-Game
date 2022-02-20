using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    public GameObject Player;

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.right * Time.deltaTime * speed;
    }
    void LateUpdate(){
        Player = GameObject.FindWithTag("Player");
        transform.position = new Vector3(transform.position.x, Player.transform.position.y, transform.position.z);
    }
}
