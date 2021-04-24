using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private float speed;
    
    void Start()
    {
        speed = 5f;
    }

    void FixedUpdate()
    {
        transform.Translate(-Vector2.up * speed * Time.deltaTime);
    }
}
