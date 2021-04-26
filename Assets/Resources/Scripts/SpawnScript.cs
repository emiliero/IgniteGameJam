using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class SpawnScript : MonoBehaviour
{
    private long _tickCounter;
    private int _snoppCountDown, _spawnNumber, _difficulty;
    private List<string> _snopp;
    private int[] _xOffsets = new int[2] { -10, 10 };
    private System.Random _chancifier = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        _tickCounter = 0;
        _snoppCountDown = 0;
        _snopp = new List<string>();
        _spawnNumber = Random.Range(60, 180);

        _snopp.Add("Turtle");

        //"Turtle", "Octopus", "TinyFish", "SeaHorse"
    }

    // Update is called once per frame
    void Update()
    {
        _tickCounter++;
        _snoppCountDown++;
        _difficulty = _difficulty < 59 ? (int) _tickCounter / 300 : 59;

        switch (_tickCounter)
        {
            case 300:
                _snopp.Add("SeaHorse");
                break;
            case 600:
                _snopp.Add("Octopus");
                break;
            case 900:
                _snopp.Add("TinyFish");
                break;
        }

        if (_snoppCountDown >= _spawnNumber)
        {
            _snoppCountDown = 0;
            _spawnNumber = Random.Range(60 - _difficulty, 180 - (_difficulty * 2));

            var snoppChooser = _snopp[_chancifier.Next(_snopp.Count)];
            var x = snoppChooser == "Octopus" ? Random.Range(-10, 10) : _xOffsets[_chancifier.Next(_xOffsets.Length)];
            var pos = new Vector3(x, GameObject.Find("Main Camera").transform.position.y - _chancifier.Next(7, 14), 0);
            var chosenSnopp = Resources.Load($"Prefabs/{snoppChooser}", typeof(GameObject)) as GameObject;

            Instantiate(chosenSnopp, pos, chosenSnopp.transform.rotation);
        }
    }
}