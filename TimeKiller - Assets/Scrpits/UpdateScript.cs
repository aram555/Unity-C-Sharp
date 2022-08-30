using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateScript : MonoBehaviour
{
    [Header("ОбЪекты")]
    public GameObject Player;
    public GameObject FallZone;
    private PlayerMovement player;
    private ScoreScript score;
    private FallZone fall;
    [Header("Текст Speed")]
    public int speedT;
    public Text SpeedText;
    [Header("Текст Fall")]
    public int fallT;
    public Text FallText;
    [Header("Монеты")]
    public Text moneyText;
    public int moneysCount;
    void Start()
    {
        player = Player.GetComponent<PlayerMovement>();
        score = Player.GetComponent<ScoreScript>();
        fall = FallZone.GetComponent<FallZone>();

        speedT = PlayerPrefs.GetInt("Speed");
        SpeedText.text = speedT.ToString();

        fallT = PlayerPrefs.GetInt("Fall");
        FallText.text = fallT.ToString();

        moneysCount = PlayerPrefs.GetInt("Money");
        moneyText.text = "Moneys: " + moneysCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void SpeedUpdate() {
        if(moneysCount >= 10) {
            player.speed += 2;
            player.normalSpeed += 2;

            PlayerPrefs.SetInt("Speed", player.normalSpeed);
            speedT = PlayerPrefs.GetInt("Speed");
            SpeedText.text = speedT.ToString();

            moneysCount -= 10;
            PlayerPrefs.GetInt("Money");
            moneyText.text = "Moneys: " + moneysCount.ToString();
        }
        else return;
    }

    public void FallUpdate() {
        if(moneysCount >= 10) {
            fall.fallBallCount += 2;
            PlayerPrefs.SetInt("Fall", fall.fallBallCount);
            fallT = PlayerPrefs.GetInt("Fall");
            FallText.text = fallT.ToString();

            moneysCount -= 10;
            PlayerPrefs.GetInt("Money");
            moneyText.text = "Moneys: " + moneysCount.ToString();
        }
        else return;
    }
}