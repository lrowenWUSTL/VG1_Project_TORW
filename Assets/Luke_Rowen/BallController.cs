using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody _rb;

    public float speed;
    
    public float boostEnd;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        boostEnd = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            _rb.AddForce(Vector3.forward * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            _rb.AddForce(Vector3.back * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            _rb.AddForce(Vector3.left * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            _rb.AddForce(Vector3.right * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.Space)) {
            _rb.AddForce(Vector3.up * speed * Time.deltaTime);
        }
        
        if (Time.time > boostEnd) {
            speed = 1000f;
        }
    }
}
