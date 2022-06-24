using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateScore : MonoBehaviour
{
    public static int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Score: 0";
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Score: " + score.ToString();

        if(score >= 1 && score < 2){
            GameManager.gameSpeed = 15;
        }
        else if(score >= 3 && score < 4){
            GameManager.gameSpeed = 20;
        }
        else if(score >= 5){
            GameManager.gameSpeed = 25;
        }
        else if(score >= 6){
            GameManager.gameSpeed = 35;
        }
    }

}
