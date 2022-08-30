using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CannonScript : MonoBehaviour
{
    [Header("Balls")]
    public int ballCount;
    public GameObject ball;
    public Transform spawnPos;
    [Header("UI")]
    public Text ballCountText;
    [Header("Music")]
    public AudioSource shoot;
    // Start is called before the first frame update
    void Start()
    {
        ballCountText.text = "Ball Count " + ballCount.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        ballCountText.text = "Ball Count " + ballCount.ToString();

        if(!EventSystem.current.IsPointerOverGameObject()) {
            if(Input.GetMouseButtonDown(0) && ballCount > 0) {
                shoot.Play();
                GameObject Ball = (GameObject)Instantiate(ball, spawnPos.position, spawnPos.rotation);
                ballCount--;

                if(ballCount == 0) Ball.GetComponent<DefeatScript>().enabled = true;
                else Ball.GetComponent<DefeatScript>().enabled = false;
            }
            else {
                return;
            }
        }
    }
}
