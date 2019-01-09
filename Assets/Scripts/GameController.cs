using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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

    public void PlayerHit(bool playerWinner)
    {
        ScoreUpdated(playerWinner); //Show Score
        StartCoroutine(WaitToLoad());
    }

    private IEnumerator WaitToLoad()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("SampleScene"); //Reset
    }

}
