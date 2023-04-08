using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCode : MonoBehaviour
{
    public bool hasPassed;
    public Material passed;
    public Material notPassed;

    private Vector3 respawnPoint;
    void Start()
    {
        hasPassed = false;
        respawnPoint = new Vector3(transform.position.x, transform.position.y + 15, transform.position.z);
    }

    private void Update()
    {
        if(hasPassed == false)
        {
            GetComponent<MeshRenderer>().material = notPassed;
        }
        else
        {
            GetComponent<MeshRenderer>().material = passed;
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
        }
    }

}

