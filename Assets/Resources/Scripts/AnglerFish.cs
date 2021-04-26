using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnglerFish : MonoBehaviour
{
    float speed, direction, upDown;
    bool goingRight;
    bool kill;
    GameObject target;

    void Start()
    {
        direction = transform.position.x < 0 ? 1 : -1;
        upDown = 0;
        speed = UnityEngine.Random.Range(20, 35) / 10;
        if (direction > 0)
        {
            goingRight = true;
        }
        FlipMe();
    }

    // Update is called once per frame
    void Update()
    {
        FlipMe();
        OutOfBounds();
        transform.Translate(new Vector2(speed * direction * Time.deltaTime, upDown));

        if (kill && target)
        {
            goingRight = target.transform.position.x < transform.position.x ? false : true;
            FindDirection(transform, target.transform);
            transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * 5 * Time.deltaTime);
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

    internal void FuckMeUp(GameObject gameO)
    {
        kill = true;
        target = gameO;
        GetComponent<Animator>().SetBool("targetSpooted", true);
        Debug.Log("GO!");
    }
}