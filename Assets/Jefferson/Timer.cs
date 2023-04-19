using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{

    public float inMiliseconds;

    private TMP_Text timer_text;

    private void Awake()
    {
        timer_text = GetComponent<TMP_Text>();
    }

    private void Start()
    {

    }

    void Update()
    {
        float currentTime = Time.timeSinceLevelLoad;
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        float inSeconds = currentTime % 60;
        string seconds = inSeconds.ToString("00");
/*        float inMiliseconds = (currentTime - inSeconds) * 100;
        string miliseconds = inMiliseconds.ToString("00");*/

        timer_text.text = minutes + ":" + seconds;

        // timer_text.text = minutes + ":" + seconds + ":" + miliseconds;
    }

}
