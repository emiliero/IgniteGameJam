using UnityEngine;

public class Turtle : MonoBehaviour
{
    float speed;

    void Start()
    {
        speed = Random.Range(20, 35) / 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
