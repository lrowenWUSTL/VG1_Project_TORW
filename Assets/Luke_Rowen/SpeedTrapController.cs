using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedTrapController : MonoBehaviour {
    private float _slowTime = 1f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.GetComponent<BallController>()) return;

        Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
        ballRB.maxLinearVelocity *= 0.65f;
        ballRB.velocity *= 0.65f;

        collision.gameObject.GetComponent<BallController>().StartCoroutine("resetEffects");
    }
}