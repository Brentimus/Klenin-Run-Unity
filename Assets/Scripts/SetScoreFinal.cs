using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetScoreFinal : MonoBehaviour
{
    void Update()
    {
        GetComponent<UnityEngine.UI.Text>().text = "Score: " + UpdateScore.score.ToString();
    }
}
