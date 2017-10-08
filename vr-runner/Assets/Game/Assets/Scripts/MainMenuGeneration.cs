using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuGeneration : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnObjects());
    }


    IEnumerator SpawnObjects()
    {
        while (true)
        {
            // generate random x position
            var rand = Random.Range(0, 3);
            var xpos = 0f;
            var zpos = -20f;

            if (rand == 0)
            {
                xpos = Random.Range(-50f, -25f);
                zpos = Random.Range(0f, 50f);
            }
            else if (rand == 1)
            {
                xpos = Random.Range(25f, 50f);
                zpos = Random.Range(0f, 50f);
            }
            else
            {
                xpos = Random.Range(-50f, 50f);
                zpos = Random.Range(-50f, 0f);
            }

            // add a new target
            Instantiate(target, new Vector3(xpos, -10f, zpos), Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(0f, 1f));
        }
    }
}
