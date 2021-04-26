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
        speed = UnityEngine.Random.Range(4, 6);
        timer = UnityEngine.Random.Range(7, 12);
        if (transform.position.x < 0) goingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        FlipMe();
        OutOfBounds();
        timer -= Time.deltaTime;
        if (timer > 0)
        {
            goingRight = FindDirection(transform, target.transform);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            if (transform.position.x < target.transform.position.x)
            {
                transform.Translate(Vector2.left * speed * .45f * Time.deltaTime);
            }
            else
            {
                transform.Translate(-Vector2.left * speed * .45f * Time.deltaTime);
            }
        }
        else
        {

            if (transform.position.x < 0)
            {
                goingRight = false;
                transform.Translate(Vector2.left * speed * 2 * Time.deltaTime);
            }
            else
            {
                goingRight = true;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coral")
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 0.2f;
            GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Coral")
        {
            Color tmp = GetComponent<SpriteRenderer>().color;
            tmp.a = 1f;
            GetComponent<SpriteRenderer>().color = tmp;
        }
    }

    void FlipMe()
    {
        if (!goingRight && transform.localScale.x < 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
        else if (goingRight && transform.localScale.x > 0)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
        }
    }
}
