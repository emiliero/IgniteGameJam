using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class CoralSpawner : MonoBehaviour
{
    Transform player;
    float coralStep;
    GameObject coral1, coral2, coral3;

    void Start()
    {
        player = GameObject.Find("Player").transform;
        coralStep = -5;
        coral1 = (GameObject)Resources.Load($"Prefabs/Coral1", typeof(GameObject));
        coral2 = (GameObject)Resources.Load($"Prefabs/Coral2", typeof(GameObject));
        coral3 = (GameObject)Resources.Load($"Prefabs/Coral3", typeof(GameObject));
    }

    // Update is called once per frame
    void Update()
    {
        
        if (player!=null && player.position.y <= coralStep)
        {
            coralStep -= 25;
            SpawnCoral();
        }
    }


    private void SpawnCoral()
    {
        switch (UnityEngine.Random.Range(1,3))
        {
            case 1:
                SpawnCoral1();
                break;
            case 2:
                SpawnCoral2();
                break;
            case 3:
                SpawnCoral3();
                break;
        }
    }

    
    private void SpawnCoral1()
    {
        switch (UnityEngine.Random.Range(1,2))
        {
            case 1:
                var pos = new Vector3(-7.5f, GameObject.Find("Main Camera").transform.position.y - UnityEngine.Random.Range(7, 14), 0);
                Instantiate(coral1,pos,coral1.transform.rotation);
                break;
            case 2:
                var pos2 = new Vector3(7.5f, GameObject.Find("Main Camera").transform.position.y - UnityEngine.Random.Range(7, 14), 0);
                var tmp = Instantiate(coral1, pos2, coral1.transform.rotation);
                tmp.transform.Rotate(new Vector3(0, 0, 90));
                break;
        }
    }

    private void SpawnCoral2()
    {
        var pos = new Vector3(UnityEngine.Random.Range(-5f,5f), GameObject.Find("Main Camera").transform.position.y - UnityEngine.Random.Range(7, 14), 0);
        var tmp = Instantiate(coral2, pos, coral2.transform.rotation);
        tmp.transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 359)));
    }

    private void SpawnCoral3()
    {
        var pos = new Vector3(UnityEngine.Random.Range(-5f, 5f), GameObject.Find("Main Camera").transform.position.y - UnityEngine.Random.Range(7, 14), 0);
        var tmp = Instantiate(coral3, pos, coral3.transform.rotation);
        tmp.transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 359)));
    }
}
