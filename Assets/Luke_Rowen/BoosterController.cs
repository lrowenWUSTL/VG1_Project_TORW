using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour
{
    
    private float _boostTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update() {

    }

    private void OnCollisionEnter(Collision collision) {
        if(collision.gameObject.GetComponent<BallController>()) {
            BallController ball = collision.gameObject.GetComponent<BallController>();
            ball.boostEnd = Time.time + _boostTime;
            ball.speed *= 1.75f;
        }
    }
}
