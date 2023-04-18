using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : MonoBehaviour {
    private float _boostTime = 2f;
    public float boostStrength;

    // Start is called before the first frame update
    void Start() {
    }

    // Update is called once per frame
    void Update() {
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<BallController>() && boostStrength > 0 ) {
            Rigidbody ballRB = collision.gameObject.GetComponent<Rigidbody>();
            collision.gameObject.GetComponent<BallController>().maxVelocity *= boostStrength;

            Vector3 forward = collision.gameObject.GetComponentInParent<Transform>().forward;
            forward = new Vector3(forward.x, 0, forward.z);
            
            ballRB.AddForce(forward * boostStrength, ForceMode.Acceleration);

            collision.gameObject.GetComponent<BallController>().StartCoroutine("resetEffects");
        }
    }
}