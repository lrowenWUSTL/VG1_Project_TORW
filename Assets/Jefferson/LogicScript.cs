using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject gamePauseUI;

    bool paused = false;

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void backToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void showGameOverUI()
    {
        Time.timeScale = 0;
        gameOverUI.SetActive(true);
    }

    public void setGamePauseUI(bool state)
    {
        gamePauseUI.SetActive(state);
        paused = state;
        if (state)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
    }

    public void continueGame()
    {
        Time.timeScale = 0;
        setGamePauseUI(false);
    }

    public bool isPaused()
    {
        return paused;
    }

}