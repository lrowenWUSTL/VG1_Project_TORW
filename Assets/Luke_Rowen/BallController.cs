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
    
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        boostEnd = Time.time;
        _baseSpeed = speed;
        _rb.maxLinearVelocity = maxVelocity;
        respawnPoint = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > boostEnd) {
            speed = _baseSpeed;
        }

        _rb.velocity += Vector3.down * 10f;
        
        print(_rb.velocity.magnitude);
    }
}
