using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    private TMP_Text timer_text;
    private float nextActionTime = 0.0f;
    public float period = 0.01f;

    private void Awake()
    {
        timer_text = GetComponent<TMP_Text>();
    }

    private void Start()
    {

    }

    void Update()
    {
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            float currentTime = Time.timeSinceLevelLoad;
            string miliseconds = currentTime.ToString("0.00");
            char mili1 = miliseconds[miliseconds.Length - 2];
            char mili2 = miliseconds[miliseconds.Length - 1];
            miliseconds = mili1.ToString() + mili2.ToString();
            string minutes = Mathf.Floor(currentTime / 60).ToString("00");
            float inSeconds = currentTime % 60;
            string seconds = inSeconds.ToString("00");

            timer_text.text = minutes + ":" + seconds + ":" + miliseconds;
        }
    }

}