using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    float speed, direction, upDown;

    void Start()
    {
        direction = transform.position.x < 0 ? 1 : -1;
        upDown = 0;
        speed = Random.Range(20, 35) / 10;
    }

    // Update is called once per frame
    void Update()
    {
        OutOfBounds();
        transform.Translate(new Vector2(speed * direction * Time.deltaTime, upDown));
        upDown += Random.Range(-1f, 1f) / 1000; 
    }

    void OutOfBounds()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
