using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Turtle : MonoBehaviour
{
    float speed, direction, upDown;
    bool goingRight;

    void Start()
    {
        direction = transform.position.x < 0 ? 1 : -1;
        upDown = 0;
        speed = Random.Range(20, 35) / 10;
        if (direction > 0)
        {
            goingRight = true;
        }
        FlipMe();
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

    private bool FindDirection(Transform me, Transform target)
    {
        return (me.position.x < target.position.x) ? true : false;
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
