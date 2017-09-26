using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		// wait for 3 seconds, let player load into scene

        // give player a 3 second countdown to the game start

        // start generating targets
	}
	
	// Update is called once per frame
	void Update () {
		// When miss score reaches 3, end game

        
	}

    void EndGame () {
        // Stop game - explode all currently loaded targets, change skybox color

        // Display "GAME OVER" text

        // Display stats: time and score, then display buttons to quit or try again
    }
}
