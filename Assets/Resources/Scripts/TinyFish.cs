using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TinyFish : MonoBehaviour
{
    GameObject target;
    float speed, timer;
    bool goingRight;

    void Start()
    {
        target = GameObject.Find("Player");
        speed = 3;
        timer = UnityEngine.Random.Range(7, 12);
        if (transform.position.x < 0) goingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!goingRight && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if(goingRight && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        OutOfBounds();
        goingRight = FindDirection(transform, target.transform);
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

    private bool FindDirection(Transform me, Transform target)
    {
        return (me.position.x < target.position.x) ? true : false;
    }

    void OutOfBounds()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
