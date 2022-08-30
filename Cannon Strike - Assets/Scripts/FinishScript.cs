using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScript : MonoBehaviour
{
    public int ballsCount;
    public int finishCount;
    [Header("UI")]
    public Text FinishText;
    public GameObject victory;
    // Start is called before the first frame update
    void Start()
    {
        FinishText.text = ballsCount.ToString() + "/" + finishCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        FinishText.text = ballsCount.ToString() + "/" + finishCount.ToString();

        if(ballsCount >= finishCount) {
            victory.SetActive(true);
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Ball")) {
            Debug.Log("Trigger");
            ballsCount++;
        }
    }
}
