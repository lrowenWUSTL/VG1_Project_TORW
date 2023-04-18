using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BumperController : MonoBehaviour {
    public float bumperStrength;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<BallController>()) {
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
            ballRB.AddForce(Vector3.up * bumperStrength, ForceMode.Acceleration);

            collision.gameObject.GetComponent<BallController>().StartCoroutine("resetEffects");
        }
    }
}
