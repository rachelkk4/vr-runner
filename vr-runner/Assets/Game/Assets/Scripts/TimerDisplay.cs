using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerDisplay : MonoBehaviour {

    private float time;
    public Text timerLabel;
    public bool stop;
    float minutes;
    float seconds;
    float fraction;

    private void Start()
    {
        stop = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stop)
        {
            time += Time.deltaTime;

            minutes = time / 60; //Divides GUI time by 60 to get the minute
            seconds = time % 60; //Mod GUI time to get the seconds
            fraction = (time * 100) % 100;

            // Updating the label value
            timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
        }
        else
        {
            timerLabel.text = string.Format("{0:00} : {1:00} : {2:000}", minutes, seconds, fraction);
        }
    }
}
