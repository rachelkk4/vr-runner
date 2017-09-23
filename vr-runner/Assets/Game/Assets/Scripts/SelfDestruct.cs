using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour {

    
    // Use this for initialization
    void Start () {
        StartCoroutine(Destruct());
      }

    private void Update()
    {
        transform.Translate(Time.deltaTime, 0, 0, Space.World);
    }

    IEnumerator Destruct()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}
