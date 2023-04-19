using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;


public class TrackCheckpoints : MonoBehaviour
{
    public GameObject[] checkpoints;
    public GameObject finalCheckpoint;
    public int totalLaps;
    public LogicScript logic;
    public TMP_Text lapCount;

    private int lapsCompleted = 1;
    private CheckpointCode finalCheckpointComponent;
    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        lapsCompleted = 0;
        finalCheckpointComponent = finalCheckpoint.GetComponent<CheckpointCode>();
    }

    // Update is called once per frame
    void Update()
    {
        if (finalCheckpointComponent.hasPassed == true)
        {
            bool passed_all_checkpoints = true;
            finalCheckpointComponent.hasPassed = false;
            for (int i = 0; i < checkpoints.Length; i++)
            {
                CheckpointCode checkpointComponent = checkpoints[i].GetComponent<CheckpointCode>();
                if(checkpointComponent.hasPassed == false)
                {
                    passed_all_checkpoints = false;
                }
                checkpointComponent.hasPassed = false;

            }
            if (passed_all_checkpoints)
            {
                lapsCompleted += 1;
            }
            //Debug.Log(lapsCompleted);
        }

        lapCount.text = "Lap #" + lapsCompleted.ToString();

        if (lapsCompleted > totalLaps)
        {
            logic.showGameWonUI();
        }
    }
}
