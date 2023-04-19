using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCode : MonoBehaviour
{
    public bool hasPassed;
    public Material passed;
    public Material notPassed;
    public float Duration = 2f;
    private Vector3 respawnPoint;
    private Transform child;
    void Start()
    {
        hasPassed = false;
        respawnPoint = new Vector3(transform.position.x, transform.position.y + 15, transform.position.z);
        child = gameObject.transform.GetChild(0);
    }

    private void Update()
    {
        if(hasPassed == false)
        {
            child.GetComponent<MeshRenderer>().material = notPassed;
        }
        else
        {
            child.GetComponent<MeshRenderer>().material = passed;
        }
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.GetComponent<BallController>())
        {
            //Debug.Log("hi" + hasPassed);
            hasPassed = true;
            other.gameObject.GetComponent<BallController>().respawnPoint = respawnPoint;
            other.gameObject.GetComponent<BallController>().ApplyRandomBoost(Duration);
        }
    }

}

