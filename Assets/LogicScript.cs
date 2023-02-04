using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{

    public int playerScore;
    public Text scoreTest;
    public GameObject gameOverUI;

    public void addSocre(int score)
    {
        playerScore += score;
        scoreTest.text = playerScore.ToString();
    }

    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void showGameOverUI()
    {
        gameOverUI.SetActive(true);
    }

}

