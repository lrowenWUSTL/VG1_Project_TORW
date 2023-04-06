 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BaseBorder : MonoBehaviour
{

    public LogicScript logic;

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallController>())
        {
            other.transform.position = other.gameObject.GetComponent<BallController>().respawnPoint;
            other.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        }
    }


}
