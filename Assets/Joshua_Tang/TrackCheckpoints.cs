using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TrackCheckpoints : MonoBehaviour
{
    public GameObject[] checkpoints;
    public GameObject finalCheckpoint;
    public int totalLaps;
    public LogicScript logic;
    public TMP_Text lapCount;

    private int lapsCompleted;
    private CheckpointCode finalCheckpointComponent;
    // Start is called before the first frame update
    void Start()
    {
        lapsCompleted = 1;
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

        lapCount.text = "Lap #" + lapsCompleted.ToString() + " of " + totalLaps;

        if (lapsCompleted > totalLaps)
        {
            lapsCompleted = 1;
            lapCount.text = "Lap #" + totalLaps + " of " + totalLaps;
            logic.showGameWonUI();
        } else
        {
            lapCount.text = "Lap #" + lapsCompleted.ToString() + " of " + totalLaps;
        }

    }
}
