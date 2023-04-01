using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointCode : MonoBehaviour
{
    public bool hasPassed;
    public Material passed;
    public Material notPassed;
    void Start()
    {
        hasPassed = false;
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
            Debug.Log("hi" + hasPassed);
            hasPassed = true;
        }
    }

}
