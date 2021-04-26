using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnScript : MonoBehaviour
{
    private long _tickCounter;
    private int _snoppCountDown, _spawnNumber, _difficulty;
    private string[] _snopp = new string[4] { "Turtle", "Octopus", "TinyFish", "SeaHorse" };
    private int[] _xOffsets = new int[2] { -10, 10 };
    private System.Random _chancifier = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        _tickCounter = 0;
        _snoppCountDown = 0;
        _spawnNumber = Random.Range(60, 180);
    }

    // Update is called once per frame
    void Update()
    {
        _tickCounter++;
        _snoppCountDown++;
        _difficulty = _difficulty < 59 ? (int) _tickCounter / 300 : 59;

        if (_snoppCountDown >= _spawnNumber)
        {
            _snoppCountDown = 0;
            _spawnNumber = Random.Range(60 - _difficulty, 180 - (_difficulty * 2));

            var snoppChooser = _snopp[_chancifier.Next(_snopp.Length)];
            var x = snoppChooser == "Octopus" ? Random.Range(-10, 10) : _xOffsets[_chancifier.Next(_xOffsets.Length)];
            var pos = new Vector3(x, GameObject.Find("Main Camera").transform.position.y - _chancifier.Next(7, 14), 0);
            var chosenSnopp = Resources.Load($"Prefabs/{snoppChooser}", typeof(GameObject)) as GameObject;

            Instantiate(chosenSnopp, pos, chosenSnopp.transform.rotation);
        }
    }
}