using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour {
    private float _boostTime = 2f;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnCollisionEnter(Collision collision) {
        if (!collision.gameObject.GetComponent<BallController>()) return;

        Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
        ballRB.maxLinearVelocity *= 1.75f;
        ballRB.velocity *= 1.75f;

        collision.gameObject.GetComponent<BallController>().StartCoroutine("resetEffects");
    }
}