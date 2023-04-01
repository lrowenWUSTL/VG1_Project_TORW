using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class AISplineKnotFollower : MonoBehaviour
{
    public SplineContainer splineContainer;
    public GameObject ball;
    public float maxSpeed;
    public int speed;

    Rigidbody ballRB;
    Spline spline;
    BezierKnot[] knots;
    Vector3 splineTransition;
    Vector3 waypointToBallVec;
    int knotCount;
    int knotIndex;
    float waypointCompleteDist;
    // Start is called before the first frame update
    void Start()
    {
        splineTransition = new Vector3(6.19693f, 0.09999847f, -94.1002f);
        spline = splineContainer.Spline;
        knots = spline.ToArray();
        knotCount = knots.Length;
        waypointCompleteDist = 10.0f;
        waypointToBallVec = (Vector3)(knots[0].Position) + splineTransition - ball.transform.position;
        ballRB = ball.GetComponent<Rigidbody>();
    }

    void checkKnotUpdateVec()
    {
        if(waypointToBallVec.magnitude <= waypointCompleteDist)
        {
            if(knotIndex == knotCount - 1)
            {
                knotIndex = 0;
            }
            else
            {
                knotIndex += 1;
            }
        }
        waypointToBallVec = (Vector3)(knots[knotIndex].Position) + splineTransition - ball.transform.position;
    }

    void updateVelocity()
    {
        Vector3 velocity = new Vector3(waypointToBallVec.x, 0, waypointToBallVec.z);
        ballRB.AddForce(velocity * Time.deltaTime * speed * 10);
        if (ballRB.velocity.magnitude > maxSpeed)
        {
            ballRB.velocity = ballRB.velocity.normalized * maxSpeed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        checkKnotUpdateVec();
        updateVelocity();
    }

  
}
