using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour {

    public float speed;
    public float maxVelocity;
    public float boostEnd;
    public Vector3 respawnPoint;

    private float _baseSpeed;

    private float _startingMaxVelocity;
    
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        boostEnd = Time.time;
        _baseSpeed = speed;
        // _rb.maxLinearVelocity = maxVelocity;
        respawnPoint = transform.position;
        _startingMaxVelocity = maxVelocity;

    }

    // Update is called once per frame
    void Update() {
        CheckMaxVelocity();
    }

    IEnumerator resetEffects() {
        yield return new WaitForSeconds(3f);

        print("RESETTING");
        
        maxVelocity = _startingMaxVelocity;
        CheckMaxVelocity();
        _rb.useGravity = true;
    }

    void CheckMaxVelocity() {
        float x = _rb.velocity.x;
        float y = _rb.velocity.y;
        float z = _rb.velocity.z;

        if (x * x + z * z > maxVelocity * maxVelocity) {
            Vector3 tmp = Vector3.Normalize(new Vector3(x, 0, z)) * maxVelocity;
            _rb.velocity = new Vector3(tmp.x, y, tmp.z);
        }
    }
}
