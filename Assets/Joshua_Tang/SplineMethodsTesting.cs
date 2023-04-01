using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;


public class SplineMethodsTesting : MonoBehaviour
{
    public SplineContainer splineContainer;
    public GameObject ball;

    Spline spline;
    BezierKnot[] knots;
    Vector3 splineTransition;
    int knotCount;
    // Start is called before the first frame update
    //Debug.DrawRay(transform.position, Vector2.down * .85f);
    void Start()
    {
        splineTransition = new Vector3(6.19693f, 0.09999847f, -94.1002f);
        spline = splineContainer.Spline;
        knots = spline.ToArray();
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.DrawRay(transform.position, ((Vector3)(knots[0].Position)+splineTransition-ball.transform.position) * .2f);
        //Debug.Log((Vector3)(knots[0].Position));
        //Debug.Log(ball.transform.position);
        //Debug.Log((Vector3)(knots[0].Position)-ball.transform.position);
        //Debug.DrawRay(transform.position, knots[0].TangentOut);

    }
}
