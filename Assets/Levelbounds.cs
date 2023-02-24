using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBounds : MonoBehaviour
{
    // Start is called before the first frame update
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<BallController>())
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}