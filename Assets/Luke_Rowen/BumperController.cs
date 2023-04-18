using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.GetComponent<BallController>()) return;

        Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
        ballRB.AddForce(Vector3.up * 20f, ForceMode.Acceleration);

        collision.gameObject.GetComponent<BallController>().StartCoroutine("resetEffects");
    }
}
