using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TudaSudaX : MonoBehaviour
{
    public float dirX1;
    public float dirX2;
    public float speed;
    public bool movingRight = true;
    public float timer;
    public float newtimer;
    
    void Update()
    {
        if(transform.position.x > dirX1)
        {
            movingRight = false;
        }
        if (transform.position.x < dirX2)
        {
            movingRight = true;
        }

        if (movingRight)
        {
            timer -= Time.deltaTime;
            if(timer <= 0) {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
                timer += Time.deltaTime;
            }
        } 
        else if(movingRight == false)
        {
            timer += Time.deltaTime;
            if(timer >= newtimer) {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
                timer -= Time.deltaTime;
            }
        }
    }
}
