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
    public float speed, vSpeed;
    public float goingDownSpeed;
    float moveByY;
    float moveByX;
    public TextMeshProUGUI txt;
    public GameObject stopples, trail;

    // Start is called before the first frame update
    void Start()
    {
        vSpeed = 1.8f;
        camCon = GameObject.Find("Main Camera").GetComponent<CameraController>();
        txt = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        player = GetComponent<Rigidbody2D> ();
        stopples = GameObject.Find("Stopples");
        trail = GameObject.Find("Trail");
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        camCon.playerSpeed = -moveByY;
        UpdateScore();
        if (Input.GetKeyDown(KeyCode.W))
        {
            stopples.GetComponent<ParticleSystem>().Play();
        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            stopples.GetComponent<ParticleSystem>().Stop();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coral")
        {
            speed = 3.5f;
            vSpeed = 1.3f;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coral")
        {
            speed = 5f;
            vSpeed = 1.8f;
        }
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
        verticalMove = Input.GetAxis("Vertical") * vSpeed;
        
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
