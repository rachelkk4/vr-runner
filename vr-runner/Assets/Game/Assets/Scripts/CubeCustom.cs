using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeCustom : MonoBehaviour {

    float RandomSpeed;
    public GameObject explode;

    public Text missCountText;
    public static int missCount;

    public Text hitCountText;
    public static int hitCount;

    // New cube targets should fade in and be red in color.
    void Start () {
        StartCoroutine(FadeIn());
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        RandomSpeed = Random.Range(3, 6);  // initialize cube travel speed

        missCountText = GameObject.FindGameObjectWithTag("MissText").GetComponent<Text>();
        hitCountText = GameObject.FindGameObjectWithTag("HitText").GetComponent<Text>();
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
	void Update () {
        transform.Translate(Time.deltaTime * RandomSpeed, 0, 0, Space.World);

        transform.Rotate(Vector3.one, 30 * Time.deltaTime);
    }

    public void Explode()
    {
        Instantiate(explode, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void increaseMissCount()
    {
        missCount++;
        missCountText.text = string.Format("Misses: {0:00}", missCount);
    }

    public void increaseHitCount()
    {
        hitCount++;
        hitCountText.text = string.Format("Hits: {0:00}", hitCount);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "plane")
        {
            increaseMissCount();
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
