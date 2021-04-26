using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CameraController camCon;
    float verticalMove = 0f;
    float horizontalMove = 0f;
    Rigidbody2D player;
    public float speed;
    public float goingDownSpeed;
    float moveByY;
    float moveByX;
    public TextMeshProUGUI txt;

    // Start is called before the first frame update
    void Start()
    {
        camCon = GameObject.Find("Main Camera").GetComponent<CameraController>();
        txt = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        player = GetComponent<Rigidbody2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        camCon.playerSpeed = -moveByY;
        UpdateScore();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(gameObject);
        }
    }

    void Move(){
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical") * 2;
        
        moveByX = horizontalMove * speed;
        moveByY = verticalMove - goingDownSpeed;
        
        player.velocity = new Vector2(moveByY,player.velocity.y);
        player.velocity = new Vector2(moveByX,player.velocity.x);
    }

    void UpdateScore()
    {
        txt.text = Math.Floor(transform.position.y * -1).ToString();
    }
}
