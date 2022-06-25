using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetFinalHighScore : MonoBehaviour
{
    public GameManager gameManager;
    void Start()
    {
        int finalScore = 0;
        if (PlayerPrefs.HasKey("HiScore"))
             {
                int hiScore = PlayerPrefs.GetInt("HiScore");
                if(UpdateScore.score > hiScore){
                    finalScore = UpdateScore.score;
                    gameManager.Highscore();
                    PlayerPrefs.SetInt("HiScore", UpdateScore.score);
                    PlayerPrefs.Save();
                }
                else{
                    finalScore = hiScore;
                }   
             }
        else{
                PlayerPrefs.SetInt("HiScore",UpdateScore.score);
                PlayerPrefs.Save();
                gameManager.Highscore();    
                finalScore = UpdateScore.score;
            }

        GetComponent<UnityEngine.UI.Text>().text = "Hi-Score: " + finalScore;
    }
}
