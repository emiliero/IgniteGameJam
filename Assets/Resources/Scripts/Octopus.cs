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

    void OutOfBounds()
    {
        if (transform.position.x < -10 || transform.position.x > 10)
        {
            Destroy(gameObject);
        }
    }
}
