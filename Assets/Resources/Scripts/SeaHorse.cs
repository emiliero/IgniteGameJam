using UnityEngine;

public class SeaHorse : MonoBehaviour
{
    float timer, speedTimer, speed;
    Vector2 direction;

    void Start()
    {
        float size = Random.Range(50, 100);
        transform.localScale = new Vector2(size/100, size/100);
        timer = 0.5f;
        speed = Random.Range(2, 4);
        direction = new Vector2(Random.Range(-20, 20) / 10, Random.Range(-20, 20) / 10);
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBounds();
        if (timer < 0)
        {
            timer = 3;
            direction = new Vector2(Random.Range(-20, 20) / 10, Random.Range(-20, 20) / 10);
        }
        if (speedTimer < 0)
        {
            speed = Random.Range(2, 3);
            speedTimer = Random.Range(10, 50)/10;
        }

        timer -= Time.deltaTime;
        speedTimer -= Time.deltaTime;

        transform.Translate(direction * speed * Time.deltaTime);
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
