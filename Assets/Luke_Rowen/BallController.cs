using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BallController : MonoBehaviour
{
    Rigidbody _rb;

    public float speed;

    private float _boostTime = 1f;

    private float _boostEnd;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        _boostEnd = Time.time;
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
    }

    private void OnCollisionEnter(Collision collision) {
        print(">>> " + collision.gameObject.name);

        if(collision.gameObject.GetComponent<BoosterController>()) {
            _boostEnd = Time.time + _boostTime;
            speed = 1750f;
        }

        if (Time.time > _boostEnd) {
            speed = 1000f;
        }

        if (collision.gameObject.GetComponent<Backstop>()) {
            _rb.ResetInertiaTensor();
        }

        if (collision.gameObject.GetComponent<BumperController>()) {
            _rb.AddForce(Vector3.up * 20000f);
        }
    }
}
