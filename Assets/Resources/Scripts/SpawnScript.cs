using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScript : MonoBehaviour
{
    int fuckery = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fuckery = fuckery >= 5 ? 0 : fuckery++;

        if (fuckery == 0)
        {
            GameObject cunt = Resources.Load("Prefabs/Enemy") as GameObject;
            
        }
    }
}
