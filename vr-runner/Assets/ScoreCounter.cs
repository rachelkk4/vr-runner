using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour {

    private int hitScore;
    private int missScore;

	// Use this for initialization
	void Start () {
        hitScore = 0;
        missScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        // When a block is clicked and destroyed, increase hit score by 1

        // When a block passes through the barrier, increase miss score by 1
	}
}
