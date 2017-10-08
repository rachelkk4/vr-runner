using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

    public GameObject target;
    GameObject gameHUD;
    GameObject endGamePanel;
    GameObject gameOver;
    Coroutine generation;
    bool gameEnd;

	// Use this for initialization
	void Start () {
        this.gameHUD = GameObject.FindGameObjectWithTag("GameHUD");
        this.endGamePanel = GameObject.FindGameObjectWithTag("EndGamePanel");
        this.gameOver = GameObject.FindGameObjectWithTag("GameOver");

        gameHUD.SetActive(false);
        endGamePanel.SetActive(false);
        gameOver.SetActive(false);
        GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>().enabled = false;
        gameEnd = false;

        StartCoroutine( Opening() );
    }
	
	// Update is called once per frame
	void Update () {
		// When miss score reaches 3, end game
        if (CubeCustom.missCount == 3)
        {
            gameEnd = true;
        }
	}

    void EndGame () {
            StartCoroutine(Ending());  
    }

    IEnumerator Opening()
    {
        // wait for 2 seconds, let player load into scene
        yield return new WaitForSeconds(2);

        // give player a 3 second countdown to the game start
        Text countdown = GameObject.FindGameObjectWithTag("Countdown").GetComponent<Text>();
        countdown.text = "3";
        countdown.enabled = true;

        yield return new WaitForSeconds(1);
        countdown.text = "2";

        yield return new WaitForSeconds(1);
        countdown.text = "1";

        yield return new WaitForSeconds(1);
        countdown.text = "START!";
        yield return new WaitForSeconds(1);

        countdown.enabled = false;
        gameHUD.SetActive(true);

        // start generating targets
        generation = StartCoroutine(GenerateTargets());
    }

    IEnumerator Ending()
    {
        // Stop game - explode all currently loaded targets, change skybox color
        foreach (GameObject target in GameObject.FindGameObjectsWithTag("target"))
        {
            target.GetComponent<CubeCustom>().Explode();
        }

        GameObject.FindGameObjectWithTag("Time").GetComponent<TimerDisplay>().stop = true;

        // Display "GAME OVER" text
        gameOver.SetActive(true);

        yield return new WaitForSeconds(3);
        gameOver.SetActive(false);

        endGamePanel.SetActive(true);

        // Display stats: time and score, then display buttons to quit or try again
        GameObject score = GameObject.FindGameObjectWithTag("EndScore");
        score.GetComponent<Text>().text = string.Format("FINAL SCORE: {0}", CubeCustom.hitCount);

        // GameObject time = GameObject.FindGameObjectWithTag("EndTime");
        // time.GetComponent<Text>().text = string.Format("Time: {0} : {1:00} : {2:000}", 

        CubeCustom.hitCount = 0;
        CubeCustom.missCount = 0;
    }

    IEnumerator GenerateTargets() 
    {
        while (!gameEnd)
        {
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

            for (float i = 0; i < Random.Range(0f, 2f); i = i + 0.1f)
            {
                if (gameEnd)
                {
                    break;
                }
                else
                {
                    yield return new WaitForSeconds(0.1f);
                }
            }
        }

        if (gameEnd)
        {
            StartCoroutine(Ending());
        }

    }
}
