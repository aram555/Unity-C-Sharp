using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallZone : MonoBehaviour
{
    public float timer;
    public float newTimer;
    public bool fall;
    Vector3 Pos;
    // Start is called before the first frame update
    void Start()
    {
        Pos = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(fall == true) {
            timer -= Time.deltaTime;

            if(timer <= 0) {
                transform.position = new Vector3(0, -10, 0);
                timer += Time.deltaTime;
            }
        }
        else if(fall == false) {
            timer += Time.deltaTime;

            if(timer >= newTimer) {
                transform.position = Pos;
                timer = newTimer;
            }
        }
    }
    private void OnCollisionEnter(Collision other) {
        if(other.collider.tag == "Player") {
            fall = true;
        }
    }
    private void OnCollisionExit(Collision other) {
        if(other.gameObject.name == "PlayerOne") {
            fall = false;
        }
    }
}
