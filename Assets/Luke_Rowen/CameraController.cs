using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform ballTransform;
  
    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        // Dot product of two normalized vector is equals to cos of theire angle.
        Rigidbody rgBall = ballTransform.GetComponent<Rigidbody>();
        
        float yRotation = -Mathf.Acos(Vector3.Dot(rgBall.velocity.normalized, Vector3.forward)) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, yRotation, 0);
    }
}

//Thanks to https://answers.unity.com/questions/1861711/how-to-make-the-camera-follow-and-face-a-rolling-o.html