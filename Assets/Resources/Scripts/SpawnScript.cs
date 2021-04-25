using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
//using System.Random as Random;

public class SpawnScript : MonoBehaviour
{
    private int _tickCounter;
    private string[] _snopp = new string[3] { "Turtle", "Octopus", "TinyFish" };
    private System.Random _chancifier = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        _tickCounter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _tickCounter++;

        if (_tickCounter % 100 == 0)
        {
            var right = _chancifier.Next(0, 2) == 0;
            int x;

            if (right)
            {
                x = 10;
            }
            else
            {
                x = -10;
            }

            if (right && transform.localScale.x > 0 || !right && transform.localScale.x < 0)
            {
                transform.localScale *= -1;
            }

            var snoppChooser = _chancifier.Next(_snopp.Length);
            var pos = new Vector3(x, GameObject.Find("Main Camera").transform.position.y - _chancifier.Next(7, 14), 0);
            var chosenSnopp = Resources.Load($"Prefabs/{_snopp[snoppChooser]}", typeof(GameObject)) as GameObject;

            if (chosenSnopp.name == "Octopus")
            {
                x = Random.Range(-10, 10);
                pos = new Vector3(x, GameObject.Find("Main Camera").transform.position.y - _chancifier.Next(7, 14), 0);
            }

            Instantiate(chosenSnopp, pos, chosenSnopp.transform.rotation);
        }
    }
}