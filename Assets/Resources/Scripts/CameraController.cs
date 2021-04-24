using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed;
    public float playerSpeed;
    
    void Start()
    {
        speed = 2f;
    }

    void FixedUpdate()
    {
        //transform.Translate(-Vector2.up * speed * Time.deltaTime);
        transform.Translate(-Vector2.up * playerSpeed * Time.deltaTime);
    }
}
