using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextScript : MonoBehaviour
{
    public Text Moneys;
    public int Money;
    private Transform targets;
    EnemyScript enemy = new EnemyScript();
    Turrets turret = new Turrets();

    // Start is called before the first frame update 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Money = PlayerPrefs.GetInt("Moneys");
        Moneys.text = "Moneys: " + Money.ToString();
    }
}
