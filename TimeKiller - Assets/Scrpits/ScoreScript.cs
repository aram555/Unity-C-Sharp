using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text FinishScore;
    public Text FallScore;
    public bool Bul;
    public int health;
    public GameObject FallZone;
    private FallZone fall;
    public int Money;
    // Start is called before the first frame update
    void Start()
    {
        fall = FallZone.GetComponent<FallZone>();
    }

    // Update is called once per frame
    void Update()
    {
        FallScore.text = "FallScore: " + fall.FallBalls;

        if(fall.FallBalls <= 0) {
            fall.FallBalls = 0;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Ball")
        {
            score++;
            scoreText.text = "Score: " + score.ToString();
            FinishScore.text = "Score: " + score.ToString();

            PlayerPrefs.SetInt("Score", score);
            Money += 1;
            PlayerPrefs.SetInt("Money", Money);
        }
        if(collision.collider.tag == "Health") {
            score++;
            scoreText.text = "Score: " + score.ToString();
            FinishScore.text = "Score: " + score.ToString();

            fall.FallBalls -= health;
            FallScore.text = "FallScore: " + fall.FallBalls;
            
            PlayerPrefs.SetInt("Score", score);
            Money += 2;
            PlayerPrefs.SetInt("Money", Money);
        }
    }
}
