using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moneys : MonoBehaviour
{
    public int moneys;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("Moneys", moneys);
        Debug.Log(PlayerPrefs.GetInt("Moneys"));
    }
}
