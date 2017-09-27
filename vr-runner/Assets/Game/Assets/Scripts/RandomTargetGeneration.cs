using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTargetGeneration : MonoBehaviour {

    public GameObject target;

    // Use this for initialization
    void Start () {
        StartCoroutine( SpawnObjects() );
	}

    
	IEnumerator SpawnObjects()
    {
        while (true) {
            // generate random y and z position
            float rand1 = Random.Range(0, 2);
            float ypos = 5f;
            float zpos = 5f;

            // upper box area
            if (rand1 == 0)
            {
                ypos = Random.Range(9f, 15f);
                zpos = Random.Range(-10f, 10f);
            }
            // bottom area, left side
            else if (rand1 == 1)
            {
                ypos = Random.Range(5f, 9f);
                zpos = Random.Range(-10f, -2f);
            }
            // bottom area, right side
            else if (rand1 == 2)
            {
                ypos = Random.Range(5f, 9f);
                zpos = Random.Range(2f, 10f);
            }
            // add a new target
            Instantiate(target, new Vector3(-30f, ypos, zpos), Quaternion.identity);

            yield return new WaitForSeconds(Random.Range(0f, 2f));
        }
	}
}
