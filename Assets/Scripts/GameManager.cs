using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool gameRunning = false;
    public GameObject scoreCanvas;
    public GameObject gameOverCanvas;
    public GameObject startGameCanvas;
    public GameObject highscore;
    public static int gameSpeed = 12;
    public bool flagGameover = false;
    void Start()
    {
        Time.timeScale = 0;
        scoreCanvas.SetActive(false);
        gameOverCanvas.SetActive(false);
        highscore.SetActive(false);
        startGameCanvas.SetActive(true);
        gameSpeed = 10;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Delete))
        {
            PlayerPrefs.DeleteAll();
        }

        if(Input.GetKey(KeyCode.Space) && !gameRunning){
            Time.timeScale = 1;
            gameRunning = true;
            scoreCanvas.SetActive(true);
            startGameCanvas.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Space) && flagGameover)
        {
            ResetGame();
        }
    }

    public void Highscore()
    {
        highscore.SetActive(true);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        scoreCanvas.SetActive(false);
        flagGameover = true;
    }

    public void ResetGame()
    {
        gameRunning = false;
        SceneManager.LoadScene(0);
    }
}
