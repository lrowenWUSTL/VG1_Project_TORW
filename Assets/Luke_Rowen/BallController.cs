using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour {
    public float speed;
    public float boostEnd;

    private float _baseSpeed;
    
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        boostEnd = Time.time;
        _baseSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > boostEnd) {
            speed = _baseSpeed;
        }
    }
}
