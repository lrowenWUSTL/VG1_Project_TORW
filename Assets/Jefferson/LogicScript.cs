using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public GameObject gameOverUI;
    public GameObject gamePauseUI;
    public GameObject gameWonUI;

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

    public void showGameWonUI()
    {
        Time.timeScale = 0;
        gameWonUI.SetActive(true);
    }

    public void setGamePauseUI(bool state)
    {
        gamePauseUI.SetActive(state);
        paused = state;
        if (state)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void continueGame()
    {
        setGamePauseUI(false);
    }

    public bool isPaused()
    {
        return paused;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape) && gamePauseUI != null)
        {
            setGamePauseUI(true);
        }

        /*        if (Input.GetKey(KeyCode.Escape) && logic.isPaused())
                {
                    logic.setGamePauseUI(false);
                }*/
    }

}