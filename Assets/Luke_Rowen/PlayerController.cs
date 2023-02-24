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
    void Start() {
        ballTransform = ball.transform;
        _origionalLocalPosition = ballTransform.localPosition;
        _origionalLocalRotation = ballTransform.localRotation;
    }

    // Update is called once per frame
    void Update() {
        transform.position = ballTransform.position;

        transform.position += -transform.right * _origionalLocalPosition.x;
        transform.position += -transform.up * _origionalLocalPosition.y;
        transform.position += -transform.forward * _origionalLocalPosition.z;
        
        ballTransform.RotateAround(ballTransform.position, ballTransform.up, -_origionalLocalRotation.eulerAngles.y);

        ballTransform.localPosition = _origionalLocalPosition;
        

        Rigidbody ballRB = ball.GetComponent<Rigidbody>();
        float speed = ball.GetComponent<BallController>().speed;
        Vector3 euler = transform.rotation.eulerAngles;
        
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)) {
            ballRB.AddForce(transform.forward * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)) {
            ballRB.AddForce(-transform.forward * speed * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) {
            transform.rotation = Quaternion.Euler(euler.x, euler.y - (rotationSpeed * Time.deltaTime), euler.z);
            ballRB.AddForce(-transform.right * speed * 0.35f * Time.deltaTime);
        }
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
            transform.rotation = Quaternion.Euler(euler.x, euler.y + (rotationSpeed * Time.deltaTime), euler.z);
            ballRB.AddForce(transform.forward * speed * 0.35f * Time.deltaTime);
        }
        
        //ballTransform.localRotation = _origionalLocalRotation;
    }
}

//Holy shit thank you to https://www.youtube.com/watch?v=NFBEgKd1mSc
