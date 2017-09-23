using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{

    public GameObject center;
    Vector3 offset;
    float decelTime;
    float currentTime;
    Vector3 move;
    Vector3 rotate;
    float speed;
    Color fade;

    // Use this for initialization
    void Start()
    {
        // Vector perpendicular to the center
        offset = center.transform.position - this.transform.position;

        decelTime = 3;
        currentTime = 0;
        fade = Random.ColorHSV(0, 1, 1, 1, 1, 1, 0, 0);

        speed = Random.Range(0.01f, 0.05f);
        rotate = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));
    }

    private void Update()
    {
        float interpolatingFactor = currentTime / decelTime;
        move = Vector3.Slerp(offset * speed, Vector3.zero, interpolatingFactor);

        transform.position -= move;
        transform.Rotate(rotate);

        var material = GetComponent<Renderer>().material;
        var color = material.color;

        material.color = Color.Lerp(material.color, fade, 3.5f * Time.deltaTime);

        currentTime += Time.deltaTime;
    }
}
