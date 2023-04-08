using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void EndGame()
    {
        Application.Quit();
    }

    public void track1()
    {
        SceneManager.LoadScene(2);
    }

    public void track2()
    {
        SceneManager.LoadScene(3);
    }

    public void track3()
    {
        SceneManager.LoadScene(4);
    }

    public void track4()
    {
        SceneManager.LoadScene(5);
    }

}