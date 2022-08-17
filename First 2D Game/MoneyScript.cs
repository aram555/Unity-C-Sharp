using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyScript : MonoBehaviour
{
    public static int Coins = 0;
    public Text Money;
    void Start()
    {
        Money = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        Money.text = "Moneys:" + Coins.ToString();
    }
}
