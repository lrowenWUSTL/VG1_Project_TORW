using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject ball;

    public float rotationSpeed;

    private Transform ballTransform;

    private Vector3 _origionalLocalPosition;
    private Quaternion _origionalLocalRotation;
    
    Rigidbody _ballRB; 
    float _speed; 
    void Start() {
        ballTransform = ball.transform;
        _origionalLocalPosition = ballTransform.localPosition;
        _origionalLocalRotation = ballTransform.localRotation;
        
        _ballRB = ball.GetComponent<Rigidbody>();
        _speed = ball.GetComponent<BallController>().speed;
    }

    // Update is called once per frame
    void Update() {
        transform.position = ballTransform.position;

        transform.position += -transform.right * _origionalLocalPosition.x;
        transform.position += -transform.up * _origionalLocalPosition.y;
        transform.position += -transform.forward * _origionalLocalPosition.z;
        
        ballTransform.RotateAround(ballTransform.position, ballTransform.up, -_origionalLocalRotation.eulerAngles.y);

        ballTransform.localPosition = _origionalLocalPosition;
        

        
        Vector3 euler = transform.rotation.eulerAngles;
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            _ballRB.velocity += transform.forward * _speed;
        }
        
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            _ballRB.velocity += -transform.forward * _speed;
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Euler(euler.x, euler.y - (rotationSpeed * Time.deltaTime), euler.z);
            _ballRB.velocity += -transform.right * _speed * 0.2f;
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Euler(euler.x, euler.y + (rotationSpeed * Time.deltaTime), euler.z);
            _ballRB.velocity += transform.right * _speed * 0.2f;
        }
    }
    
}

//Holy shit thank you to https://www.youtube.com/watch?v=NFBEgKd1mSc
