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
    public Quaternion respawnRotation;

    private float _baseSpeed;

    private float _startingMaxVelocity;
    public float speedBoost = 2f;
    public float velocityBoost = 1.5f;
    public float sizeBoost = 1.5f;
    public float yDuration = 3f;
    public float yBoost = 5f;
    
    private Rigidbody _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
        boostEnd = Time.time;
        _baseSpeed = speed;
        // _rb.maxLinearVelocity = maxVelocity;
        respawnPoint = transform.position;
        respawnRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
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
    public void ApplyRandomBoost(float duration)
    {
        int randomBoost = UnityEngine.Random.Range(1, 5);
        switch (randomBoost)
        {
            case 1:
                StartCoroutine(speedBoostCoroutine(duration));
                break;
            case 2:
                StartCoroutine(VelocityCoroutine(duration));
                break;
            case 3:
                StartCoroutine(SizeBoostCoroutine(duration));
                break;
            case 4:
                //StartCoroutine(YBoostCoroutine(yDuration));
                break;
        }
    }
    private IEnumerator speedBoostCoroutine(float duration)
    {
        speed *= speedBoost;
        yield return new WaitForSeconds(duration);
        speed = _baseSpeed;
    }

    private IEnumerator VelocityCoroutine(float duration)
    {
        maxVelocity *= velocityBoost;
        yield return new WaitForSeconds(duration);
        maxVelocity = _startingMaxVelocity;
    }

    private IEnumerator SizeBoostCoroutine(float duration)
    {
        transform.localScale *= sizeBoost;
        yield return new WaitForSeconds(duration);
        transform.localScale /= sizeBoost;
    }

    private IEnumerator YBoostCoroutine(float duration)
    {
        float endTime = Time.time + duration;
        while (Time.time < endTime)
        {
            _rb.velocity = new Vector3(_rb.velocity.x, yBoost, _rb.velocity.z);
            yield return null;
        }
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
