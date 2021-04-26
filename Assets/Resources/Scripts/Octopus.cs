using UnityEditor;
using UnityEngine;

public class Octopus : MonoBehaviour
{
    float startY, speed;
    bool goingUp = true;
    int direction;

    void Start()
    {
        speed = 5f;
        startY = transform.position.y;
        direction = transform.position.x < 0 ? 1 : -1;
    }

    void FixedUpdate()
    {
        OutOfBounds();
        if (goingUp)
        {
            if (transform.position.y <= startY + 1.4)
            {
                transform.Translate(new Vector3(1f * direction, 2f, 0) * speed * Time.deltaTime);
            }
            else
            {
                goingUp = false;
            }
        }
        else
        {
            if (transform.position.y >= startY - 1.4f)
            {
                transform.Translate(new Vector3(0.1f * direction, -.5f, 0) * speed * Time.deltaTime);
            }
            else
            {
                goingUp = true;
            }
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

    void OutOfBounds()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
