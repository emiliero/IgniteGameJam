using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    float verticalMove = 0f;
    float horizontalMove = 0f;
    Rigidbody2D player;
    public float speed;
    public float goingDownSpeed;
    float moveByY;
    float moveByX;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void FixedUpdate ()
    {
        
    }

    void Move(){
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");
        
        moveByX = horizontalMove * speed;
        moveByY = verticalMove - goingDownSpeed;
        
        player.velocity = new Vector2(moveByY,player.velocity.y);
        player.velocity = new Vector2(moveByX,player.velocity.x);
    }
}
