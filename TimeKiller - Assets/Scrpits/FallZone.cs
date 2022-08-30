using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour
{
    public int fallBallCount;
    public int FallBalls = 0;
    public GameObject Looze;

    private void Start() {
        fallBallCount = PlayerPrefs.GetInt("Fall") + 5;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(collision.gameObject);
        FallBalls++;

        if (FallBalls >= fallBallCount)
        {
            Time.timeScale = 0;
            Looze.SetActive(true);
        }
    }
}
