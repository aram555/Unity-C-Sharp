using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int highScore;
    public Text highScoreText;

    private void Start()
    {
        highScore = PlayerPrefs.GetInt("Highscore");
        highScoreText.text = "HighScore: " + highScore.ToString();

        if(PlayerPrefs.GetInt("Score") > highScore)
        {
            highScore = PlayerPrefs.GetInt("Score");

            PlayerPrefs.SetInt("Highscore", highScore);
            highScoreText.text = "HighScore: " + highScore.ToString();
        }
        else
        {
            highScore = PlayerPrefs.GetInt("Highscore");
        }
    }
}
