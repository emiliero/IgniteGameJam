using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnScript : MonoBehaviour
{
    private int _tickCounter;
    private string[] _snopp = new string[3] { "Turtle", "Octopus", "TinyFish" };
    private int[] _xOffsets = new int[2] { 5, -5 };
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

        if (_tickCounter % 120 == 0)
        {
            int x = _xOffsets[_chancifier.Next(_xOffsets.Length)];
            var snoppChooser = _chancifier.Next(_snopp.Length);
            var pos = new Vector3(x, GameObject.Find("Main Camera").transform.position.y - _chancifier.Next(3, 7), 0);
            var chosenSnopp = Resources.Load($"Prefabs/{_snopp[snoppChooser]}", typeof(GameObject)) as GameObject;

            Instantiate(chosenSnopp, pos, chosenSnopp.transform.rotation);
        }
    }
}