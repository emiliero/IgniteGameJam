using UnityEngine;

public class SeaHorse : MonoBehaviour
{
    float timer, speedTimer, speed;
    Vector2 direction;

    void Start()
    {
        GetComponent<SpriteRenderer>().color = new Color(Random.Range(0F, 1F), Random.Range(0, 1F), Random.Range(0, 1F));
        float size = Random.Range(50, 100);
        Debug.Log(size);
        transform.localScale = new Vector2(size/100, size/100);
        timer = Random.Range(1, 3);
        speed = Random.Range(2, 4);
        direction = new Vector2(Random.Range(-20, 20) / 10, Random.Range(-20, 20) / 10);
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBounds();
        if (timer < 0)
        {
            timer = Random.Range(1, 3);
            direction = new Vector2(Random.Range(-20, 20) / 10, Random.Range(-20, 20) / 10);
        }
        if (speedTimer < 0)
        {
            speed = Random.Range(2, 4);
            speedTimer = Random.Range(10, 50)/10;
        }

        timer -= Time.deltaTime;
        speedTimer -= Time.deltaTime;

        //transform.Rotate(new Vector2(Random.Range(10, 20), Random.Range(10, 20)));
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OutOfBounds()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
