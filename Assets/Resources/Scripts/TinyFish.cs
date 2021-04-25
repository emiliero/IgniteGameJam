using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TinyFish : MonoBehaviour
{
    GameObject target;
    float speed, timer;


    void Start()
    {
        target = GameObject.Find("Player");
        speed = 3;
        timer = Random.Range(7, 12);
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBounds();
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if (transform.position.x < target.transform.position.x)
            {
                transform.Translate(Vector2.left * speed * .5f * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.left * speed * .5f * Time.deltaTime);
            }
        }
        else
        {
            if (transform.position.x < 0)
            {
                transform.Translate(Vector2.left * speed * 2 * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.left * speed * 2 * Time.deltaTime);
            }
        }
    }

    void OutOfBounds()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
