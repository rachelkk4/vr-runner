using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCustom : MonoBehaviour {

    float RandomSpeed;
    public GameObject explode;

    // Use this for initialization
    void Start () {
        StartCoroutine(FadeIn());
        gameObject.GetComponent<Renderer>().material.color = Color.red;
	}

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
	void Update () {
        RandomSpeed = Random.Range(3, 6);
        transform.Translate(Time.deltaTime * RandomSpeed, 0, 0, Space.World);

        transform.Rotate(Vector3.one, 30 * Time.deltaTime);
    }

    public void Explode()
    {
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "plane")
        {
            Explode();
        }
    }
    
    public void changeBlue()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.blue;
    }

    public void changeRed()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }

    public void changeYellow()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
    }

}
