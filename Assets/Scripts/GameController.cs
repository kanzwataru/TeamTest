using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    public Text scoreText;

    public void ScoreUpdated(bool playerWinner)
    {
        scoreText.enabled = true;
        if (playerWinner)
        {
            scoreText.text = "LEFT PLAYER WINS";
        }
        else
        {
            scoreText.text = "RIGHT PLAYER WINS";
        }
    }
	
}
