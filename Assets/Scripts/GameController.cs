using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

    public Text scoreText;
    public RawImage leftGreenArrow1;
    public RawImage leftGreenArrow2;
    public RawImage rightGreenArrow1;
    public RawImage rightGreenArrow2;
    private bool victory = false;

    public void PlayerAngleChange(int player, int addArrow, int degree) //represent angle change with green arrow
    {
        if (addArrow == 1) 
        {
            if (degree == 0)
            {
                if (player == 2)
                    rightGreenArrow1.enabled = true;
                else
                    leftGreenArrow1.enabled = true;
            }
            else if (degree == 1)
            {
                if (player == 2)
                    rightGreenArrow2.enabled = true;
                else
                    leftGreenArrow2.enabled = true;
            }
        }
        else if (addArrow == -1) 
        {
            if (degree == 2)
            {
                if (player == 2)
                    rightGreenArrow2.enabled = false;
                else
                    leftGreenArrow2.enabled = false;
            }
            else if (degree == 1)
            {
                if (player == 2)
                    rightGreenArrow1.enabled = false;
                else
                    leftGreenArrow1.enabled = false;
            }
        }
    }

    public void ScoreUpdated(bool playerWinner)
    {
        scoreText.enabled = true;

        if (victory == false)
        {
            victory = true;
            if (playerWinner)
            {
                scoreText.text = "LEFT PLAYER WINS";
            }
            else
            {
                scoreText.text = "RIGHT PLAYER WINS";
            }
        }
        else
        {
            scoreText.text = "IT'S A TIE";
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
