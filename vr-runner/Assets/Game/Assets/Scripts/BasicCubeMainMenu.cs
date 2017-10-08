using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCubeMainMenu : MonoBehaviour {

    float RandomSpeed;
    public GameObject explode;

    // New cube targets should fade in and be red in color.
    void Start()
    {
        StartCoroutine(FadeIn());
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        RandomSpeed = Random.Range(3, 6);  // initialize cube travel speed
    }

    // Fade in script
    IEnumerator FadeIn()
    {
        for (float f = 0f; f <= 1; f += 0.05f)
        {
            Color c = Color.red;
            c.a = f;
            gameObject.GetComponent<Renderer>().material.color = c;
            yield return null;
        }
    }

    // Update is called once per frame
    // The cube moves linearly towards the player and rotates as it moves
    void Update()
    {
        transform.Translate(0, Time.deltaTime * RandomSpeed, 0, Space.World);

        transform.Rotate(Vector3.one, 30 * Time.deltaTime);

        if (transform.position.y == 300f)
        {
            Explode();
        }
    }

    public void Explode()
    {
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
