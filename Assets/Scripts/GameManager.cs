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

    public AudioSource music;
    public AudioSource deathSound;
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
            deathSound.Play();
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

        if (Input.GetButton("Jumping") && !gameRunning){
            music.Play();
            Time.timeScale = 1;
            gameRunning = true;
            scoreCanvas.SetActive(true);
            startGameCanvas.SetActive(false);
        }

        if (Input.GetButtonDown("Jumping") && flagGameover)
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
        music.Stop();
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
